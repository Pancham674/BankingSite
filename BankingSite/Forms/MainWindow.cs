using System;
using System.Collections.Generic;
using System.Data;
using System.IO;
using System.Text.RegularExpressions;
using System.Windows.Forms;

namespace BankingSite
{
    public partial class MainWindow : Form
    {
        List<string> _missingTables;
        bool _isConnectedAndHasTables;

        DataTable _addressTable;
        DataTable _customerTable;
        DataTable _accountTable;
        DataTable _transactionTable;

        #region Server Connection
        public MainWindow()
        {
            InitializeComponent();
        }

        private void Window_Load(object sender, EventArgs e)
        {
            txtbServerName.Text = string.Concat(Environment.MachineName, @"\");
        }

        /// <summary>
        /// Will cancel changong the tab if we're not connected and have all required tables.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void tcWindow_Selecting(object sender, TabControlCancelEventArgs e)
        {
            if (!_isConnectedAndHasTables)
            {
                e.Cancel = true;
                return;
            }

            DrawingControl.SuspendDrawing(tcWindow);

            if (tcWindow.SelectedTab == tpCustomers)
            {
                StopDrawingOfCustomerAddress();
            }
            else if (tcWindow.SelectedTab == tpTransactions)
            {
                StopDrawingOfTransaction();
            }
            else if (tcWindow.SelectedTab == tpAccounts)
            {
                StopDrawingOfAccount();
            }
        }

        void StopDrawingOfCustomerAddress()
        {
            DrawingControl.SuspendDrawing(pnlCustomerDetails);
            DrawingControl.SuspendDrawing(dgvCustomers);

            DrawingControl.SuspendDrawing(pnlAddressTableAdapter);
            DrawingControl.SuspendDrawing(dgvAddresses);
        }

        void StopDrawingOfTransaction()
        {
            DrawingControl.SuspendDrawing(pnlTransactionDetails);
            DrawingControl.SuspendDrawing(dgvTransactions);
        }

        void StopDrawingOfAccount()
        {
            DrawingControl.SuspendDrawing(pnlAccountDetails);
            DrawingControl.SuspendDrawing(dgvAccounts);
        }

        private void tcWindow_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (tcWindow.SelectedTab == tpCustomers)
            {
                ResumeDrawingOfCustomerAddress();
            }
            else if (tcWindow.SelectedTab == tpTransactions)
            {
                ResumeDrawingOfTransaction();
            }
            else if (tcWindow.SelectedTab == tpAccounts)
            {
                ResumeDrawingOfAccount();
            }

            DrawingControl.ResumeDrawing(tcWindow);
        }

        void ResumeDrawingOfCustomerAddress()
        {
            DrawingControl.ResumeDrawing(pnlCustomerDetails);
            DrawingControl.ResumeDrawing(dgvCustomers);

            DrawingControl.ResumeDrawing(pnlAddressTableAdapter);
            DrawingControl.ResumeDrawing(dgvAddresses);
        }

        void ResumeDrawingOfTransaction()
        {
            DrawingControl.ResumeDrawing(pnlTransactionDetails);
            DrawingControl.ResumeDrawing(dgvTransactions);
        }

        void ResumeDrawingOfAccount()
        {
            DrawingControl.ResumeDrawing(pnlAccountDetails);
            DrawingControl.ResumeDrawing(dgvAccounts);
        }

        /// <summary>
        /// Will try to connect with the server in order to display all available databases in the dropdown
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void cbDbNames_DropDown(object sender, EventArgs e)
        {
            LoadTables();
        }

        /// <summary>
        /// Will connect to the server and db in order to display all tables (except the system dbs) in the comboBox for selection.
        /// </summary>
        void LoadTables()
        {
            try
            {
                if (!CanConnectToServer())
                {
                    return;
                }

                cbDbNames.Items.Clear();
                string[] databaseNames = DatabaseInteraction.GetDatabases();
                cbDbNames.Items.AddRange(databaseNames);
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "An Error ocurred");
            }
        }

        /// <summary>
        /// Will insert new data into the address, customer and account tables
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnInsertData_Click(object sender, EventArgs e)
        {
            InsertDataToTables();
        }

