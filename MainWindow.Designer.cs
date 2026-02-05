namespace BankingSite
{
	partial class MainWindow
	{
		/// <summary>
		/// Required designer variable.
		/// </summary>
		private System.ComponentModel.IContainer components = null;

		/// <summary>
		/// Clean up any resources being used.
		/// </summary>
		/// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
		protected override void Dispose(bool disposing)
		{
			if (disposing && (components != null))
			{
				components.Dispose();
			}
			base.Dispose(disposing);
		}

		#region Windows Form Designer generated code

		/// <summary>
		/// Required method for Designer support - do not modify
		/// the contents of this method with the code editor.
		/// </summary>
		private void InitializeComponent()
		{
			System.Windows.Forms.Label iDLabel;
			System.Windows.Forms.Label firstNameLabel;
			System.Windows.Forms.Label lastNameLabel;
			System.Windows.Forms.Label phoneNumberLabel;
			System.Windows.Forms.Label emailAddressLabel;
			System.Windows.Forms.Label address_IDLabel;
			System.Windows.Forms.Label iDLabel1;
			System.Windows.Forms.Label streetNameLabel;
			System.Windows.Forms.Label streetNumberLabel;
			System.Windows.Forms.Label zipCodeLabel;
			System.Windows.Forms.Label cityLabel;
			System.Windows.Forms.Label iDLabel2;
			System.Windows.Forms.Label iDLabel3;
			this.tpTransactions = new System.Windows.Forms.TabPage();
			this.tlpTransactions = new System.Windows.Forms.TableLayoutPanel();
			this.dgvTransactions = new System.Windows.Forms.DataGridView();
			this.pnlTransactionDetails = new System.Windows.Forms.Panel();
			this.btnCreateNewTransaction = new System.Windows.Forms.Button();
			this.btnDeleteTransaction = new System.Windows.Forms.Button();
			this.transactionIDTextBox = new System.Windows.Forms.TextBox();
			this.tpAccounts = new System.Windows.Forms.TabPage();
			this.tlpAccounts = new System.Windows.Forms.TableLayoutPanel();
			this.pnlAccountDetails = new System.Windows.Forms.Panel();
			this.btnShowTransactions = new System.Windows.Forms.Button();
			this.accountIDTextBox = new System.Windows.Forms.TextBox();
			this.btnCreateNewAccount = new System.Windows.Forms.Button();
			this.btnDeleteSelectedAccount = new System.Windows.Forms.Button();
			this.dgvAccounts = new System.Windows.Forms.DataGridView();
			this.tpCustomers = new System.Windows.Forms.TabPage();
			this.tlpCostumerAddress = new System.Windows.Forms.TableLayoutPanel();
			this.dgvCustomers = new System.Windows.Forms.DataGridView();
			this.dgvAddresses = new System.Windows.Forms.DataGridView();
			this.pnlCustomerDetails = new System.Windows.Forms.Panel();
			this.customerAddressIDComboBox = new System.Windows.Forms.ComboBox();
			this.customerIDTextBox = new System.Windows.Forms.TextBox();
			this.firstNameTextBox = new System.Windows.Forms.TextBox();
			this.lastNameTextBox = new System.Windows.Forms.TextBox();
			this.phoneNumberTextBox = new System.Windows.Forms.TextBox();
			this.emailAddressTextBox = new System.Windows.Forms.TextBox();
			this.btnShowOwnedAccounts = new System.Windows.Forms.Button();
			this.btnDeleteCustomer = new System.Windows.Forms.Button();
			this.btnCreateNewCustomer = new System.Windows.Forms.Button();
			this.btnUpdateCustomer = new System.Windows.Forms.Button();
			this.pnlAddressTableAdapter = new System.Windows.Forms.Panel();
			this.addressIDTextBox = new System.Windows.Forms.TextBox();
			this.streetNameTextBox = new System.Windows.Forms.TextBox();
			this.streetNumberTextBox = new System.Windows.Forms.TextBox();
			this.zipCodeTextBox = new System.Windows.Forms.TextBox();
			this.cityTextBox = new System.Windows.Forms.TextBox();
			this.btnDeleteAddress = new System.Windows.Forms.Button();
			this.btnCreateNewAddress = new System.Windows.Forms.Button();
			this.btnUpdateAddress = new System.Windows.Forms.Button();
			this.tpDBConnection = new System.Windows.Forms.TabPage();
			this.pnlDbConnection = new System.Windows.Forms.Panel();
			this.btnInsertData = new System.Windows.Forms.Button();
			this.lblDbConnectionTitle = new System.Windows.Forms.Label();
			this.lblDataBaseName = new System.Windows.Forms.Label();
			this.btnConnectToDB = new System.Windows.Forms.Button();
			this.cbDbNames = new System.Windows.Forms.ComboBox();
			this.lblServerName = new System.Windows.Forms.Label();
			this.txtbPassword = new System.Windows.Forms.TextBox();
			this.txtbServerName = new System.Windows.Forms.TextBox();
			this.lblPasword = new System.Windows.Forms.Label();
			this.lblUsername = new System.Windows.Forms.Label();
			this.txtbUsername = new System.Windows.Forms.TextBox();
			this.tcWindow = new System.Windows.Forms.TabControl();
			this.btnDeleteAllData = new System.Windows.Forms.Button();
			iDLabel = new System.Windows.Forms.Label();
			firstNameLabel = new System.Windows.Forms.Label();
			lastNameLabel = new System.Windows.Forms.Label();
			phoneNumberLabel = new System.Windows.Forms.Label();
			emailAddressLabel = new System.Windows.Forms.Label();
			address_IDLabel = new System.Windows.Forms.Label();
			iDLabel1 = new System.Windows.Forms.Label();
			streetNameLabel = new System.Windows.Forms.Label();
			streetNumberLabel = new System.Windows.Forms.Label();
			zipCodeLabel = new System.Windows.Forms.Label();
			cityLabel = new System.Windows.Forms.Label();
			iDLabel2 = new System.Windows.Forms.Label();
			iDLabel3 = new System.Windows.Forms.Label();
			this.tpTransactions.SuspendLayout();
			this.tlpTransactions.SuspendLayout();
			((System.ComponentModel.ISupportInitialize)(this.dgvTransactions)).BeginInit();
			this.pnlTransactionDetails.SuspendLayout();
			this.tpAccounts.SuspendLayout();
			this.tlpAccounts.SuspendLayout();
			this.pnlAccountDetails.SuspendLayout();
			((System.ComponentModel.ISupportInitialize)(this.dgvAccounts)).BeginInit();
			this.tpCustomers.SuspendLayout();
			this.tlpCostumerAddress.SuspendLayout();
			((System.ComponentModel.ISupportInitialize)(this.dgvCustomers)).BeginInit();
			((System.ComponentModel.ISupportInitialize)(this.dgvAddresses)).BeginInit();
			this.pnlCustomerDetails.SuspendLayout();
			this.pnlAddressTableAdapter.SuspendLayout();
			this.tpDBConnection.SuspendLayout();
			this.pnlDbConnection.SuspendLayout();
			this.tcWindow.SuspendLayout();
			this.SuspendLayout();
			// 
			// iDLabel
			// 
			iDLabel.Anchor = System.Windows.Forms.AnchorStyles.None;
			iDLabel.AutoSize = true;
			iDLabel.Font = new System.Drawing.Font("Bahnschrift Condensed", 14.25F);
			iDLabel.Location = new System.Drawing.Point(13, 22);
			iDLabel.Name = "iDLabel";
			iDLabel.Size = new System.Drawing.Size(24, 23);
			iDLabel.TabIndex = 23;
			iDLabel.Text = "ID:";
			// 
			// firstNameLabel
			// 
			firstNameLabel.Anchor = System.Windows.Forms.AnchorStyles.None;
			firstNameLabel.AutoSize = true;
			firstNameLabel.Font = new System.Drawing.Font("Bahnschrift Condensed", 14.25F);
			firstNameLabel.Location = new System.Drawing.Point(13, 56);
			firstNameLabel.Name = "firstNameLabel";
			firstNameLabel.Size = new System.Drawing.Size(81, 23);
			firstNameLabel.TabIndex = 25;
			firstNameLabel.Text = "First Name:";
			// 
			// lastNameLabel
			// 
			lastNameLabel.Anchor = System.Windows.Forms.AnchorStyles.None;
			lastNameLabel.AutoSize = true;
			lastNameLabel.Font = new System.Drawing.Font("Bahnschrift Condensed", 14.25F);
			lastNameLabel.Location = new System.Drawing.Point(13, 90);
			lastNameLabel.Name = "lastNameLabel";
			lastNameLabel.Size = new System.Drawing.Size(79, 23);
			lastNameLabel.TabIndex = 27;
			lastNameLabel.Text = "Last Name:";
			// 
			// phoneNumberLabel
			// 
			phoneNumberLabel.Anchor = System.Windows.Forms.AnchorStyles.None;
			phoneNumberLabel.AutoSize = true;
			phoneNumberLabel.Font = new System.Drawing.Font("Bahnschrift Condensed", 14.25F);
			phoneNumberLabel.Location = new System.Drawing.Point(13, 124);
			phoneNumberLabel.Name = "phoneNumberLabel";
			phoneNumberLabel.Size = new System.Drawing.Size(103, 23);
			phoneNumberLabel.TabIndex = 29;
			phoneNumberLabel.Text = "Phone Number:";
			// 
			// emailAddressLabel
			// 
			emailAddressLabel.Anchor = System.Windows.Forms.AnchorStyles.None;
			emailAddressLabel.AutoSize = true;
			emailAddressLabel.Font = new System.Drawing.Font("Bahnschrift Condensed", 14.25F);
			emailAddressLabel.Location = new System.Drawing.Point(13, 158);
			emailAddressLabel.Name = "emailAddressLabel";
			emailAddressLabel.Size = new System.Drawing.Size(103, 23);
			emailAddressLabel.TabIndex = 31;
			emailAddressLabel.Text = "Email Address:";
			// 
			// address_IDLabel
			// 
			address_IDLabel.Anchor = System.Windows.Forms.AnchorStyles.None;
			address_IDLabel.AutoSize = true;
			address_IDLabel.Font = new System.Drawing.Font("Bahnschrift Condensed", 14.25F);
			address_IDLabel.Location = new System.Drawing.Point(13, 192);
			address_IDLabel.Name = "address_IDLabel";
			address_IDLabel.Size = new System.Drawing.Size(79, 23);
			address_IDLabel.TabIndex = 33;
			address_IDLabel.Text = "Address ID:";
			// 
			// iDLabel1
			// 
			iDLabel1.Anchor = System.Windows.Forms.AnchorStyles.None;
			iDLabel1.AutoSize = true;
			iDLabel1.Font = new System.Drawing.Font("Bahnschrift Condensed", 14.25F);
			iDLabel1.Location = new System.Drawing.Point(13, 26);
			iDLabel1.Name = "iDLabel1";
			iDLabel1.Size = new System.Drawing.Size(24, 23);
			iDLabel1.TabIndex = 23;
			iDLabel1.Text = "ID:";
			// 
			// streetNameLabel
			// 
			streetNameLabel.Anchor = System.Windows.Forms.AnchorStyles.None;
			streetNameLabel.AutoSize = true;
			streetNameLabel.Font = new System.Drawing.Font("Bahnschrift Condensed", 14.25F);
			streetNameLabel.Location = new System.Drawing.Point(13, 60);
			streetNameLabel.Name = "streetNameLabel";
			streetNameLabel.Size = new System.Drawing.Size(90, 23);
			streetNameLabel.TabIndex = 25;
			streetNameLabel.Text = "Street Name:";
			// 
			// streetNumberLabel
			// 
			streetNumberLabel.Anchor = System.Windows.Forms.AnchorStyles.None;
			streetNumberLabel.AutoSize = true;
			streetNumberLabel.Font = new System.Drawing.Font("Bahnschrift Condensed", 14.25F);
			streetNumberLabel.Location = new System.Drawing.Point(13, 94);
			streetNumberLabel.Name = "streetNumberLabel";
			streetNumberLabel.Size = new System.Drawing.Size(103, 23);
			streetNumberLabel.TabIndex = 27;
			streetNumberLabel.Text = "Street Number:";
			// 
			// zipCodeLabel
			// 
			zipCodeLabel.Anchor = System.Windows.Forms.AnchorStyles.None;
			zipCodeLabel.AutoSize = true;
			zipCodeLabel.Font = new System.Drawing.Font("Bahnschrift Condensed", 14.25F);
			zipCodeLabel.Location = new System.Drawing.Point(13, 128);
			zipCodeLabel.Name = "zipCodeLabel";
			zipCodeLabel.Size = new System.Drawing.Size(66, 23);
			zipCodeLabel.TabIndex = 29;
			zipCodeLabel.Text = "Zip Code:";
			// 
			// cityLabel
			// 
			cityLabel.Anchor = System.Windows.Forms.AnchorStyles.None;
			cityLabel.AutoSize = true;
			cityLabel.Font = new System.Drawing.Font("Bahnschrift Condensed", 14.25F);
			cityLabel.Location = new System.Drawing.Point(13, 162);
			cityLabel.Name = "cityLabel";
			cityLabel.Size = new System.Drawing.Size(36, 23);
			cityLabel.TabIndex = 31;
			cityLabel.Text = "City:";
			// 
			// iDLabel2
			// 
			iDLabel2.Anchor = System.Windows.Forms.AnchorStyles.None;
			iDLabel2.AutoSize = true;
			iDLabel2.Font = new System.Drawing.Font("Bahnschrift Condensed", 14.25F);
			iDLabel2.Location = new System.Drawing.Point(397, 26);
			iDLabel2.Name = "iDLabel2";
			iDLabel2.Size = new System.Drawing.Size(81, 23);
			iDLabel2.TabIndex = 33;
			iDLabel2.Text = "Selected ID:";
			// 
			// iDLabel3
			// 
			iDLabel3.Anchor = System.Windows.Forms.AnchorStyles.None;
			iDLabel3.AutoSize = true;
			iDLabel3.Font = new System.Drawing.Font("Bahnschrift Condensed", 14.25F);
			iDLabel3.Location = new System.Drawing.Point(397, 26);
			iDLabel3.Name = "iDLabel3";
			iDLabel3.Size = new System.Drawing.Size(81, 23);
			iDLabel3.TabIndex = 1;
			iDLabel3.Text = "Selected ID:";
			// 
			// tpTransactions
			// 
			this.tpTransactions.AutoScroll = true;
			this.tpTransactions.Controls.Add(this.tlpTransactions);
			this.tpTransactions.Location = new System.Drawing.Point(4, 27);
			this.tpTransactions.Name = "tpTransactions";
			this.tpTransactions.Padding = new System.Windows.Forms.Padding(3);
			this.tpTransactions.Size = new System.Drawing.Size(998, 630);
			this.tpTransactions.TabIndex = 3;
			this.tpTransactions.Text = "Transactions";
			this.tpTransactions.UseVisualStyleBackColor = true;
			// 
			// tlpTransactions
			// 
			this.tlpTransactions.CellBorderStyle = System.Windows.Forms.TableLayoutPanelCellBorderStyle.Single;
			this.tlpTransactions.ColumnCount = 1;
			this.tlpTransactions.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100F));
			this.tlpTransactions.Controls.Add(this.dgvTransactions, 0, 0);
			this.tlpTransactions.Controls.Add(this.pnlTransactionDetails, 0, 1);
			this.tlpTransactions.Dock = System.Windows.Forms.DockStyle.Fill;
			this.tlpTransactions.Location = new System.Drawing.Point(3, 3);
			this.tlpTransactions.Name = "tlpTransactions";
			this.tlpTransactions.RowCount = 2;
			this.tlpTransactions.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100F));
			this.tlpTransactions.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 80F));
			this.tlpTransactions.Size = new System.Drawing.Size(992, 624);
			this.tlpTransactions.TabIndex = 36;
			// 
			// dgvTransactions
			// 
			this.dgvTransactions.AllowUserToAddRows = false;
			this.dgvTransactions.AllowUserToDeleteRows = false;
			this.dgvTransactions.AllowUserToResizeColumns = false;
			this.dgvTransactions.AllowUserToResizeRows = false;
			this.dgvTransactions.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.AllCells;
			this.dgvTransactions.AutoSizeRowsMode = System.Windows.Forms.DataGridViewAutoSizeRowsMode.AllCells;
			this.dgvTransactions.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
			this.dgvTransactions.Dock = System.Windows.Forms.DockStyle.Fill;
			this.dgvTransactions.Location = new System.Drawing.Point(4, 4);
			this.dgvTransactions.MultiSelect = false;
			this.dgvTransactions.Name = "dgvTransactions";
			this.dgvTransactions.ReadOnly = true;
			this.dgvTransactions.RowHeadersWidth = 4;
			this.dgvTransactions.RowHeadersWidthSizeMode = System.Windows.Forms.DataGridViewRowHeadersWidthSizeMode.DisableResizing;
			this.dgvTransactions.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
			this.dgvTransactions.Size = new System.Drawing.Size(984, 535);
			this.dgvTransactions.TabIndex = 1;
			// 
			// pnlTransactionDetails
			// 
			this.pnlTransactionDetails.AutoScroll = true;
			this.pnlTransactionDetails.Controls.Add(this.btnCreateNewTransaction);
			this.pnlTransactionDetails.Controls.Add(iDLabel3);
			this.pnlTransactionDetails.Controls.Add(this.btnDeleteTransaction);
			this.pnlTransactionDetails.Controls.Add(this.transactionIDTextBox);
			this.pnlTransactionDetails.Dock = System.Windows.Forms.DockStyle.Fill;
			this.pnlTransactionDetails.Location = new System.Drawing.Point(4, 546);
			this.pnlTransactionDetails.Name = "pnlTransactionDetails";
			this.pnlTransactionDetails.Size = new System.Drawing.Size(984, 74);
			this.pnlTransactionDetails.TabIndex = 12;
			// 
			// btnCreateNewTransaction
			// 
			this.btnCreateNewTransaction.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
			this.btnCreateNewTransaction.Cursor = System.Windows.Forms.Cursors.Hand;
			this.btnCreateNewTransaction.Font = new System.Drawing.Font("Bahnschrift Condensed", 14F);
			this.btnCreateNewTransaction.Location = new System.Drawing.Point(22, 17);
			this.btnCreateNewTransaction.MaximumSize = new System.Drawing.Size(200, 40);
			this.btnCreateNewTransaction.MinimumSize = new System.Drawing.Size(200, 40);
			this.btnCreateNewTransaction.Name = "btnCreateNewTransaction";
			this.btnCreateNewTransaction.Size = new System.Drawing.Size(200, 40);
			this.btnCreateNewTransaction.TabIndex = 35;
			this.btnCreateNewTransaction.Text = "Create New Transaction...";
			this.btnCreateNewTransaction.UseVisualStyleBackColor = true;
			this.btnCreateNewTransaction.Click += new System.EventHandler(this.btnCreateNewTransaction_Click);
			// 
			// btnDeleteTransaction
			// 
			this.btnDeleteTransaction.Anchor = System.Windows.Forms.AnchorStyles.None;
			this.btnDeleteTransaction.Cursor = System.Windows.Forms.Cursors.Hand;
			this.btnDeleteTransaction.Font = new System.Drawing.Font("Bahnschrift Condensed", 14F);
			this.btnDeleteTransaction.Location = new System.Drawing.Point(612, 17);
			this.btnDeleteTransaction.MaximumSize = new System.Drawing.Size(155, 40);
			this.btnDeleteTransaction.MinimumSize = new System.Drawing.Size(155, 40);
			this.btnDeleteTransaction.Name = "btnDeleteTransaction";
			this.btnDeleteTransaction.Size = new System.Drawing.Size(155, 40);
			this.btnDeleteTransaction.TabIndex = 34;
			this.btnDeleteTransaction.Text = "Delete Transaction";
			this.btnDeleteTransaction.UseVisualStyleBackColor = true;
			this.btnDeleteTransaction.Click += new System.EventHandler(this.btnDeleteTransaction_Click);
			// 
			// transactionIDTextBox
			// 
			this.transactionIDTextBox.Anchor = System.Windows.Forms.AnchorStyles.None;
			this.transactionIDTextBox.Font = new System.Drawing.Font("Bahnschrift Condensed", 14.25F);
			this.transactionIDTextBox.Location = new System.Drawing.Point(495, 22);
			this.transactionIDTextBox.MaximumSize = new System.Drawing.Size(100, 30);
			this.transactionIDTextBox.MinimumSize = new System.Drawing.Size(100, 30);
			this.transactionIDTextBox.Name = "transactionIDTextBox";
			this.transactionIDTextBox.ReadOnly = true;
			this.transactionIDTextBox.Size = new System.Drawing.Size(100, 30);
			this.transactionIDTextBox.TabIndex = 2;
			// 
			// tpAccounts
			// 
			this.tpAccounts.AutoScroll = true;
			this.tpAccounts.Controls.Add(this.tlpAccounts);
			this.tpAccounts.Location = new System.Drawing.Point(4, 27);
			this.tpAccounts.Name = "tpAccounts";
			this.tpAccounts.Padding = new System.Windows.Forms.Padding(3);
			this.tpAccounts.Size = new System.Drawing.Size(998, 630);
			this.tpAccounts.TabIndex = 2;
			this.tpAccounts.Text = "Accounts";
			this.tpAccounts.UseVisualStyleBackColor = true;
			// 
			// tlpAccounts
			// 
			this.tlpAccounts.CellBorderStyle = System.Windows.Forms.TableLayoutPanelCellBorderStyle.Single;
			this.tlpAccounts.ColumnCount = 1;
			this.tlpAccounts.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100F));
			this.tlpAccounts.Controls.Add(this.pnlAccountDetails, 0, 1);
			this.tlpAccounts.Controls.Add(this.dgvAccounts, 0, 0);
			this.tlpAccounts.Dock = System.Windows.Forms.DockStyle.Fill;
			this.tlpAccounts.Location = new System.Drawing.Point(3, 3);
			this.tlpAccounts.Name = "tlpAccounts";
			this.tlpAccounts.RowCount = 2;
			this.tlpAccounts.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100F));
			this.tlpAccounts.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 80F));
			this.tlpAccounts.Size = new System.Drawing.Size(992, 624);
			this.tlpAccounts.TabIndex = 11;
			// 
			// pnlAccountDetails
			// 
			this.pnlAccountDetails.AutoScroll = true;
			this.pnlAccountDetails.Controls.Add(this.btnShowTransactions);
			this.pnlAccountDetails.Controls.Add(iDLabel2);
			this.pnlAccountDetails.Controls.Add(this.accountIDTextBox);
			this.pnlAccountDetails.Controls.Add(this.btnCreateNewAccount);
			this.pnlAccountDetails.Controls.Add(this.btnDeleteSelectedAccount);
			this.pnlAccountDetails.Dock = System.Windows.Forms.DockStyle.Fill;
			this.pnlAccountDetails.Location = new System.Drawing.Point(4, 546);
			this.pnlAccountDetails.Name = "pnlAccountDetails";
			this.pnlAccountDetails.Size = new System.Drawing.Size(984, 74);
			this.pnlAccountDetails.TabIndex = 12;
			// 
			// btnShowTransactions
			// 
			this.btnShowTransactions.Anchor = System.Windows.Forms.AnchorStyles.None;
			this.btnShowTransactions.Cursor = System.Windows.Forms.Cursors.Hand;
			this.btnShowTransactions.Font = new System.Drawing.Font("Bahnschrift Condensed", 14F);
			this.btnShowTransactions.Location = new System.Drawing.Point(612, 17);
			this.btnShowTransactions.MaximumSize = new System.Drawing.Size(155, 40);
			this.btnShowTransactions.MinimumSize = new System.Drawing.Size(155, 40);
			this.btnShowTransactions.Name = "btnShowTransactions";
			this.btnShowTransactions.Size = new System.Drawing.Size(155, 40);
			this.btnShowTransactions.TabIndex = 35;
			this.btnShowTransactions.Text = "Show Transactions...";
			this.btnShowTransactions.UseVisualStyleBackColor = true;
			this.btnShowTransactions.Click += new System.EventHandler(this.btnShowTransactions_Click);
			// 
			// accountIDTextBox
			// 
			this.accountIDTextBox.Anchor = System.Windows.Forms.AnchorStyles.None;
			this.accountIDTextBox.Font = new System.Drawing.Font("Bahnschrift Condensed", 14.25F);
			this.accountIDTextBox.Location = new System.Drawing.Point(495, 22);
			this.accountIDTextBox.MaximumSize = new System.Drawing.Size(100, 30);
			this.accountIDTextBox.MinimumSize = new System.Drawing.Size(100, 30);
			this.accountIDTextBox.Name = "accountIDTextBox";
			this.accountIDTextBox.ReadOnly = true;
			this.accountIDTextBox.Size = new System.Drawing.Size(100, 30);
			this.accountIDTextBox.TabIndex = 34;
			// 
			// btnCreateNewAccount
			// 
			this.btnCreateNewAccount.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
			this.btnCreateNewAccount.Cursor = System.Windows.Forms.Cursors.Hand;
			this.btnCreateNewAccount.Font = new System.Drawing.Font("Bahnschrift Condensed", 14F);
			this.btnCreateNewAccount.Location = new System.Drawing.Point(22, 17);
			this.btnCreateNewAccount.MaximumSize = new System.Drawing.Size(200, 40);
			this.btnCreateNewAccount.MinimumSize = new System.Drawing.Size(200, 40);
			this.btnCreateNewAccount.Name = "btnCreateNewAccount";
			this.btnCreateNewAccount.Size = new System.Drawing.Size(200, 40);
			this.btnCreateNewAccount.TabIndex = 33;
			this.btnCreateNewAccount.Text = "Create New Account...";
			this.btnCreateNewAccount.UseVisualStyleBackColor = true;
			this.btnCreateNewAccount.Click += new System.EventHandler(this.btnCreateNewAccount_Click);
			// 
			// btnDeleteSelectedAccount
			// 
			this.btnDeleteSelectedAccount.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
			this.btnDeleteSelectedAccount.Cursor = System.Windows.Forms.Cursors.Hand;
			this.btnDeleteSelectedAccount.Font = new System.Drawing.Font("Bahnschrift Condensed", 14F);
			this.btnDeleteSelectedAccount.Location = new System.Drawing.Point(784, 17);
			this.btnDeleteSelectedAccount.MaximumSize = new System.Drawing.Size(155, 40);
			this.btnDeleteSelectedAccount.MinimumSize = new System.Drawing.Size(155, 40);
			this.btnDeleteSelectedAccount.Name = "btnDeleteSelectedAccount";
			this.btnDeleteSelectedAccount.Size = new System.Drawing.Size(155, 40);
			this.btnDeleteSelectedAccount.TabIndex = 23;
			this.btnDeleteSelectedAccount.Text = "Delete Account";
			this.btnDeleteSelectedAccount.UseVisualStyleBackColor = true;
			this.btnDeleteSelectedAccount.Click += new System.EventHandler(this.btnDeleteSelectedAccount_Click);
			// 
			// dgvAccounts
			// 
			this.dgvAccounts.AllowUserToAddRows = false;
			this.dgvAccounts.AllowUserToDeleteRows = false;
			this.dgvAccounts.AllowUserToResizeColumns = false;
			this.dgvAccounts.AllowUserToResizeRows = false;
			this.dgvAccounts.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.AllCells;
			this.dgvAccounts.AutoSizeRowsMode = System.Windows.Forms.DataGridViewAutoSizeRowsMode.AllCells;
			this.dgvAccounts.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
			this.dgvAccounts.Dock = System.Windows.Forms.DockStyle.Fill;
			this.dgvAccounts.Location = new System.Drawing.Point(4, 4);
			this.dgvAccounts.MultiSelect = false;
			this.dgvAccounts.Name = "dgvAccounts";
			this.dgvAccounts.ReadOnly = true;
			this.dgvAccounts.RowHeadersWidth = 4;
			this.dgvAccounts.RowHeadersWidthSizeMode = System.Windows.Forms.DataGridViewRowHeadersWidthSizeMode.DisableResizing;
			this.dgvAccounts.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
			this.dgvAccounts.Size = new System.Drawing.Size(984, 535);
			this.dgvAccounts.TabIndex = 1;
			// 
			// tpCustomers
			// 
			this.tpCustomers.Controls.Add(this.tlpCostumerAddress);
			this.tpCustomers.Location = new System.Drawing.Point(4, 27);
			this.tpCustomers.Name = "tpCustomers";
			this.tpCustomers.Padding = new System.Windows.Forms.Padding(3);
			this.tpCustomers.Size = new System.Drawing.Size(998, 630);
			this.tpCustomers.TabIndex = 1;
			this.tpCustomers.Text = "Customers";
			this.tpCustomers.UseVisualStyleBackColor = true;
			// 
			// tlpCostumerAddress
			// 
			this.tlpCostumerAddress.CellBorderStyle = System.Windows.Forms.TableLayoutPanelCellBorderStyle.Single;
			this.tlpCostumerAddress.ColumnCount = 2;
			this.tlpCostumerAddress.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle());
			this.tlpCostumerAddress.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100F));
			this.tlpCostumerAddress.Controls.Add(this.dgvCustomers, 1, 0);
			this.tlpCostumerAddress.Controls.Add(this.dgvAddresses, 1, 1);
			this.tlpCostumerAddress.Controls.Add(this.pnlCustomerDetails, 0, 0);
			this.tlpCostumerAddress.Controls.Add(this.pnlAddressTableAdapter, 0, 1);
			this.tlpCostumerAddress.Dock = System.Windows.Forms.DockStyle.Fill;
			this.tlpCostumerAddress.Location = new System.Drawing.Point(3, 3);
			this.tlpCostumerAddress.Name = "tlpCostumerAddress";
			this.tlpCostumerAddress.RowCount = 2;
			this.tlpCostumerAddress.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 50F));
			this.tlpCostumerAddress.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 50F));
			this.tlpCostumerAddress.Size = new System.Drawing.Size(992, 624);
			this.tlpCostumerAddress.TabIndex = 14;
			// 
			// dgvCustomers
			// 
			this.dgvCustomers.AllowUserToAddRows = false;
			this.dgvCustomers.AllowUserToDeleteRows = false;
			this.dgvCustomers.AllowUserToResizeColumns = false;
			this.dgvCustomers.AllowUserToResizeRows = false;
			this.dgvCustomers.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.AllCells;
			this.dgvCustomers.AutoSizeRowsMode = System.Windows.Forms.DataGridViewAutoSizeRowsMode.AllCells;
			this.dgvCustomers.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
			this.dgvCustomers.Dock = System.Windows.Forms.DockStyle.Fill;
			this.dgvCustomers.Location = new System.Drawing.Point(346, 4);
			this.dgvCustomers.MultiSelect = false;
			this.dgvCustomers.Name = "dgvCustomers";
			this.dgvCustomers.ReadOnly = true;
			this.dgvCustomers.RowHeadersWidth = 4;
			this.dgvCustomers.RowHeadersWidthSizeMode = System.Windows.Forms.DataGridViewRowHeadersWidthSizeMode.DisableResizing;
			this.dgvCustomers.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
			this.dgvCustomers.ShowEditingIcon = false;
			this.dgvCustomers.Size = new System.Drawing.Size(642, 304);
			this.dgvCustomers.TabIndex = 0;
			this.dgvCustomers.SelectionChanged += new System.EventHandler(this.dgvCustomers_SelectionChanged);
			// 
			// dgvAddresses
			// 
			this.dgvAddresses.AllowUserToAddRows = false;
			this.dgvAddresses.AllowUserToDeleteRows = false;
			this.dgvAddresses.AllowUserToResizeColumns = false;
			this.dgvAddresses.AllowUserToResizeRows = false;
			this.dgvAddresses.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.AllCells;
			this.dgvAddresses.AutoSizeRowsMode = System.Windows.Forms.DataGridViewAutoSizeRowsMode.AllCells;
			this.dgvAddresses.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
			this.dgvAddresses.Dock = System.Windows.Forms.DockStyle.Fill;
			this.dgvAddresses.Location = new System.Drawing.Point(346, 315);
			this.dgvAddresses.MultiSelect = false;
			this.dgvAddresses.Name = "dgvAddresses";
			this.dgvAddresses.ReadOnly = true;
			this.dgvAddresses.RowHeadersWidth = 4;
			this.dgvAddresses.RowHeadersWidthSizeMode = System.Windows.Forms.DataGridViewRowHeadersWidthSizeMode.DisableResizing;
			this.dgvAddresses.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
			this.dgvAddresses.ShowEditingIcon = false;
			this.dgvAddresses.Size = new System.Drawing.Size(642, 305);
			this.dgvAddresses.TabIndex = 1;
			// 
			// pnlCustomerDetails
			// 
			this.pnlCustomerDetails.AutoScroll = true;
			this.pnlCustomerDetails.Controls.Add(this.customerAddressIDComboBox);
			this.pnlCustomerDetails.Controls.Add(iDLabel);
			this.pnlCustomerDetails.Controls.Add(this.customerIDTextBox);
			this.pnlCustomerDetails.Controls.Add(firstNameLabel);
			this.pnlCustomerDetails.Controls.Add(this.firstNameTextBox);
			this.pnlCustomerDetails.Controls.Add(lastNameLabel);
			this.pnlCustomerDetails.Controls.Add(this.lastNameTextBox);
			this.pnlCustomerDetails.Controls.Add(phoneNumberLabel);
			this.pnlCustomerDetails.Controls.Add(this.phoneNumberTextBox);
			this.pnlCustomerDetails.Controls.Add(emailAddressLabel);
			this.pnlCustomerDetails.Controls.Add(this.emailAddressTextBox);
			this.pnlCustomerDetails.Controls.Add(address_IDLabel);
			this.pnlCustomerDetails.Controls.Add(this.btnShowOwnedAccounts);
			this.pnlCustomerDetails.Controls.Add(this.btnDeleteCustomer);
			this.pnlCustomerDetails.Controls.Add(this.btnCreateNewCustomer);
			this.pnlCustomerDetails.Controls.Add(this.btnUpdateCustomer);
			this.pnlCustomerDetails.Dock = System.Windows.Forms.DockStyle.Fill;
			this.pnlCustomerDetails.Location = new System.Drawing.Point(4, 4);
			this.pnlCustomerDetails.Name = "pnlCustomerDetails";
			this.pnlCustomerDetails.Size = new System.Drawing.Size(335, 304);
			this.pnlCustomerDetails.TabIndex = 21;
			// 
			// customerAddressIDComboBox
			// 
			this.customerAddressIDComboBox.Anchor = System.Windows.Forms.AnchorStyles.None;
			this.customerAddressIDComboBox.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
			this.customerAddressIDComboBox.Font = new System.Drawing.Font("Bahnschrift Condensed", 14.25F);
			this.customerAddressIDComboBox.FormattingEnabled = true;
			this.customerAddressIDComboBox.Location = new System.Drawing.Point(155, 185);
			this.customerAddressIDComboBox.Name = "customerAddressIDComboBox";
			this.customerAddressIDComboBox.Size = new System.Drawing.Size(171, 31);
			this.customerAddressIDComboBox.TabIndex = 38;
			// 
			// customerIDTextBox
			// 
			this.customerIDTextBox.Anchor = System.Windows.Forms.AnchorStyles.None;
			this.customerIDTextBox.Font = new System.Drawing.Font("Bahnschrift Condensed", 14.25F);
			this.customerIDTextBox.Location = new System.Drawing.Point(155, 15);
			this.customerIDTextBox.Name = "customerIDTextBox";
			this.customerIDTextBox.ReadOnly = true;
			this.customerIDTextBox.Size = new System.Drawing.Size(171, 30);
			this.customerIDTextBox.TabIndex = 24;
			// 
			// firstNameTextBox
			// 
			this.firstNameTextBox.Anchor = System.Windows.Forms.AnchorStyles.None;
			this.firstNameTextBox.Font = new System.Drawing.Font("Bahnschrift Condensed", 14.25F);
			this.firstNameTextBox.Location = new System.Drawing.Point(155, 49);
			this.firstNameTextBox.MaxLength = 100;
			this.firstNameTextBox.Name = "firstNameTextBox";
			this.firstNameTextBox.Size = new System.Drawing.Size(171, 30);
			this.firstNameTextBox.TabIndex = 26;
			// 
			// lastNameTextBox
			// 
			this.lastNameTextBox.Anchor = System.Windows.Forms.AnchorStyles.None;
			this.lastNameTextBox.Font = new System.Drawing.Font("Bahnschrift Condensed", 14.25F);
			this.lastNameTextBox.Location = new System.Drawing.Point(155, 83);
			this.lastNameTextBox.MaxLength = 100;
			this.lastNameTextBox.Name = "lastNameTextBox";
			this.lastNameTextBox.Size = new System.Drawing.Size(171, 30);
			this.lastNameTextBox.TabIndex = 28;
			// 
			// phoneNumberTextBox
			// 
			this.phoneNumberTextBox.Anchor = System.Windows.Forms.AnchorStyles.None;
			this.phoneNumberTextBox.Font = new System.Drawing.Font("Bahnschrift Condensed", 14.25F);
			this.phoneNumberTextBox.Location = new System.Drawing.Point(155, 117);
			this.phoneNumberTextBox.Name = "phoneNumberTextBox";
			this.phoneNumberTextBox.Size = new System.Drawing.Size(171, 30);
			this.phoneNumberTextBox.TabIndex = 30;
			// 
			// emailAddressTextBox
			// 
			this.emailAddressTextBox.Anchor = System.Windows.Forms.AnchorStyles.None;
			this.emailAddressTextBox.Font = new System.Drawing.Font("Bahnschrift Condensed", 14.25F);
			this.emailAddressTextBox.Location = new System.Drawing.Point(155, 151);
			this.emailAddressTextBox.MaxLength = 255;
			this.emailAddressTextBox.Name = "emailAddressTextBox";
			this.emailAddressTextBox.Size = new System.Drawing.Size(171, 30);
			this.emailAddressTextBox.TabIndex = 32;
			// 
			// btnShowOwnedAccounts
			// 
			this.btnShowOwnedAccounts.Anchor = System.Windows.Forms.AnchorStyles.None;
			this.btnShowOwnedAccounts.Cursor = System.Windows.Forms.Cursors.Hand;
			this.btnShowOwnedAccounts.Font = new System.Drawing.Font("Bahnschrift Condensed", 14F);
			this.btnShowOwnedAccounts.Location = new System.Drawing.Point(9, 258);
			this.btnShowOwnedAccounts.Name = "btnShowOwnedAccounts";
			this.btnShowOwnedAccounts.Size = new System.Drawing.Size(171, 32);
			this.btnShowOwnedAccounts.TabIndex = 23;
			this.btnShowOwnedAccounts.Text = "Show Owned Accounts...";
			this.btnShowOwnedAccounts.UseVisualStyleBackColor = true;
			this.btnShowOwnedAccounts.Click += new System.EventHandler(this.btnShowOwnedAccounts_Click);
			// 
			// btnDeleteCustomer
			// 
			this.btnDeleteCustomer.Anchor = System.Windows.Forms.AnchorStyles.None;
			this.btnDeleteCustomer.Cursor = System.Windows.Forms.Cursors.Hand;
			this.btnDeleteCustomer.Font = new System.Drawing.Font("Bahnschrift Condensed", 14F);
			this.btnDeleteCustomer.Location = new System.Drawing.Point(186, 258);
			this.btnDeleteCustomer.Name = "btnDeleteCustomer";
			this.btnDeleteCustomer.Size = new System.Drawing.Size(140, 32);
			this.btnDeleteCustomer.TabIndex = 22;
			this.btnDeleteCustomer.Text = "Delete Customer";
			this.btnDeleteCustomer.UseVisualStyleBackColor = true;
			this.btnDeleteCustomer.Click += new System.EventHandler(this.btnDeleteCustomer_Click);
			// 
			// btnCreateNewCustomer
			// 
			this.btnCreateNewCustomer.Anchor = System.Windows.Forms.AnchorStyles.None;
			this.btnCreateNewCustomer.Cursor = System.Windows.Forms.Cursors.Hand;
			this.btnCreateNewCustomer.Font = new System.Drawing.Font("Bahnschrift Condensed", 14F);
			this.btnCreateNewCustomer.Location = new System.Drawing.Point(9, 222);
			this.btnCreateNewCustomer.Name = "btnCreateNewCustomer";
			this.btnCreateNewCustomer.Size = new System.Drawing.Size(171, 32);
			this.btnCreateNewCustomer.TabIndex = 21;
			this.btnCreateNewCustomer.Text = "Create New Customer...";
			this.btnCreateNewCustomer.UseVisualStyleBackColor = true;
			this.btnCreateNewCustomer.Click += new System.EventHandler(this.btnCreateNewCustomer_Click);
			// 
			// btnUpdateCustomer
			// 
			this.btnUpdateCustomer.Anchor = System.Windows.Forms.AnchorStyles.None;
			this.btnUpdateCustomer.Cursor = System.Windows.Forms.Cursors.Hand;
			this.btnUpdateCustomer.Font = new System.Drawing.Font("Bahnschrift Condensed", 14F);
			this.btnUpdateCustomer.Location = new System.Drawing.Point(186, 222);
			this.btnUpdateCustomer.Name = "btnUpdateCustomer";
			this.btnUpdateCustomer.Size = new System.Drawing.Size(140, 32);
			this.btnUpdateCustomer.TabIndex = 20;
			this.btnUpdateCustomer.Text = "Update Customer";
			this.btnUpdateCustomer.UseVisualStyleBackColor = true;
			this.btnUpdateCustomer.Click += new System.EventHandler(this.btnUpdateCustomer_Click);
			// 
			// pnlAddressTableAdapter
			// 
			this.pnlAddressTableAdapter.AutoScroll = true;
			this.pnlAddressTableAdapter.Controls.Add(iDLabel1);
			this.pnlAddressTableAdapter.Controls.Add(this.addressIDTextBox);
			this.pnlAddressTableAdapter.Controls.Add(streetNameLabel);
			this.pnlAddressTableAdapter.Controls.Add(this.streetNameTextBox);
			this.pnlAddressTableAdapter.Controls.Add(streetNumberLabel);
			this.pnlAddressTableAdapter.Controls.Add(this.streetNumberTextBox);
			this.pnlAddressTableAdapter.Controls.Add(zipCodeLabel);
			this.pnlAddressTableAdapter.Controls.Add(this.zipCodeTextBox);
			this.pnlAddressTableAdapter.Controls.Add(cityLabel);
			this.pnlAddressTableAdapter.Controls.Add(this.cityTextBox);
			this.pnlAddressTableAdapter.Controls.Add(this.btnDeleteAddress);
			this.pnlAddressTableAdapter.Controls.Add(this.btnCreateNewAddress);
			this.pnlAddressTableAdapter.Controls.Add(this.btnUpdateAddress);
			this.pnlAddressTableAdapter.Dock = System.Windows.Forms.DockStyle.Fill;
			this.pnlAddressTableAdapter.Location = new System.Drawing.Point(4, 315);
			this.pnlAddressTableAdapter.Name = "pnlAddressTableAdapter";
			this.pnlAddressTableAdapter.Size = new System.Drawing.Size(335, 305);
			this.pnlAddressTableAdapter.TabIndex = 22;
			// 
			// addressIDTextBox
			// 
			this.addressIDTextBox.Anchor = System.Windows.Forms.AnchorStyles.None;
			this.addressIDTextBox.Font = new System.Drawing.Font("Bahnschrift Condensed", 14.25F);
			this.addressIDTextBox.Location = new System.Drawing.Point(166, 24);
			this.addressIDTextBox.Name = "addressIDTextBox";
			this.addressIDTextBox.ReadOnly = true;
			this.addressIDTextBox.Size = new System.Drawing.Size(157, 30);
			this.addressIDTextBox.TabIndex = 24;
			// 
			// streetNameTextBox
			// 
			this.streetNameTextBox.Anchor = System.Windows.Forms.AnchorStyles.None;
			this.streetNameTextBox.Font = new System.Drawing.Font("Bahnschrift Condensed", 14.25F);
			this.streetNameTextBox.Location = new System.Drawing.Point(166, 58);
			this.streetNameTextBox.MaxLength = 200;
			this.streetNameTextBox.Name = "streetNameTextBox";
			this.streetNameTextBox.Size = new System.Drawing.Size(157, 30);
			this.streetNameTextBox.TabIndex = 26;
			// 
			// streetNumberTextBox
			// 
			this.streetNumberTextBox.Anchor = System.Windows.Forms.AnchorStyles.None;
			this.streetNumberTextBox.Font = new System.Drawing.Font("Bahnschrift Condensed", 14.25F);
			this.streetNumberTextBox.Location = new System.Drawing.Point(166, 92);
			this.streetNumberTextBox.Name = "streetNumberTextBox";
			this.streetNumberTextBox.Size = new System.Drawing.Size(157, 30);
			this.streetNumberTextBox.TabIndex = 28;
			// 
			// zipCodeTextBox
			// 
			this.zipCodeTextBox.Anchor = System.Windows.Forms.AnchorStyles.None;
			this.zipCodeTextBox.Font = new System.Drawing.Font("Bahnschrift Condensed", 14.25F);
			this.zipCodeTextBox.Location = new System.Drawing.Point(166, 126);
			this.zipCodeTextBox.Name = "zipCodeTextBox";
			this.zipCodeTextBox.Size = new System.Drawing.Size(157, 30);
			this.zipCodeTextBox.TabIndex = 30;
			// 
			// cityTextBox
			// 
			this.cityTextBox.Anchor = System.Windows.Forms.AnchorStyles.None;
			this.cityTextBox.Font = new System.Drawing.Font("Bahnschrift Condensed", 14.25F);
			this.cityTextBox.Location = new System.Drawing.Point(166, 160);
			this.cityTextBox.MaxLength = 200;
			this.cityTextBox.Name = "cityTextBox";
			this.cityTextBox.Size = new System.Drawing.Size(157, 30);
			this.cityTextBox.TabIndex = 32;
			// 
			// btnDeleteAddress
			// 
			this.btnDeleteAddress.Anchor = System.Windows.Forms.AnchorStyles.None;
			this.btnDeleteAddress.Cursor = System.Windows.Forms.Cursors.Hand;
			this.btnDeleteAddress.Font = new System.Drawing.Font("Bahnschrift Condensed", 14F);
			this.btnDeleteAddress.Location = new System.Drawing.Point(186, 249);
			this.btnDeleteAddress.Name = "btnDeleteAddress";
			this.btnDeleteAddress.Size = new System.Drawing.Size(140, 32);
			this.btnDeleteAddress.TabIndex = 23;
			this.btnDeleteAddress.Text = "Delete Address";
			this.btnDeleteAddress.UseVisualStyleBackColor = true;
			this.btnDeleteAddress.Click += new System.EventHandler(this.btnDeleteAddress_Click);
			// 
			// btnCreateNewAddress
			// 
			this.btnCreateNewAddress.Anchor = System.Windows.Forms.AnchorStyles.None;
			this.btnCreateNewAddress.Cursor = System.Windows.Forms.Cursors.Hand;
			this.btnCreateNewAddress.Font = new System.Drawing.Font("Bahnschrift Condensed", 14F);
			this.btnCreateNewAddress.Location = new System.Drawing.Point(9, 211);
			this.btnCreateNewAddress.Name = "btnCreateNewAddress";
			this.btnCreateNewAddress.Size = new System.Drawing.Size(171, 32);
			this.btnCreateNewAddress.TabIndex = 23;
			this.btnCreateNewAddress.Text = "Create New Address...";
			this.btnCreateNewAddress.UseVisualStyleBackColor = true;
			this.btnCreateNewAddress.Click += new System.EventHandler(this.btnCreateNewAddress_Click);
			// 
			// btnUpdateAddress
			// 
			this.btnUpdateAddress.Anchor = System.Windows.Forms.AnchorStyles.None;
			this.btnUpdateAddress.Cursor = System.Windows.Forms.Cursors.Hand;
			this.btnUpdateAddress.Font = new System.Drawing.Font("Bahnschrift Condensed", 14F);
			this.btnUpdateAddress.Location = new System.Drawing.Point(186, 211);
			this.btnUpdateAddress.Name = "btnUpdateAddress";
			this.btnUpdateAddress.Size = new System.Drawing.Size(140, 32);
			this.btnUpdateAddress.TabIndex = 22;
			this.btnUpdateAddress.Text = "Update Address";
			this.btnUpdateAddress.UseVisualStyleBackColor = true;
			this.btnUpdateAddress.Click += new System.EventHandler(this.btnUpdateAddress_Click);
			// 
			// tpDBConnection
			// 
			this.tpDBConnection.BackColor = System.Drawing.Color.Gainsboro;
			this.tpDBConnection.Controls.Add(this.pnlDbConnection);
			this.tpDBConnection.Location = new System.Drawing.Point(4, 27);
			this.tpDBConnection.Name = "tpDBConnection";
			this.tpDBConnection.Padding = new System.Windows.Forms.Padding(3);
			this.tpDBConnection.Size = new System.Drawing.Size(998, 630);
			this.tpDBConnection.TabIndex = 0;
			this.tpDBConnection.Text = "DB Connection";
			// 
			// pnlDbConnection
			// 
			this.pnlDbConnection.Anchor = System.Windows.Forms.AnchorStyles.None;
			this.pnlDbConnection.AutoSize = true;
			this.pnlDbConnection.BackColor = System.Drawing.SystemColors.Control;
			this.pnlDbConnection.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
			this.pnlDbConnection.Controls.Add(this.btnDeleteAllData);
			this.pnlDbConnection.Controls.Add(this.btnInsertData);
			this.pnlDbConnection.Controls.Add(this.lblDbConnectionTitle);
			this.pnlDbConnection.Controls.Add(this.lblDataBaseName);
			this.pnlDbConnection.Controls.Add(this.btnConnectToDB);
			this.pnlDbConnection.Controls.Add(this.cbDbNames);
			this.pnlDbConnection.Controls.Add(this.lblServerName);
			this.pnlDbConnection.Controls.Add(this.txtbPassword);
			this.pnlDbConnection.Controls.Add(this.txtbServerName);
			this.pnlDbConnection.Controls.Add(this.lblPasword);
			this.pnlDbConnection.Controls.Add(this.lblUsername);
			this.pnlDbConnection.Controls.Add(this.txtbUsername);
			this.pnlDbConnection.Location = new System.Drawing.Point(238, 133);
			this.pnlDbConnection.Name = "pnlDbConnection";
			this.pnlDbConnection.Size = new System.Drawing.Size(522, 365);
			this.pnlDbConnection.TabIndex = 24;
			// 
			// btnInsertData
			// 
			this.btnInsertData.Anchor = System.Windows.Forms.AnchorStyles.None;
			this.btnInsertData.BackColor = System.Drawing.SystemColors.Window;
			this.btnInsertData.Cursor = System.Windows.Forms.Cursors.Hand;
			this.btnInsertData.Enabled = false;
			this.btnInsertData.Font = new System.Drawing.Font("Bahnschrift Condensed", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.btnInsertData.Location = new System.Drawing.Point(195, 292);
			this.btnInsertData.MaximumSize = new System.Drawing.Size(130, 40);
			this.btnInsertData.MinimumSize = new System.Drawing.Size(130, 40);
			this.btnInsertData.Name = "btnInsertData";
			this.btnInsertData.Size = new System.Drawing.Size(130, 40);
			this.btnInsertData.TabIndex = 25;
			this.btnInsertData.Text = "Insert Data";
			this.btnInsertData.UseVisualStyleBackColor = false;
			this.btnInsertData.Click += new System.EventHandler(this.btnInsertData_Click);
			// 
			// lblDbConnectionTitle
			// 
			this.lblDbConnectionTitle.Anchor = System.Windows.Forms.AnchorStyles.None;
			this.lblDbConnectionTitle.AutoSize = true;
			this.lblDbConnectionTitle.Font = new System.Drawing.Font("Bahnschrift Condensed", 20.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.lblDbConnectionTitle.Location = new System.Drawing.Point(121, 29);
			this.lblDbConnectionTitle.Name = "lblDbConnectionTitle";
			this.lblDbConnectionTitle.Size = new System.Drawing.Size(278, 33);
			this.lblDbConnectionTitle.TabIndex = 23;
			this.lblDbConnectionTitle.Text = "Connect to a Database Server";
			this.lblDbConnectionTitle.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
			// 
			// lblDataBaseName
			// 
			this.lblDataBaseName.Anchor = System.Windows.Forms.AnchorStyles.None;
			this.lblDataBaseName.AutoSize = true;
			this.lblDataBaseName.Font = new System.Drawing.Font("Bahnschrift Condensed", 14.25F);
			this.lblDataBaseName.Location = new System.Drawing.Point(47, 227);
			this.lblDataBaseName.Name = "lblDataBaseName";
			this.lblDataBaseName.Size = new System.Drawing.Size(86, 23);
			this.lblDataBaseName.TabIndex = 22;
			this.lblDataBaseName.Text = "Selected DB:";
			this.lblDataBaseName.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
			// 
			// btnConnectToDB
			// 
			this.btnConnectToDB.Anchor = System.Windows.Forms.AnchorStyles.None;
			this.btnConnectToDB.BackColor = System.Drawing.SystemColors.Window;
			this.btnConnectToDB.Cursor = System.Windows.Forms.Cursors.Hand;
			this.btnConnectToDB.Font = new System.Drawing.Font("Bahnschrift Condensed", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.btnConnectToDB.Location = new System.Drawing.Point(46, 292);
			this.btnConnectToDB.MaximumSize = new System.Drawing.Size(130, 40);
			this.btnConnectToDB.MinimumSize = new System.Drawing.Size(130, 40);
			this.btnConnectToDB.Name = "btnConnectToDB";
			this.btnConnectToDB.Size = new System.Drawing.Size(130, 40);
			this.btnConnectToDB.TabIndex = 13;
			this.btnConnectToDB.Text = "Connect";
			this.btnConnectToDB.UseVisualStyleBackColor = false;
			this.btnConnectToDB.Click += new System.EventHandler(this.btnConnectToDB_Click);
			// 
			// cbDbNames
			// 
			this.cbDbNames.Anchor = System.Windows.Forms.AnchorStyles.None;
			this.cbDbNames.Font = new System.Drawing.Font("Bahnschrift Condensed", 14.25F);
			this.cbDbNames.FormattingEnabled = true;
			this.cbDbNames.Location = new System.Drawing.Point(163, 225);
			this.cbDbNames.MinimumSize = new System.Drawing.Size(255, 0);
			this.cbDbNames.Name = "cbDbNames";
			this.cbDbNames.Size = new System.Drawing.Size(311, 31);
			this.cbDbNames.TabIndex = 21;
			this.cbDbNames.DropDown += new System.EventHandler(this.cbDbNames_DropDown);
			// 
			// lblServerName
			// 
			this.lblServerName.Anchor = System.Windows.Forms.AnchorStyles.None;
			this.lblServerName.AutoSize = true;
			this.lblServerName.Font = new System.Drawing.Font("Bahnschrift Condensed", 14.25F);
			this.lblServerName.Location = new System.Drawing.Point(47, 89);
			this.lblServerName.Name = "lblServerName";
			this.lblServerName.Size = new System.Drawing.Size(93, 23);
			this.lblServerName.TabIndex = 14;
			this.lblServerName.Text = "Server Name:";
			this.lblServerName.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
			// 
			// txtbPassword
			// 
			this.txtbPassword.Anchor = System.Windows.Forms.AnchorStyles.None;
			this.txtbPassword.Font = new System.Drawing.Font("Bahnschrift Condensed", 14.25F);
			this.txtbPassword.Location = new System.Drawing.Point(163, 179);
			this.txtbPassword.MinimumSize = new System.Drawing.Size(255, 27);
			this.txtbPassword.Name = "txtbPassword";
			this.txtbPassword.PasswordChar = '*';
			this.txtbPassword.Size = new System.Drawing.Size(311, 30);
			this.txtbPassword.TabIndex = 20;
			// 
			// txtbServerName
			// 
			this.txtbServerName.Anchor = System.Windows.Forms.AnchorStyles.None;
			this.txtbServerName.Font = new System.Drawing.Font("Bahnschrift Condensed", 14.25F);
			this.txtbServerName.Location = new System.Drawing.Point(163, 87);
			this.txtbServerName.MinimumSize = new System.Drawing.Size(255, 27);
			this.txtbServerName.Name = "txtbServerName";
			this.txtbServerName.Size = new System.Drawing.Size(311, 30);
			this.txtbServerName.TabIndex = 16;
			// 
			// lblPasword
			// 
			this.lblPasword.Anchor = System.Windows.Forms.AnchorStyles.None;
			this.lblPasword.AutoSize = true;
			this.lblPasword.Font = new System.Drawing.Font("Bahnschrift Condensed", 14.25F);
			this.lblPasword.Location = new System.Drawing.Point(47, 181);
			this.lblPasword.Name = "lblPasword";
			this.lblPasword.Size = new System.Drawing.Size(75, 23);
			this.lblPasword.TabIndex = 19;
			this.lblPasword.Text = "Password:";
			this.lblPasword.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
			// 
			// lblUsername
			// 
			this.lblUsername.Anchor = System.Windows.Forms.AnchorStyles.None;
			this.lblUsername.AutoSize = true;
			this.lblUsername.Font = new System.Drawing.Font("Bahnschrift Condensed", 14.25F);
			this.lblUsername.Location = new System.Drawing.Point(47, 135);
			this.lblUsername.Name = "lblUsername";
			this.lblUsername.Size = new System.Drawing.Size(76, 23);
			this.lblUsername.TabIndex = 17;
			this.lblUsername.Text = "Username:";
			this.lblUsername.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
			// 
			// txtbUsername
			// 
			this.txtbUsername.Anchor = System.Windows.Forms.AnchorStyles.None;
			this.txtbUsername.Font = new System.Drawing.Font("Bahnschrift Condensed", 14.25F);
			this.txtbUsername.Location = new System.Drawing.Point(163, 133);
			this.txtbUsername.MinimumSize = new System.Drawing.Size(255, 27);
			this.txtbUsername.Name = "txtbUsername";
			this.txtbUsername.Size = new System.Drawing.Size(311, 30);
			this.txtbUsername.TabIndex = 18;
			// 
			// tcWindow
			// 
			this.tcWindow.Controls.Add(this.tpDBConnection);
			this.tcWindow.Controls.Add(this.tpCustomers);
			this.tcWindow.Controls.Add(this.tpAccounts);
			this.tcWindow.Controls.Add(this.tpTransactions);
			this.tcWindow.Cursor = System.Windows.Forms.Cursors.Arrow;
			this.tcWindow.Dock = System.Windows.Forms.DockStyle.Fill;
			this.tcWindow.Font = new System.Drawing.Font("Bahnschrift Condensed", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.tcWindow.Location = new System.Drawing.Point(0, 0);
			this.tcWindow.Name = "tcWindow";
			this.tcWindow.SelectedIndex = 0;
			this.tcWindow.Size = new System.Drawing.Size(1006, 661);
			this.tcWindow.TabIndex = 0;
			this.tcWindow.SelectedIndexChanged += new System.EventHandler(this.tcWindow_SelectedIndexChanged);
			this.tcWindow.Selecting += new System.Windows.Forms.TabControlCancelEventHandler(this.tcWindow_Selecting);
			// 
			// btnDeleteAllData
			// 
			this.btnDeleteAllData.Anchor = System.Windows.Forms.AnchorStyles.None;
			this.btnDeleteAllData.BackColor = System.Drawing.SystemColors.Window;
			this.btnDeleteAllData.Cursor = System.Windows.Forms.Cursors.Hand;
			this.btnDeleteAllData.Enabled = false;
			this.btnDeleteAllData.Font = new System.Drawing.Font("Bahnschrift Condensed", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.btnDeleteAllData.Location = new System.Drawing.Point(344, 292);
			this.btnDeleteAllData.MaximumSize = new System.Drawing.Size(130, 40);
			this.btnDeleteAllData.MinimumSize = new System.Drawing.Size(130, 40);
			this.btnDeleteAllData.Name = "btnDeleteAllData";
			this.btnDeleteAllData.Size = new System.Drawing.Size(130, 40);
			this.btnDeleteAllData.TabIndex = 26;
			this.btnDeleteAllData.Text = "Delete All Data";
			this.btnDeleteAllData.UseVisualStyleBackColor = false;
			this.btnDeleteAllData.Click += new System.EventHandler(this.btnDeleteAllData_Click);
			// 
			// MainWindow
			// 
			this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
			this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
			this.BackColor = System.Drawing.SystemColors.Control;
			this.ClientSize = new System.Drawing.Size(1006, 661);
			this.Controls.Add(this.tcWindow);
			this.MinimumSize = new System.Drawing.Size(1022, 700);
			this.Name = "MainWindow";
			this.ShowIcon = false;
			this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
			this.Text = "Banking Site";
			this.Load += new System.EventHandler(this.Window_Load);
			this.tpTransactions.ResumeLayout(false);
			this.tlpTransactions.ResumeLayout(false);
			((System.ComponentModel.ISupportInitialize)(this.dgvTransactions)).EndInit();
			this.pnlTransactionDetails.ResumeLayout(false);
			this.pnlTransactionDetails.PerformLayout();
			this.tpAccounts.ResumeLayout(false);
			this.tlpAccounts.ResumeLayout(false);
			this.pnlAccountDetails.ResumeLayout(false);
			this.pnlAccountDetails.PerformLayout();
			((System.ComponentModel.ISupportInitialize)(this.dgvAccounts)).EndInit();
			this.tpCustomers.ResumeLayout(false);
			this.tlpCostumerAddress.ResumeLayout(false);
			((System.ComponentModel.ISupportInitialize)(this.dgvCustomers)).EndInit();
			((System.ComponentModel.ISupportInitialize)(this.dgvAddresses)).EndInit();
			this.pnlCustomerDetails.ResumeLayout(false);
			this.pnlCustomerDetails.PerformLayout();
			this.pnlAddressTableAdapter.ResumeLayout(false);
			this.pnlAddressTableAdapter.PerformLayout();
			this.tpDBConnection.ResumeLayout(false);
			this.tpDBConnection.PerformLayout();
			this.pnlDbConnection.ResumeLayout(false);
			this.pnlDbConnection.PerformLayout();
			this.tcWindow.ResumeLayout(false);
			this.ResumeLayout(false);

		}

		#endregion

		private System.Windows.Forms.TabPage tpTransactions;
		private System.Windows.Forms.TabPage tpAccounts;
		private System.Windows.Forms.TabPage tpCustomers;
		private System.Windows.Forms.TabPage tpDBConnection;
		private System.Windows.Forms.TabControl tcWindow;
		private System.Windows.Forms.DataGridView dgvTransactions;
		private System.Windows.Forms.DataGridView dgvCustomers;
		private System.Windows.Forms.Label lblServerName;
		private System.Windows.Forms.Button btnConnectToDB;
		private System.Windows.Forms.TextBox txtbServerName;
		private System.Windows.Forms.TextBox txtbPassword;
		private System.Windows.Forms.Label lblPasword;
		private System.Windows.Forms.TextBox txtbUsername;
		private System.Windows.Forms.Label lblUsername;
		private System.Windows.Forms.Label lblDataBaseName;
		private System.Windows.Forms.ComboBox cbDbNames;
		private System.Windows.Forms.DataGridView dgvAddresses;
		private System.Windows.Forms.Panel pnlDbConnection;
		private System.Windows.Forms.Label lblDbConnectionTitle;
		private System.Windows.Forms.TableLayoutPanel tlpCostumerAddress;
		private System.Windows.Forms.Panel pnlCustomerDetails;
		private System.Windows.Forms.Button btnCreateNewCustomer;
		private System.Windows.Forms.Button btnUpdateCustomer;
		private System.Windows.Forms.Panel pnlAddressTableAdapter;
		private System.Windows.Forms.Button btnCreateNewAddress;
		private System.Windows.Forms.Button btnUpdateAddress;
		private System.Windows.Forms.Button btnDeleteCustomer;
		private System.Windows.Forms.Button btnDeleteAddress;
		private System.Windows.Forms.Button btnShowOwnedAccounts;
		private System.Windows.Forms.TableLayoutPanel tlpAccounts;
		private System.Windows.Forms.Panel pnlAccountDetails;
		private System.Windows.Forms.Button btnDeleteSelectedAccount;
		private System.Windows.Forms.Button btnCreateNewAccount;
		private System.Windows.Forms.TextBox customerIDTextBox;
		private System.Windows.Forms.TextBox firstNameTextBox;
		private System.Windows.Forms.TextBox lastNameTextBox;
		private System.Windows.Forms.TextBox phoneNumberTextBox;
		private System.Windows.Forms.TextBox emailAddressTextBox;
		private System.Windows.Forms.TextBox addressIDTextBox;
		private System.Windows.Forms.TextBox streetNameTextBox;
		private System.Windows.Forms.TextBox streetNumberTextBox;
		private System.Windows.Forms.TextBox zipCodeTextBox;
		private System.Windows.Forms.TextBox cityTextBox;
		private System.Windows.Forms.TextBox accountIDTextBox;
		private System.Windows.Forms.TextBox transactionIDTextBox;
		private System.Windows.Forms.Button btnCreateNewTransaction;
		private System.Windows.Forms.Button btnDeleteTransaction;
		private System.Windows.Forms.TableLayoutPanel tlpTransactions;
		private System.Windows.Forms.Panel pnlTransactionDetails;
		private System.Windows.Forms.DataGridView dgvAccounts;
		private System.Windows.Forms.Button btnShowTransactions;
		private System.Windows.Forms.Button btnInsertData;
		private System.Windows.Forms.ComboBox customerAddressIDComboBox;
		private System.Windows.Forms.Button btnDeleteAllData;
	}
}