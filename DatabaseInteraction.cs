using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.IO;
using System.Linq;
using System.Windows.Forms;

namespace BankingSite
{
    public class DatabaseInteraction
    {
        #region class variables
        string _connectionString;
        string _connectedDatabase;

        const string SQL_FOLDER = @"..\..\SQL\";
        const string INSERT_DATA_FOLDER = SQL_FOLDER + @"InsertData\";
        const string CREATE_TABLE_FOLDER = SQL_FOLDER + @"CreateTable\";
        const string GET_DATA_FOLDER = SQL_FOLDER + @"GetData\";
        const string UPDATE_TABLE_FOLDER = SQL_FOLDER + @"UpdateTable\";
        const string DELETE_FOLDER = SQL_FOLDER + @"DeleteData\";

        const string ADDRESS = "Address";
        const string CUSTOMER = "Customer";
        const string ACCOUNT = "Account";
        const string TRANSACTION = "Transaction";

        const string SQL_EXTENSION = ".sql";
        #endregion

        #region Manage DB Connection
        /// <summary>
        /// If a connection can be made then the connection string will be changed to that.
        /// </summary>
        /// <param name="myDb"></param>
        /// <param name="myServerName"></param>
        /// <param name="myUsername"></param>
        /// <param name="myPassword"></param>
        /// <returns></returns>
        public void CanConnectToServer(string myDb, string myServerName, string myUsername, string myPassword)
        {
            string cnString = string.Concat("Data Source=", myServerName, ";Initial Catalog=", myDb, ";UID=", myUsername, ";Password=", myPassword,
                        ";Integrated Security=False;TrustServerCertificate=True");
            SqlConnectionStringBuilder builder = new SqlConnectionStringBuilder(cnString);
            builder.ConnectTimeout = 5;

            using (SqlConnection cn = new SqlConnection(builder.ConnectionString))
            {
                cn.Open();
                _connectionString = cnString;
                _connectedDatabase = myDb;
            }
        }

        /// <summary>
        /// Gets all Database Names within the currently connected server.
        /// </summary>
        /// <returns></returns>
        public string[] GetDatabases()
        {
            using (SqlConnection cn = new SqlConnection(_connectionString))
            {
                cn.Open();

                SqlCommand cmd = cn.CreateCommand();
                cmd.CommandText = "SELECT name FROM sys.databases";
                cmd.CommandTimeout = 5;

                using (SqlDataReader reader = cmd.ExecuteReader())
                {
                    string[] systemDatabases = { "master", "tempdb", "model", "msdb" };
                    List<string> returnedDatabases = new List<string>();

                    while (reader.Read())
                    {
                        string databaseName = reader.GetString(0);

                        if (!systemDatabases.Contains(databaseName))
                        {
                            returnedDatabases.Add(databaseName);
                        }
                    }
                    return returnedDatabases.ToArray();
                }
            }
        }

        public List<string> GetMissingTables()
        {
            using (SqlConnection cn = new SqlConnection(_connectionString))
            {
                cn.Open();

                SqlCommand cmd = cn.CreateCommand();
                cmd.CommandText = "SELECT TABLE_NAME FROM INFORMATION_SCHEMA.TABLES";
                cmd.CommandTimeout = 5;

                List<string> tableNames = new List<string> { ADDRESS, CUSTOMER, ACCOUNT, TRANSACTION };

                using (SqlDataReader reader = cmd.ExecuteReader())
                {
                    while (reader.Read())
                    {
                        string currentTableName = reader.GetString(0);
                        if (tableNames.Contains(currentTableName))
                        {
                            tableNames.Remove(currentTableName);
                        }
                    }
                    return new List<string>(tableNames);
                }
            }
        }

        public bool IsConnectedToSysDb()
        {
            string[] systemDatabases = { "master", "tempdb", "model", "msdb" };
            return systemDatabases.Contains(_connectedDatabase);
        }