        void InsertDataToTables()
        {
            if (!CanConnectToServer())
            {
                return;
            }

            if (_missingTables.Count != 0)
            {
                if (DialogResult.Yes == MessageBox.Show("In order to insert data the database needs to contain all required tables: customer, address, account and transaction." +
                        "\n\nDo you want to create these tables?", "Tables missing", MessageBoxButtons.YesNo))
                {
                    CreateTables();
                    MessageBox.Show("Missing tables have been succssessfully created!", "Required tables created.");
                }
                else
                {
                    return;
                }
            }

            try
            {
                DatabaseInteraction.InsertToAllTables();

                RefillDGVs();
                _isConnectedAndHasTables = true;
                MessageBox.Show("Data has succsessfully been inserted into all tables!", "Data succsessfully inserted");
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "An Error ocurred");
            }
        }

        private void btnConnectToDB_Click(object sender, EventArgs e)
        {
            try
            {
                if (!CanConnectToServer())
                {
                    return;
                }
                    
                if (DatabaseInteraction.IsConnectedToSysDb())
                {
                    btnInsertData.Enabled = false;
                    _isConnectedAndHasTables = false;
                    Text = string.Concat("BankingSite - Connected to System Db");

                    MessageBox.Show("The currently connected database is one of the system databases. Please create a new database and connect to it.", "Connected to System Db");
                    return;
                }
               
                if (!DatabaseContainsAllTables())
                {
                    ConnectedToDatabase();

                    if (DialogResult.Yes == MessageBox.Show("The selected database does not contain the required tables customer, address, account and transaction." +
                                "\nDo you want to create these tables?", "Tables missing", MessageBoxButtons.YesNo))
                    {
                        CreateTables();
                        MessageBox.Show("Missing tables have been succssessfully created, so all of them are empty.", "Empty tables created.");
                    }
                    else
                    {
                        _isConnectedAndHasTables = false;
                    }
                    return;
                }
                else
                {
                    RefillDGVs();
                    ConnectedToDatabase();
                    MessageBox.Show("Succsessfully connected to database!", "Connection to database established.");
                }
            }
			catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "An Error ocurred");
            }
        }

        bool CanConnectToServer()
        {
            try
            {
                if (String.IsNullOrWhiteSpace(txtbServerName.Text) || String.IsNullOrWhiteSpace(txtbUsername.Text) || String.IsNullOrWhiteSpace(txtbPassword.Text))
                {
                    throw new Exception("Please provide a Server name, Username and Password before attemping to connect.");
                }

                DatabaseInteraction.ConnectToServer(String.IsNullOrWhiteSpace(cbDbNames.Text) ? "master" : cbDbNames.Text, txtbServerName.Text, txtbUsername.Text, txtbPassword.Text);
                return true;
            }
			catch (TypeInitializationException dirEx)
			{
				MessageBox.Show(dirEx.InnerException.Message, "Error while trying to connect");
			}
			catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Error while trying to connect");
            }
            return false;
		}

		/// <summary>
		/// Refreshes all DataTables, DataGridViews and Controls associated with them.
		/// </summary>
		void RefillDGVs()
        {
            RefreshAddressDataBindingsSources();
            RefreshCustomerDataBingingsSources();
            RefreshAccountDataBindingsSources();
            RefreshTransactionDataBindingsSources();
        }

        /// <summary>
        /// Will re-set the DataBinding for myUiElement.
        /// </summary>
        /// <param name="myUiElement"></param>
        /// <param name="myDataSource"></param>
        /// <param name="myDataMember"></param>
        void SetDataBindings(Control myUiElement, DataTable myDataSource, string myDataMember)
        {
            myUiElement.DataBindings.Clear();
            myUiElement.DataBindings.Add("Text", myDataSource, myDataMember, false, DataSourceUpdateMode.Never);

            if (myDataSource.Rows.Count == 0)
            {
                myUiElement.Text = string.Empty;
            }
        }

        /// <summary>
        /// Will check if the selected Database contains all requered tables such as: Address, Customer, Account and Transaction.
        /// Will return false if one of them doesn't exist.
        /// </summary>
        /// <returns></returns>
        bool DatabaseContainsAllTables()
        {
            _missingTables = DatabaseInteraction.GetMissingTables();
            return _missingTables.Count == 0;
        }

        /// <summary>
        /// Creates the required tables that are missing.
        /// </summary>
        void CreateTables()
        {
            DatabaseInteraction.CreateTables(_missingTables);
            _missingTables.Clear();
            RefillDGVs();
        }

        /// <summary>
        /// Will change the text of the window and allow changing the tab pages and inserting data
        /// </summary>
        void ConnectedToDatabase()
        {
            btnInsertData.Enabled = true;
            btnDeleteAllData.Enabled = true;
			_isConnectedAndHasTables = true;
            Text = string.Concat("BankingSite - Connected to ", cbDbNames.Text);
        }

		void btnDeleteAllData_Click(object sender, EventArgs e)
		{
            if (_addressTable.Rows.Count == 0 && _customerTable.Rows.Count == 0 && _accountTable.Rows.Count == 0 && _transactionTable.Rows.Count == 0)
            { 
                MessageBox.Show("There is no data to delete.", "No data to delete");
                return;
			}

			if (MessageBox.Show("Are you sure that you want to delete ALL data from all tables?", "Delete all data", MessageBoxButtons.YesNo) == DialogResult.No)
            {
                return;
			}

            try
            {
                DatabaseInteraction.DeleteAllDataFromAllTables();
		    	MessageBox.Show("Every data has been deleted.", "Data deleted");
			}
			catch (Exception ex)
			{
				MessageBox.Show(string.Concat(ex.Message, "\nSome data may have been deleted."), "An Error occured");
			}

			RefillDGVs();
		}
		#endregion

		#region Customer Tab
		private void btnCreateNewCustomer_Click(object sender, EventArgs e)
        {
            CreateNew cnForm = new CreateNew(CreateNew.CreateType.Customer);
            if (cnForm.ShowDialog() == DialogResult.Cancel)
            {
                return;
            }
            RefreshCustomerDataBingingsSources();
        }

        void btnUpdateCustomer_Click(object sender, EventArgs e)
        {   //the ID gets set when dgv is selected and is read only, meaning that there are no rows if we come here
            if (!int.TryParse(customerIDTextBox.Text, out int custID))
            {
                return;
            }
            //Update the dataTable but check if all of them are valid first
            if (!int.TryParse(phoneNumberTextBox.Text, out int phoneN))
            {
                MessageBox.Show("Please make sure to only input numbers for the phone number.", "Error using inputs for updating customer");
                return;
            }

            string firstN = firstNameTextBox.Text;
            string lastN = lastNameTextBox.Text;
            string email = emailAddressTextBox.Text;

            Regex emailStructure = new Regex(@"^.+(?:[\x21-\x7E].+)*@.+(?:\..+)*$");
            if (int.TryParse(firstN, out int a) || int.TryParse(lastN, out int b) || int.TryParse(email, out int c) || !emailStructure.IsMatch(email))
            {
                MessageBox.Show("Please make sure to only input strings for both names and the email. The email must follow the valid email structure.", "Error using inputs for updating customer");
                return;
            }

            try
            {
                //address to update may be set to null
                if (String.IsNullOrWhiteSpace(customerAddressIDComboBox.Text))
                {
                    DatabaseInteraction.UpdateCustomerNoAddress(firstN, lastN, phoneN, email, custID);
                }
                else
                {
                    int addrID = Convert.ToInt32(customerAddressIDComboBox.Text);
                    DatabaseInteraction.UpdateCustomer(firstN, lastN, phoneN, email, addrID, custID);
                }
                RefreshCustomerDataBingingsSources();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Error oocurred while updating a customer.");
            }
        }

        private void btnDeleteCustomer_Click(object sender, EventArgs e)
        {   //the ID gets set when dgv is selected and is read only, meaning that there are no rows if we come here
            if (!int.TryParse(customerIDTextBox.Text, out int id))
            {
                return;
            }

            if (MessageBox.Show(string.Concat("Are you sure you want to delete the customer with the ID: ", id, "?" +
                "\nThis will also delete all accounts they own."), "Delete selected customer",
                        MessageBoxButtons.YesNo, MessageBoxIcon.Warning) == DialogResult.Yes)
            {
                DatabaseInteraction.DeleteCustomerWithID(id);
                RefreshCustomerDataBingingsSources();
                RefreshAccountDataBindingsSources();
                RefreshTransactionDataBindingsSources();
            }
        }

        /// <summary>
        /// Creates a Window to display all Accounts the selecetd Customer owns.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnShowOwnedAccounts_Click(object sender, EventArgs e)
        {   //the ID gets set when dgv is selected and is read only, meaning that there are no rows if we come here
            if (!int.TryParse(customerIDTextBox.Text, out int custID))
            {
                return;
            }

            DataTable accounts = DatabaseInteraction.GetOwnedAccountsByCustomerID(custID);

            if (accounts.Rows.Count == 0)
            {
                MessageBox.Show("The selected customer has no accounts.", "Customer has no accounts.");
                return;
            }

            AssociatedDataTables owned = new AssociatedDataTables(accounts);
            owned.Text = string.Concat("Owned Accounts From Customer with ID ", custID);
            owned.Show(this);
        }

        /// <summary>
        /// Refreshes the customerTable, its dataGridViev DataSource and all Controls associated with it.
        /// </summary>
        void RefreshCustomerDataBingingsSources()
        {
            StopDrawingOfCustomerAddress();
            _customerTable = DatabaseInteraction.GetAllCustomers();
            dgvCustomers.DataSource = _customerTable;

            SetDataBindings(customerIDTextBox, _customerTable, "ID");
            SetDataBindings(firstNameTextBox, _customerTable, "FirstName");
            SetDataBindings(lastNameTextBox, _customerTable, "LastName");
            SetDataBindings(phoneNumberTextBox, _customerTable, "PhoneNumber");
            SetDataBindings(emailAddressTextBox, _customerTable, "EmailAddress");
            RefreshCustomerAddressDropDown();
            ResumeDrawingOfCustomerAddress();
        }

        /// <summary>
        /// Will add every available address ID to the dropdown
        /// </summary>
        void RefreshCustomerAddressDropDown()
        {
            DataTable addressIDsCopy = _addressTable.Copy();
            foreach (DataColumn dc in addressIDsCopy.Columns)
            {
                dc.AllowDBNull = true;
                dc.AutoIncrement = false;
            }

            addressIDsCopy.Rows.Add();
            customerAddressIDComboBox.DataSource = addressIDsCopy;
            customerAddressIDComboBox.DisplayMember = "ID";

            //to make sure that the correct address id is being shown
            dgvCustomers_SelectionChanged(new object(), new EventArgs());
        }

        /// <summary>
        /// Makes sure that the correct Address ID is selected for the current customer
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void dgvCustomers_SelectionChanged(object sender, EventArgs e)
        {
            if (dgvCustomers.SelectedCells.Count != 6)
            {
                return;
            }
            DataGridViewCell currentCell = dgvCustomers.SelectedCells[5];
            string val = currentCell.Value.ToString();
            customerAddressIDComboBox.Text = val;
        }
        #endregion

        #region Address Tab
        private void btnCreateNewAddress_Click(object sender, EventArgs e)
        {
            CreateNew cnForm = new CreateNew(CreateNew.CreateType.Address);

            if (cnForm.ShowDialog() == DialogResult.Cancel)
            {
                return;
            }

            RefreshAddressDataBindingsSources();
            RefreshCustomerAddressDropDown();
        }

        void btnUpdateAddress_Click(object sender, EventArgs e)
        {   //the ID gets set when dgv is selected and is read only, meaning that there are no rows if we come here
            if (!int.TryParse(addressIDTextBox.Text, out int addrID))
            {
                return;
            }

            //Update the dataTable but check if all of them are valid first
            if (!int.TryParse(streetNumberTextBox.Text, out int streetNumber) || !int.TryParse(zipCodeTextBox.Text, out int zipCode))
            {
                MessageBox.Show("Please make sure to only input numbers for the street number and zip code.", "Error using inputs for updating address");
                return;
            }

            string streetName = streetNameTextBox.Text;
            string city = cityTextBox.Text;

            if (int.TryParse(streetName, out int a) || int.TryParse(city, out int b))
            {
                MessageBox.Show("Please make sure to only input strings for the street name and city.", "Error using inputs for updating address");
                return;
            }

            try
            {
                DatabaseInteraction.UpdateAddress(streetName, streetNumber, zipCode, city, addrID);
                RefreshAddressDataBindingsSources();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Error occured while updating an address.");
            }
        }

        private void btnDeleteAddress_Click(object sender, EventArgs e)
        {   //the ID gets set when dgv is selected and is read only, meaning that there are no rows if we come here
            if (!int.TryParse(addressIDTextBox.Text, out int id))
            {
                return;
            }

            if (MessageBox.Show(string.Concat("Are you sure you want to delete the address with the ID: ", id, "?" +
                "\nCustomers living at this place will become homeless."), "Delete selected address",
                MessageBoxButtons.YesNo, MessageBoxIcon.Warning) == DialogResult.Yes)
            {
                DatabaseInteraction.DeleteAddressWithID(id);
                RefreshAddressDataBindingsSources();
                RefreshCustomerDataBingingsSources();
            }
        }

        /// <summary>
        /// Refreshes the addressTable, its dataGridViev DataSource and all Controls associated with it.
        /// </summary>
        void RefreshAddressDataBindingsSources()
        {
            StopDrawingOfCustomerAddress();
            _addressTable = DatabaseInteraction.GetAllAddresses();
            dgvAddresses.DataSource = _addressTable;

            //address ui controls
            SetDataBindings(addressIDTextBox, _addressTable, "ID");
            SetDataBindings(streetNameTextBox, _addressTable, "StreetName");
            SetDataBindings(streetNumberTextBox, _addressTable, "StreetNumber");
            SetDataBindings(zipCodeTextBox, _addressTable, "ZipCode");
            SetDataBindings(cityTextBox, _addressTable, "City");
            ResumeDrawingOfCustomerAddress();
        }
        #endregion

        #region Account Tab
        private void btnCreateNewAccount_Click(object sender, EventArgs e)
        {
            if (_customerTable.Rows.Count == 0)
            {
                MessageBox.Show("Can't create an account without any customers. Please create a customer then try again.", "No Customers available");
                return;
            }

            CreateNew cnForm = new CreateNew(CreateNew.CreateType.Account);
            if (cnForm.ShowDialog() == DialogResult.Cancel)
            {
                return;
            }

            RefreshAccountDataBindingsSources();
        }

        /// <summary>
        /// Will open a window to show all transactions the account is assotiated with.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnShowTransactions_Click(object sender, EventArgs e)
        {   //the ID gets set when dgv is selected and is read only, meaning that there are no rows if we come here
            if (!int.TryParse(accountIDTextBox.Text, out int accID))
            {
                return;
            }

            DataTable transactions = DatabaseInteraction.GetAllTransactionsFromAccountID(accID);
            if (transactions.Rows.Count == 0)
            {
                MessageBox.Show("The selected account is not associated with any transactions.", "Account has no transactions.");
                return;
            }

            AssociatedDataTables owned = new AssociatedDataTables(transactions);
            owned.Text = string.Concat("Transactions Associated with Account ID ", accID);
            owned.Show(this);
        }

        private void btnDeleteSelectedAccount_Click(object sender, EventArgs e)
        {   //the ID gets set when dgv is selected and is read only, meaning that there are no rows if we come here
            if (!int.TryParse(accountIDTextBox.Text, out int accID))
            {
                return;
            }

            if (MessageBox.Show(string.Concat("Are you sure you want to delete the account with the ID: ", accID, "?" +
                "\n this will also delete transactions associated with this account."), "Delete selected account",
                MessageBoxButtons.YesNo, MessageBoxIcon.Warning) == DialogResult.Yes)
            {
                DatabaseInteraction.DeleteAccountWithID(accID);
                RefreshAccountDataBindingsSources();
                RefreshTransactionDataBindingsSources();
            }
        }

        /// <summary>
        /// Refreshes the accountTable, its dataGridViev DataSource and all Controls associated with it.
        /// </summary>
        void RefreshAccountDataBindingsSources()
        {
            StopDrawingOfAccount();
            _accountTable = DatabaseInteraction.GetAllAccounts();
            dgvAccounts.DataSource = _accountTable;
            SetDataBindings(accountIDTextBox, _accountTable, "ID");
            ResumeDrawingOfAccount();
        }
        #endregion

        #region Transaction Tab
        private void btnCreateNewTransaction_Click(object sender, EventArgs e)
        {
            if (_accountTable.Rows.Count == 0)
            {
                MessageBox.Show("Can't create a transaction without any accounts. Please create an account then try again.", "No Accounts available");
                return;
            }

            CreateNew cnForm = new CreateNew(CreateNew.CreateType.Transaction);
            if (cnForm.ShowDialog() == DialogResult.Cancel)
            {
                return;
            }
            RefreshTransactionDataBindingsSources();
            RefreshAccountDataBindingsSources();
        }

        private void btnDeleteTransaction_Click(object sender, EventArgs e)
        {   //the ID gets set when dgv is selected and is read only, meaning that there are no rows if we come here
            if (!int.TryParse(transactionIDTextBox.Text, out int id))
            {
                return;
            }

            if (MessageBox.Show(string.Concat("Are you sure you want to delete the transaction with the ID: ", transactionIDTextBox.Text, "?"), "Delete selected Transaction",
                MessageBoxButtons.YesNo, MessageBoxIcon.Warning) == DialogResult.Yes)
            {
                DatabaseInteraction.DeleteTransactionWithID(id);
                RefreshTransactionDataBindingsSources();
            }
        }

        /// <summary>
        /// Refreshes the transactionTable, its dataGridViev DataSource and all Controls associated with it.
        /// </summary>
        void RefreshTransactionDataBindingsSources()
        {
            StopDrawingOfTransaction();
            _transactionTable = DatabaseInteraction.GetAllTransactions();
            dgvTransactions.DataSource = _transactionTable;
            SetDataBindings(transactionIDTextBox, _transactionTable, "ID");
            ResumeDrawingOfTransaction();
        }
		#endregion		
	}
}