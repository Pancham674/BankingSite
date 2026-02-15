using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.IO;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace BankingSite
{
    public static class DatabaseInteraction
    {
		#region class variables
		static string _connectionString;
		static string _connectedDatabase;

        static string _sqlDir = GetSqlDir();
		static string _insertDataDir = _sqlDir + @"InsertData\";
		static string _createTableDir = _sqlDir + @"CreateTable\";
		static string _getDataDir = _sqlDir + @"GetData\";
		static string _updateTableDir = _sqlDir + @"UpdateTable\";
		static string _deleteDir = _sqlDir + @"DeleteData\";

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
        public static void CanConnectToServer(string myDb, string myServerName, string myUsername, string myPassword)
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
        public static string[] GetDatabases()
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

        public static List<string> GetMissingTables()
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

        public static bool IsConnectedToSysDb()
        {
            string[] systemDatabases = { "master", "tempdb", "model", "msdb" };
            return systemDatabases.Contains(_connectedDatabase);
        }

		/// <summary>
		/// Creates the required tables that are missing.
		/// </summary>
		public static void CreateTables(List<string> myMissingTables)
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
                        cmd.CommandText = File.ReadAllText(string.Concat(_createTableDir, ADDRESS, SQL_EXTENSION));
                        cmd.ExecuteNonQuery();
                        continue;
                    }

                    if (missingTable.Equals(CUSTOMER))
                    {
                        cmd.CommandText = File.ReadAllText(string.Concat(_createTableDir, CUSTOMER, SQL_EXTENSION));
                        cmd.ExecuteNonQuery();
                        continue;
                    }

                    if (missingTable.Equals(ACCOUNT))
                    {
                        cmd.CommandText = File.ReadAllText(string.Concat(_createTableDir, ACCOUNT, SQL_EXTENSION));
                        cmd.ExecuteNonQuery();
                        continue;
                    }

                    if (missingTable.Equals(TRANSACTION))
                    {
                        cmd.CommandText = File.ReadAllText(string.Concat(_createTableDir, TRANSACTION, SQL_EXTENSION));
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

		static void CreateTrigger()
        {
            using (SqlConnection cn = new SqlConnection(_connectionString))
            {
                cn.Open();
                SqlCommand cmd = cn.CreateCommand();
                cmd.CommandTimeout = 5;

                cmd.CommandText = File.ReadAllText(string.Concat(_createTableDir, "CustomerTrigger", SQL_EXTENSION));
                cmd.ExecuteNonQuery();

                cmd.CommandText = File.ReadAllText(string.Concat(_createTableDir, "AccountTrigger", SQL_EXTENSION));
                cmd.ExecuteNonQuery();
            }
        }

        /// <summary>
        /// Will get the SQL Directory, where all sql files reside. Neccessary for Testing since its in a different dir than this project.
        /// </summary>
        /// <returns></returns>
        static string GetSqlDir()
        {
            string sqlDir = string.Empty;
            string[] directories = Environment.CurrentDirectory.Split(Path.DirectorySeparatorChar);
			do  //Go down to the "BankingSite" subdirectory (take one away since we always start in the "\bin\Debug" path anyway)
			{
                directories = directories.Take(directories.Length - 1).ToArray();
            }
            while (!directories[directories.Length - 1].ToLower().Equals("bankingsiteproject"));

			//once the subdir is found, add all the directories back to the path
			foreach (string dir in directories)
            {
                sqlDir = string.Concat(sqlDir, dir, @"\");
            }

            sqlDir = string.Concat(sqlDir, @"BankingSite\SQL\");

            if (!Directory.Exists(sqlDir))
            {
                throw new DirectoryNotFoundException(string.Concat("The path \"", @"\BankingSite\SQL\", "\" couldn't be found in \"", sqlDir,
                                "\". If it has been moved then please move it back to its original location and restart the application."));
            }
			return sqlDir;
        }
		#endregion

		#region SQL Insert Methods
		public static void InsertToAllTables()
        {
            using (SqlConnection cn = new SqlConnection(_connectionString))
            {
                cn.Open();
                SqlCommand cmd = cn.CreateCommand();
                cmd.CommandTimeout = 5;

                cmd.CommandText = File.ReadAllText(string.Concat(_insertDataDir, "DefaultAddresses", SQL_EXTENSION));
                cmd.ExecuteNonQuery();

                cmd.CommandText = File.ReadAllText(string.Concat(_insertDataDir, "DefaultCustomers", SQL_EXTENSION));
                cmd.ExecuteNonQuery();

                cmd.CommandText = File.ReadAllText(string.Concat(_insertDataDir, "DefaultAccounts", SQL_EXTENSION));
                cmd.ExecuteNonQuery();

                cmd.CommandText = File.ReadAllText(string.Concat(_insertDataDir, "DefaultTransactions", SQL_EXTENSION));
                cmd.ExecuteNonQuery();
            }
        }

        public static void InsertCustomer(string myFirstName, string myLastName, int myPhoneNumber, string myEmail, int myAddressID)
        {
            using (SqlConnection cn = new SqlConnection(_connectionString))
            {
                cn.Open();
                SqlCommand cmd = cn.CreateCommand();
                cmd.CommandText = File.ReadAllText(string.Concat(_insertDataDir, CUSTOMER, SQL_EXTENSION));
                cmd.CommandTimeout = 5;

                cmd.Parameters.AddWithValue("@FirstName", myFirstName);
                cmd.Parameters.AddWithValue("@LastName", myLastName);
                cmd.Parameters.AddWithValue("@PhoneNumber", myPhoneNumber);
                cmd.Parameters.AddWithValue("@EmailAddress", myEmail);
                cmd.Parameters.AddWithValue("@Address_ID", myAddressID);
                cmd.ExecuteNonQuery();
            }
        }

        public static void InsertCustomerNoAddress(string myFirstName, string myLastName, int myPhoneNumber, string myEmail)
        {
            using (SqlConnection cn = new SqlConnection(_connectionString))
            {
                cn.Open();
                SqlCommand cmd = cn.CreateCommand();
                cmd.CommandText = File.ReadAllText(string.Concat(_insertDataDir, "CustomerNoAddress", SQL_EXTENSION));
                cmd.CommandTimeout = 5;

                cmd.Parameters.AddWithValue("@FirstName", myFirstName);
                cmd.Parameters.AddWithValue("@LastName", myLastName);
                cmd.Parameters.AddWithValue("@PhoneNumber", myPhoneNumber);
                cmd.Parameters.AddWithValue("@EmailAddress", myEmail);
                cmd.ExecuteNonQuery();
            }
        }

        public static void InsertAddress(string myStreetName, int myStreetNumber, int myZipCode, string myCity)
        {
            using (SqlConnection cn = new SqlConnection(_connectionString))
            {
                cn.Open();
                SqlCommand cmd = cn.CreateCommand();
                cmd.CommandText = File.ReadAllText(string.Concat(_insertDataDir, ADDRESS, SQL_EXTENSION));
                cmd.CommandTimeout = 5;

                cmd.Parameters.AddWithValue("@StreetName", myStreetName);
                cmd.Parameters.AddWithValue("@StreetNumber", myStreetNumber);
                cmd.Parameters.AddWithValue("@ZipCode", myZipCode);
                cmd.Parameters.AddWithValue("@City", myCity);
                cmd.ExecuteNonQuery();
            }
        }

        public static void InsertAccount(int myBalance, int myCustomerID, string myHashCode, string myCountryCode)
        {
            using (SqlConnection cn = new SqlConnection(_connectionString))
            {   //Insert the new account first, then update its IBAN so it has the correct account id in it
                cn.Open();
                SqlCommand cmd = cn.CreateCommand();
                cmd.CommandText = File.ReadAllText(string.Concat(_insertDataDir, ACCOUNT, SQL_EXTENSION));
                cmd.CommandTimeout = 5;

                cmd.Parameters.AddWithValue("@IBAN", "Empty");
                cmd.Parameters.AddWithValue("@Balance", myBalance);
                cmd.Parameters.AddWithValue("@Customer_ID", myCustomerID);
                cmd.ExecuteNonQuery();

                int id = GetLastAccountID();
				string iban = myCountryCode + myCustomerID + id + myHashCode;
                cmd.CommandText = File.ReadAllText(String.Concat(_updateTableDir, ACCOUNT, "Iban", SQL_EXTENSION));

                cmd.Parameters["@IBAN"].Value = iban;
                cmd.Parameters.AddWithValue("@ID", id);
                cmd.ExecuteNonQuery();
			}
		}

        public static void InsertTransaction(DateTime myDate, int myAmount, string myIntendedUse, string myType, int myReceiverID, int mySenderID)
        {
            using (SqlConnection cn = new SqlConnection(_connectionString))
            {
                cn.Open();
                SqlCommand cmd = cn.CreateCommand();
                cmd.CommandText = File.ReadAllText(string.Concat(_insertDataDir, TRANSACTION, SQL_EXTENSION));
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
        public static void UpdateCustomer(string myFirstName, string myLastName, int myPhoneNumber, string myEmail, object myAddressID, int myCustomerID)
        {
            using (SqlConnection cn = new SqlConnection(_connectionString))
            {
                cn.Open();
                SqlCommand cmd = cn.CreateCommand();
                cmd.CommandText = File.ReadAllText(string.Concat(_updateTableDir, CUSTOMER, SQL_EXTENSION));
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

        public static void UpdateCustomerNoAddress(string myFirstName, string myLastName, int myPhoneNumber, string myEmail, int myCustomerID)
        {
            using (SqlConnection cn = new SqlConnection(_connectionString))
            {
                cn.Open();
                SqlCommand cmd = cn.CreateCommand();
                cmd.CommandText = File.ReadAllText(string.Concat(_updateTableDir, "CustomerNoAddress", SQL_EXTENSION));
                cmd.CommandTimeout = 5;

                cmd.Parameters.AddWithValue("@FirstName", myFirstName);
                cmd.Parameters.AddWithValue("@LastName", myLastName);
                cmd.Parameters.AddWithValue("@PhoneNumber", myPhoneNumber);
                cmd.Parameters.AddWithValue("@EmailAddress", myEmail);
                cmd.Parameters.AddWithValue("@ID", myCustomerID);
                cmd.ExecuteNonQuery();
            }
        }

        static void UpdateAccountBalance(int myNewBalance, int myAccountID)
        {
            using (SqlConnection cn = new SqlConnection(_connectionString))
            {
                cn.Open();
                SqlCommand cmd = cn.CreateCommand();
                cmd.CommandText = File.ReadAllText(string.Concat(_updateTableDir, "AccountBalance", SQL_EXTENSION));
                cmd.CommandTimeout = 5;

                cmd.Parameters.AddWithValue("@Balance", myNewBalance);
                cmd.Parameters.AddWithValue("@ID", myAccountID);
                cmd.ExecuteNonQuery();
            }
        }

        public static void UpdateAddress(string myStreetName, int myStreetNumber, int myZipCode, string myCity, int myID)
        {
            using (SqlConnection cn = new SqlConnection(_connectionString))
            {
                cn.Open();
                SqlCommand cmd = cn.CreateCommand();
                cmd.CommandText = File.ReadAllText(string.Concat(_updateTableDir, ADDRESS, SQL_EXTENSION));
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
        public static void DeleteAllDataFromAllTables()
        {
            using (SqlConnection cn = new SqlConnection(_connectionString))
            {
                cn.Open();
                SqlCommand cmd = cn.CreateCommand();
                cmd.CommandText = File.ReadAllText(string.Concat(_deleteDir, "AllData", SQL_EXTENSION));
                
                cmd.CommandTimeout = 5;
                cmd.ExecuteNonQuery();
			}
		}

		static void DeleteData(string myType, int myID)
        {
            using (SqlConnection cn = new SqlConnection(_connectionString))
            {
                cn.Open();
                SqlCommand cmd = cn.CreateCommand();
                cmd.CommandText = File.ReadAllText(string.Concat(_deleteDir, myType, SQL_EXTENSION));
                cmd.CommandTimeout = 5;

                cmd.Parameters.AddWithValue("@ID", myID);
                cmd.ExecuteNonQuery();
            }
        }

        public static void DeleteCustomerWithID(int myCustomerID)
        {
            DeleteData(CUSTOMER, myCustomerID);
        }

        public static void DeleteAccountWithID(int myAccountID)
        {
            DeleteData(ACCOUNT, myAccountID);
        }

        public static void DeleteTransactionWithID(int myTransactionID)
        {
            DeleteData(TRANSACTION, myTransactionID);
        }

        public static void DeleteAddressWithID(int myAddressID)
        {
            DeleteData(ADDRESS, myAddressID);
        }
        #endregion

        #region Get DataTable Methods
        static DataTable GetDataTable(string myCommandText)
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

        public static DataTable GetOwnedAccountsByCustomerID(int myCustomerID)
        {
            string cmdText = File.ReadAllText(string.Concat(_getDataDir, "AllAssociatedAccounts", SQL_EXTENSION));
            return GetDataTable(string.Format(cmdText, myCustomerID));
        }

        public static DataTable GetAllTransactionsFromAccountID(int myAccountID)
        {
            string cmdText = File.ReadAllText(string.Concat(_getDataDir, "AllAssociatedTransactions", SQL_EXTENSION));
            return GetDataTable(string.Format(cmdText, myAccountID));
        }

        public static DataTable GetAllAddresses()
        {
            return GetDataTable(File.ReadAllText(string.Concat(_getDataDir, "AllAddresses", SQL_EXTENSION)));
        }

        public static DataTable GetAllCustomers()
        {
            return GetDataTable(File.ReadAllText(string.Concat(_getDataDir, "AllCustomers", SQL_EXTENSION)));
        }

        public static DataTable GetAllAccounts()
        {
            return GetDataTable(File.ReadAllText(string.Concat(_getDataDir, "AllAccounts", SQL_EXTENSION)));
        }

        public static DataTable GetAllTransactions()
        {
            return GetDataTable(File.ReadAllText(string.Concat(_getDataDir, "AllTransactions", SQL_EXTENSION)));
        }

        public static int GetLastAccountID()
        {
            DataTable dt = GetDataTable("SELECT IDENT_CURRENT('Account')");
            int lastId = dt.Rows.Count == 0 ? 0 : Convert.ToInt32(dt.Rows[0].ItemArray[0]);
            return lastId;
        }
        #endregion

        #region Manage Account Balance Methods
        /// <summary>
        ///Will remove myAmount from balance of Account with ID myAccountID.
        /// </summary>
        /// <param name="myAccountID"></param>
        /// <param name="myAmount"></param>
        public static void WithdrawFromAccount(int myAccountID, int myAmount)
        {
            string cmdText = File.ReadAllText(string.Concat(_getDataDir, "BalanceFromAccountID", SQL_EXTENSION));
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
        public static void DepositToAccount(int myAccountID, int myAmount)
        {
            string cmdText = File.ReadAllText(string.Concat(_getDataDir, "BalanceFromAccountID", SQL_EXTENSION));
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
        public static void TransferFromSenderToReceiver(int mySenderID, int myReceiverID, int myAmount)
        {
            WithdrawFromAccount(mySenderID, myAmount);
            DepositToAccount(myReceiverID, myAmount);
        }
        #endregion

        public static string ConnectedDatabase { get => _connectedDatabase; }
	}
}