        /// <summary>
        /// Creates the required tables that are missing.
        /// </summary>
        public void CreateTables(List<string> myMissingTables)
        {
            bool tablesCreated = false;
            foreach (string missingTable in myMissingTables)
            {
                using (SqlConnection cn = new SqlConnection(_connectionString))
                {
                    cn.Open();
                    SqlCommand cmd = cn.CreateCommand();
                    cmd.CommandTimeout = 5;

                    if (missingTable.Equals(ADDRESS))
                    {
                        cmd.CommandText = File.ReadAllText(string.Concat(CREATE_TABLE_FOLDER, ADDRESS, SQL_EXTENSION));
                        cmd.ExecuteNonQuery();
                        continue;
                    }

                    if (missingTable.Equals(CUSTOMER))
                    {
                        cmd.CommandText = File.ReadAllText(string.Concat(CREATE_TABLE_FOLDER, CUSTOMER, SQL_EXTENSION));
                        cmd.ExecuteNonQuery();
                        continue;
                    }

                    if (missingTable.Equals(ACCOUNT))
                    {
                        cmd.CommandText = File.ReadAllText(string.Concat(CREATE_TABLE_FOLDER, ACCOUNT, SQL_EXTENSION));
                        cmd.ExecuteNonQuery();
                        continue;
                    }

                    if (missingTable.Equals(TRANSACTION))
                    {
                        cmd.CommandText = File.ReadAllText(string.Concat(CREATE_TABLE_FOLDER, TRANSACTION, SQL_EXTENSION));
                        cmd.ExecuteNonQuery();
                        tablesCreated = true;
                        continue;
                    }
                }
            }

            if (tablesCreated)
            {
                CreateTrigger();
            }
        }

        void CreateTrigger()
        {
            using (SqlConnection cn = new SqlConnection(_connectionString))
            {
                cn.Open();
                SqlCommand cmd = cn.CreateCommand();
                cmd.CommandTimeout = 5;

                cmd.CommandText = File.ReadAllText(string.Concat(CREATE_TABLE_FOLDER, "CustomerTrigger", SQL_EXTENSION));
                cmd.ExecuteNonQuery();

                cmd.CommandText = File.ReadAllText(string.Concat(CREATE_TABLE_FOLDER, "AccountTrigger", SQL_EXTENSION));
                cmd.ExecuteNonQuery();
            }
        }
        #endregion

        #region SQL Insert Methods
        public void InsertToAllTables()
        {
            using (SqlConnection cn = new SqlConnection(_connectionString))
            {
                cn.Open();
                SqlCommand cmd = cn.CreateCommand();
                cmd.CommandTimeout = 5;

                cmd.CommandText = File.ReadAllText(string.Concat(INSERT_DATA_FOLDER, "DefaultAddresses", SQL_EXTENSION));
                cmd.ExecuteNonQuery();

                cmd.CommandText = File.ReadAllText(string.Concat(INSERT_DATA_FOLDER, "DefaultCustomers", SQL_EXTENSION));
                cmd.ExecuteNonQuery();

                cmd.CommandText = File.ReadAllText(string.Concat(INSERT_DATA_FOLDER, "DefaultAccounts", SQL_EXTENSION));
                cmd.ExecuteNonQuery();

                cmd.CommandText = File.ReadAllText(string.Concat(INSERT_DATA_FOLDER, "DefaultTransactions", SQL_EXTENSION));
                cmd.ExecuteNonQuery();
            }
        }

        public void InsertCustomer(string myFirstName, string myLastName, int myPhoneNumber, string myEmail, int myAddressID)
        {
            using (SqlConnection cn = new SqlConnection(_connectionString))
            {
                cn.Open();
                SqlCommand cmd = cn.CreateCommand();
                cmd.CommandText = File.ReadAllText(string.Concat(INSERT_DATA_FOLDER, CUSTOMER, SQL_EXTENSION));
                cmd.CommandTimeout = 5;

                cmd.Parameters.AddWithValue("@FirstName", myFirstName);
                cmd.Parameters.AddWithValue("@LastName", myLastName);
                cmd.Parameters.AddWithValue("@PhoneNumber", myPhoneNumber);
                cmd.Parameters.AddWithValue("@EmailAddress", myEmail);
                cmd.Parameters.AddWithValue("@Address_ID", myAddressID);
                cmd.ExecuteNonQuery();
            }
        }

