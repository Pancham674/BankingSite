using System;
using System.Data;
using System.Drawing;
using System.Text.RegularExpressions;
using System.Windows.Forms;

namespace BankingSite
{
    public partial class CreateNew : Form
    {
        bool _hasCanceled = true;
        CreateType _type;

        /// <summary>
        /// Will determine which panel (that holds all neccesary UI) to use by its parameters
        /// </summary>
        /// <param name="myCreateType"></param>
        public CreateNew(CreateType myCreateType)
        {
            InitializeComponent();

            _type = myCreateType;
            string title = "Create New ";

            switch (_type)
            {
                case CreateType.Customer:
                    UsePanel(pnlCustomer);
                    GetAddressIDs();
                    title += "Customer";
                    break;

                case CreateType.Address:
                    UsePanel(pnlAddress);
                    title += "Address";
                    break;

                case CreateType.Account:
                    UsePanel(pnlAccount);
                    GetCustomerIDs();
                    title += "Account";
                    break;

                case CreateType.Transaction:
                    UsePanel(pnlTransaction);
                    title += "Transaction";

                    dateDateTimePicker.MaxDate = DateTime.Now.Date;
                    dateDateTimePicker.Value = dateDateTimePicker.MaxDate;

                    DataTable table = new DataTable();
                    table.Columns.Add("Type");

                    table.Rows.Add(TransactionType.Withdrawal.ToString());
                    table.Rows.Add(TransactionType.Deposit.ToString());
                    table.Rows.Add(TransactionType.Transfer.ToString());

                    typeComboBox.DataSource = table;
                    typeComboBox.DisplayMember = "Type";

                    GetAccountIDs();
                    accountReceiver_IDComboBox.Enabled = false;
                    break;
            }

            Text = title;
        }

        void UsePanel(Panel myPanel)
        {
            myPanel.Visible = true;
            Size = new Size(myPanel.Size.Width + 17, myPanel.Size.Height + 37);
            myPanel.Location = new Point(0, 0);
        }


        /// <summary>
        /// Gets all address ids for its dropdown control.
        /// </summary>
        void GetAddressIDs()
        {
            DataTable addrIDs = DatabaseInteraction.GetAllAddresses();

            foreach (DataColumn dc in addrIDs.Columns)
            {
                dc.AllowDBNull = true;
                dc.AutoIncrement = false;
            }

            addrIDs.Rows.Add();
            address_IDComboBox.DataSource = addrIDs;
            address_IDComboBox.DisplayMember = "ID";
        }

        /// <summary>
        /// Gets all customer ids for its dropdown control.
        /// </summary>
        void GetCustomerIDs()
        {
            DataTable custIDs = DatabaseInteraction.GetAllCustomers();

            customer_IDComboBox.DataSource = custIDs;
            customer_IDComboBox.DisplayMember = "ID";
        }

        /// <summary>
        /// Gets all account ids for its dropdown control.
        /// </summary>
        void GetAccountIDs()
        {
            DataTable accIDs = DatabaseInteraction.GetAllAccounts();

            accountReceiver_IDComboBox.DataSource = new DataView(accIDs);
            accountSender_IDComboBox.DataSource = new DataView(accIDs);

            accountReceiver_IDComboBox.DisplayMember = "ID";
            accountSender_IDComboBox.DisplayMember = "ID";
        }

        /// <summary>
        /// Will choose the correct Create method (Address, Customer, Account or Transaction) based on the type of data the user wants to create.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        void btnCreateNew_Click(object sender, EventArgs e)
        {
            switch (_type)
            {
                case CreateType.Customer:
                    CreateNewCustomer();
                    break;

                case CreateType.Address:
                    CreateNewAddress();
                    break;

                case CreateType.Account:
                    CreateNewAccount();
                    break;

                case CreateType.Transaction:
                    CreateNewTransaction();
                    break;
            }
        }

        void CreateNewCustomer()
        {   //Create a new Customer dataTable but check if all of the inputs are valid first
            if (!int.TryParse(phoneNumberTextBox.Text, out int phoneN))
            {
                MessageBox.Show("Please make sure to only input numbers for the phone number.", "Error using inputs for creating new customer");
                return;
            }

            string firstN = firstNameTextBox.Text;
            string lastN = lastNameTextBox.Text;
            string email = emailAddressTextBox.Text;

            //if (email.Contains("@") && email.Split('@')[0].Length <= 64 && email.Split('@')[1].Length <= 255)
            Regex emailStructure = new Regex(@"^.+(?:[\x21-\x7E].+)*@.+(?:\..+)*$");
            if (int.TryParse(firstN, out int a) || int.TryParse(lastN, out int b) || int.TryParse(email, out int c) || !emailStructure.IsMatch(email))
            {
                MessageBox.Show("Please make sure to only input strings for both names and the email. The email must follow the valid email structure.", "Error using inputs for creating new customer");
                return;
            }

            try
            {
                //address to update may be set to null
                if (String.IsNullOrWhiteSpace(address_IDComboBox.Text))
                {
					DatabaseInteraction.InsertCustomer(firstN, lastN, phoneN, email);
                }
                else
                {
					DatabaseInteraction.InsertCustomer(firstN, lastN, phoneN, email, Convert.ToInt32(address_IDComboBox.Text));
                }
                _hasCanceled = false;
                Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Error oocurred while creating a new customer.");
            }
        }