        public void InsertCustomerNoAddress(string myFirstName, string myLastName, int myPhoneNumber, string myEmail)
        {
            using (SqlConnection cn = new SqlConnection(_connectionString))
            {
                cn.Open();
                SqlCommand cmd = cn.CreateCommand();
                cmd.CommandText = File.ReadAllText(string.Concat(INSERT_DATA_FOLDER, "CustomerNoAddress", SQL_EXTENSION));
                cmd.CommandTimeout = 5;

                cmd.Parameters.AddWithValue("@FirstName", myFirstName);
                cmd.Parameters.AddWithValue("@LastName", myLastName);
                cmd.Parameters.AddWithValue("@PhoneNumber", myPhoneNumber);
                cmd.Parameters.AddWithValue("@EmailAddress", myEmail);
                cmd.ExecuteNonQuery();
            }
        }

        public void InsertAddress(string myStreetName, int myStreetNumber, int myZipCode, string myCity)
        {
            using (SqlConnection cn = new SqlConnection(_connectionString))
            {
                cn.Open();
                SqlCommand cmd = cn.CreateCommand();
                cmd.CommandText = File.ReadAllText(string.Concat(INSERT_DATA_FOLDER, ADDRESS, SQL_EXTENSION));
                cmd.CommandTimeout = 5;

                cmd.Parameters.AddWithValue("@StreetName", myStreetName);
                cmd.Parameters.AddWithValue("@StreetNumber", myStreetNumber);
                cmd.Parameters.AddWithValue("@ZipCode", myZipCode);
                cmd.Parameters.AddWithValue("@City", myCity);
                cmd.ExecuteNonQuery();
            }
        }

        public void InsertAccount(string myIban, int myBalance, int myCustomerID)
        {
            using (SqlConnection cn = new SqlConnection(_connectionString))
            {
                cn.Open();
                SqlCommand cmd = cn.CreateCommand();
                cmd.CommandText = File.ReadAllText(string.Concat(INSERT_DATA_FOLDER, ACCOUNT, SQL_EXTENSION));
                cmd.CommandTimeout = 5;

                cmd.Parameters.AddWithValue("@IBAN", myIban);
                cmd.Parameters.AddWithValue("@Balance", myBalance);
                cmd.Parameters.AddWithValue("@Customer_ID", myCustomerID);
                cmd.ExecuteNonQuery();
            }
        }

        public void InsertTransaction(DateTime myDate, int myAmount, string myIntendedUse, string myType, int myReceiverID, int mySenderID)
        {
            using (SqlConnection cn = new SqlConnection(_connectionString))
            {
                cn.Open();
                SqlCommand cmd = cn.CreateCommand();
                cmd.CommandText = File.ReadAllText(string.Concat(INSERT_DATA_FOLDER, TRANSACTION, SQL_EXTENSION));
                cmd.CommandTimeout = 5;

                cmd.Parameters.AddWithValue("@Date", myDate);
                cmd.Parameters.AddWithValue("@Amount", myAmount);
                cmd.Parameters.AddWithValue("@IntendedUse", myIntendedUse);
                cmd.Parameters.AddWithValue("@Type", myType);
                cmd.Parameters.AddWithValue("@AccountReceiver_ID", myReceiverID);
                cmd.Parameters.AddWithValue("@AccountSender_ID", mySenderID);
                cmd.ExecuteNonQuery();
            }
        }
        #endregion

        #region SQL Update Methods
        public void UpdateCustomer(string myFirstName, string myLastName, int myPhoneNumber, string myEmail, object myAddressID, int myCustomerID)
        {
            using (SqlConnection cn = new SqlConnection(_connectionString))
            {
                cn.Open();
                SqlCommand cmd = cn.CreateCommand();
                cmd.CommandText = File.ReadAllText(string.Concat(UPDATE_TABLE_FOLDER, CUSTOMER, SQL_EXTENSION));
                cmd.CommandTimeout = 5;

                cmd.Parameters.AddWithValue("@FirstName", myFirstName);
                cmd.Parameters.AddWithValue("@LastName", myLastName);
                cmd.Parameters.AddWithValue("@PhoneNumber", myPhoneNumber);
                cmd.Parameters.AddWithValue("@EmailAddress", myEmail);
                cmd.Parameters.AddWithValue("@AddressID", myAddressID);
                cmd.Parameters.AddWithValue("@ID", myCustomerID);
                cmd.ExecuteNonQuery();
            }
        }

        public void UpdateCustomerNoAddress(string myFirstName, string myLastName, int myPhoneNumber, string myEmail, int myCustomerID)
        {
            using (SqlConnection cn = new SqlConnection(_connectionString))
            {
                cn.Open();
                SqlCommand cmd = cn.CreateCommand();
                cmd.CommandText = File.ReadAllText(string.Concat(UPDATE_TABLE_FOLDER, "CustomerNoAddress", SQL_EXTENSION));
                cmd.CommandTimeout = 5;

                cmd.Parameters.AddWithValue("@FirstName", myFirstName);
                cmd.Parameters.AddWithValue("@LastName", myLastName);
                cmd.Parameters.AddWithValue("@PhoneNumber", myPhoneNumber);
                cmd.Parameters.AddWithValue("@EmailAddress", myEmail);
                cmd.Parameters.AddWithValue("@ID", myCustomerID);
                cmd.ExecuteNonQuery();
            }
        }

        void UpdateAccountBalance(int myNewBalance, int myAccountID)
        {
            using (SqlConnection cn = new SqlConnection(_connectionString))
            {
                cn.Open();
                SqlCommand cmd = cn.CreateCommand();
                cmd.CommandText = File.ReadAllText(string.Concat(UPDATE_TABLE_FOLDER, "AccountBalance", SQL_EXTENSION));
                cmd.CommandTimeout = 5;

                cmd.Parameters.AddWithValue("@Balance", myNewBalance);
                cmd.Parameters.AddWithValue("@ID", myAccountID);
                cmd.ExecuteNonQuery();
            }
        }

        public void UpdateAddress(string myStreetName, int myStreetNumber, int myZipCode, string myCity, int myID)
        {
            using (SqlConnection cn = new SqlConnection(_connectionString))
            {
                cn.Open();
                SqlCommand cmd = cn.CreateCommand();
                cmd.CommandText = File.ReadAllText(string.Concat(UPDATE_TABLE_FOLDER, ADDRESS, SQL_EXTENSION));
                cmd.CommandTimeout = 5;

                cmd.Parameters.AddWithValue("@StreetName", myStreetName);
                cmd.Parameters.AddWithValue("@StreetNumber", myStreetNumber);
                cmd.Parameters.AddWithValue("@ZipCode", myZipCode);
                cmd.Parameters.AddWithValue("@City", myCity);
                cmd.Parameters.AddWithValue("@ID", myID);
                cmd.ExecuteNonQuery();
            }
        }
        #endregion

        #region SQL Delete Methods
        void DeleteData(string myType, int myID)
        {
            using (SqlConnection cn = new SqlConnection(_connectionString))
            {
                cn.Open();
                SqlCommand cmd = cn.CreateCommand();
                cmd.CommandText = File.ReadAllText(string.Concat(DELETE_FOLDER, myType, SQL_EXTENSION));
                cmd.CommandTimeout = 5;

                cmd.Parameters.AddWithValue("@ID", myID);
                cmd.ExecuteNonQuery();
            }
        }

        public void DeleteCustomerWithID(int myCustomerID)
        {
            DeleteData(CUSTOMER, myCustomerID);
        }

        public void DeleteAccountWithID(int myAccountID)
        {
            DeleteData(ACCOUNT, myAccountID);
        }

        public void DeleteTransactionWithID(int myTransactionID)
        {
            DeleteData(TRANSACTION, myTransactionID);
        }

        public void DeleteAddressWithID(int myAddressID)
        {
            DeleteData(ADDRESS, myAddressID);
        }
        #endregion