        void CreateNewAddress()
        {   //Create new address dataTable but check if all of them are valid first
            if (!int.TryParse(streetNumberTextBox.Text, out int streetNumber) || !int.TryParse(zipCodeTextBox.Text, out int zipCode))
            {
                MessageBox.Show("Please make sure to only input numbers for the street number and zip code.", "Error using inputs for creating new address");
                return;
            }

            string streetName = streetNameTextBox.Text;
            string city = cityTextBox.Text;

            if (int.TryParse(streetName, out int a) || int.TryParse(city, out int b))
            {
                MessageBox.Show("Please make sure to only input strings for the street name and city.", "Error using inputs for creating new address");
                return;
            }

            try
            {
				DatabaseInteraction.InsertAddress(streetName, streetNumber, zipCode, city);
                _hasCanceled = false;
                Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Error occured while creating a new address.");
            }
        }

        void CreateNewAccount()
        {   //Create a new Account dataTable but check if all of the inputs are valid first
            if (!int.TryParse(balanceTextBox.Text, out int balance))
            {
                MessageBox.Show("Please make sure to only input numbers for the starting balance.", "Error using inputs for creating new account");
                return;
            }
            string countryCode = CountryCodeComboBox.Text;

            if (String.IsNullOrWhiteSpace(countryCode))
            {
                MessageBox.Show("Please select a country code then try again.", "Error using inputs for creating new account");
                return;
            }

            Random rnd = new Random();
            long hashCode = Math.Abs(countryCode.GetHashCode());
            hashCode *= rnd.Next(1, 10);                                                            //make every hashcode different

            string strHashCode = hashCode.ToString();
            strHashCode = strHashCode.Length > 15 ? strHashCode.Substring(0, 15) : strHashCode;     //limit length of hashcode

			try
            {
				DatabaseInteraction.InsertAccount(balance, Convert.ToInt32(customer_IDComboBox.Text), strHashCode, countryCode);
                _hasCanceled = false;
                Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Error oocurred while creating a new account.");
            }
        }

        /// <summary>
        /// Creates a new Transaction and change the balance of the sender and receiver accounts based on which type of transaction was chosen.
        /// </summary>
        void CreateNewTransaction()
        {   //Create a new transaction but check if all of the inputs are valid first
            if (!int.TryParse(amountTextBox.Text, out int amount))
            {
                MessageBox.Show("Please make sure to only input numbers for the amount.", "Error using inputs for creating new transaction");
                return;
            }

            if (amount < 1)
            {
                MessageBox.Show(string.Concat("You cant start a transaction with the amount of ", amount, ". Please input a greater number than 0"), "Invalid amount");
                return;
            }

            int receiverID = Convert.ToInt32(accountReceiver_IDComboBox.Text);
            int senderID = Convert.ToInt32(accountSender_IDComboBox.Text);

            string intendedUse = intendedUseTextBox.Text;
            string type = typeComboBox.Text;

            if (int.TryParse(intendedUse, out int a))
            {
                MessageBox.Show("Please make sure to only input strings for the intended use.", "Error using inputs for creating new transaction");
                return;
            }

            if (type == TransactionType.Transfer.ToString() && receiverID == senderID)
            {
                MessageBox.Show("You cannot transfer to the same account. Please select a different account or choose a different transaction type and try again.", "Invalid transaction");
                return;
            }

            try
            {
				DatabaseInteraction.InsertTransaction(dateDateTimePicker.Value, amount, intendedUse, type, receiverID, senderID);
                _hasCanceled = false;
                Close();

                //get balance from sender and update it based on the transaction balance
                if (type == TransactionType.Withdrawal.ToString())
                {
					DatabaseInteraction.WithdrawFromAccount(senderID, amount);
                    return;
                }

                //get balance from sender and update it based on the transaction balance
                if (type == TransactionType.Deposit.ToString())
                {
					DatabaseInteraction.DepositToAccount(senderID, amount);
                    return;
                }

                //get balance from both ids and update it based on the transaction balance
                if (type == TransactionType.Transfer.ToString())
                {
					DatabaseInteraction.TransferFromSenderToReceiver(senderID, receiverID, amount);
                    return;
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Error oocurred while creating a new transaction.");
            }
        }



        void CreateNew_FormClosing(object sender, FormClosingEventArgs e)
        {
            DialogResult = _hasCanceled ? DialogResult.Cancel : DialogResult.OK;
        }

        /// <summary>
        /// Contains all different types of DataTables the User can create.
        /// Customer, Address, Account and Transaction.
        /// </summary>
        public enum CreateType
        {
            Customer,
            Address,
            Account,
            Transaction,
        }

        public enum TransactionType
        {
            Withdrawal,
            Deposit,
            Transfer
        }

        /// <summary>
        /// Enable the selection of receiver id if transfer has been selected.
        /// The receiver will be the same as the sender on deposit and withdrawal.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        void typeComboBox_SelectedIndexChanged(object sender, EventArgs e)
        {
            accountReceiver_IDComboBox.Enabled = typeComboBox.Text == TransactionType.Transfer.ToString();

            if (!accountReceiver_IDComboBox.Enabled)
            {
                accountSender_IDComboBox_SelectedIndexChanged(sender, e);
            }
        }

        /// <summary>
        /// Will make the selected Index of both comboBoxes equal if the one for the receiver is disabled.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        void accountSender_IDComboBox_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (!accountReceiver_IDComboBox.Enabled)
            {
                accountReceiver_IDComboBox.SelectedIndex = accountSender_IDComboBox.SelectedIndex;
            }
        }
    }
}