        #region Get DataTable Methods
        DataTable GetDataTable(string myCommandText)
        {
            DataTable dt = new DataTable();
            try
            {
                using (SqlConnection cn = new SqlConnection(_connectionString))
                {
                    cn.Open();
                    SqlCommand cmd = cn.CreateCommand();

                    cmd.CommandTimeout = 5;
                    cmd.CommandText = myCommandText;

                    SqlDataReader reader = cmd.ExecuteReader();
                    dt.Load(reader);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "An Error ocurred");
            }
            return dt;
        }

        public DataTable GetOwnedAccountsByCustomerID(int myCustomerID)
        {
            string cmdText = File.ReadAllText(string.Concat(GET_DATA_FOLDER, "AllAssociatedAccounts", SQL_EXTENSION));
            return GetDataTable(string.Format(cmdText, myCustomerID));
        }

        public DataTable GetAllTransactionsFromAccountID(int myAccountID)
        {
            string cmdText = File.ReadAllText(string.Concat(GET_DATA_FOLDER, "AllAssociatedTransactions", SQL_EXTENSION));
            return GetDataTable(string.Format(cmdText, myAccountID));
        }

        public DataTable GetAllAddresses()
        {
            return GetDataTable(File.ReadAllText(string.Concat(GET_DATA_FOLDER, "AllAddresses", SQL_EXTENSION)));
        }

        public DataTable GetAllCustomers()
        {
            return GetDataTable(File.ReadAllText(string.Concat(GET_DATA_FOLDER, "AllCustomers", SQL_EXTENSION)));
        }

        public DataTable GetAllAccounts()
        {
            return GetDataTable(File.ReadAllText(string.Concat(GET_DATA_FOLDER, "AllAccounts", SQL_EXTENSION)));
        }

        public DataTable GetAllTransactions()
        {
            return GetDataTable(File.ReadAllText(string.Concat(GET_DATA_FOLDER, "AllTransactions", SQL_EXTENSION)));
        }

        public int GetLastAccountID()
        {
            DataTable dt = GetDataTable("SELECT TOP 1 ID FROM [dbo].[Account] ORDER BY ID DESC");
            return (int)dt.Rows[0].ItemArray[0];
        }
        #endregion

        #region Manage Account Balance Methods
        /// <summary>
        ///Will remove myAmount from balance of Account with ID myAccountID.
        /// </summary>
        /// <param name="myAccountID"></param>
        /// <param name="myAmount"></param>
        public void WithdrawFromAccount(int myAccountID, int myAmount)
        {
            string cmdText = File.ReadAllText(string.Concat(GET_DATA_FOLDER, "BalanceFromAccountID", SQL_EXTENSION));
            DataTable temp = GetDataTable(string.Format(cmdText, myAccountID));

            int currentBalance = Convert.ToInt32(temp.Rows[0].ItemArray[0]);
            int newBalance = currentBalance - myAmount;

            UpdateAccountBalance(newBalance, myAccountID);
        }

        /// <summary>
        ///Will add myAmount to balance of Account with ID myAccountID.
        /// </summary>
        /// <param name="myAccountID"></param>
        /// <param name="myAmount"></param>
        public void DepositToAccount(int myAccountID, int myAmount)
        {
            string cmdText = File.ReadAllText(string.Concat(GET_DATA_FOLDER, "BalanceFromAccountID", SQL_EXTENSION));
            DataTable temp = GetDataTable(string.Format(cmdText, myAccountID));

            int currentBalance = Convert.ToInt32(temp.Rows[0].ItemArray[0]);
            int newBalance = currentBalance + myAmount;

            UpdateAccountBalance(newBalance, myAccountID);
        }

        /// <summary>
        ///Will remove myAmount from balance of the sender and add it into the balance of the receiver Account.
        /// </summary>
        /// <param name="mySenderID"></param>
        /// <param name="myReceiverID"></param>
        /// <param name="myAmount"></param>
        public void TransferFromSenderToReceiver(int mySenderID, int myReceiverID, int myAmount)
        {
            WithdrawFromAccount(mySenderID, myAmount);
            DepositToAccount(myReceiverID, myAmount);
        }
        #endregion
    }
}