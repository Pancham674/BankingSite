using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.IO;
using System.Linq;

namespace BankingSite.UnitTest
{
	[TestClass]
	public class DatabaseInteractionTest
	{
		string _servername = string.Concat(Environment.MachineName, @"\SQLEXPRESS");
		// to test this create a file named "secret.txt" in the BankingSite.UnitTest folder
		string _u = File.ReadAllText(@"..\..\secret.txt").Split()[0];		//first line is the username
		string _p = File.ReadAllText(@"..\..\secret.txt").Split()[2];       //second line is the password
		
		//also create the following databases: BankingSiteTest, EmptyBankingSiteTest

		#region Methods		
		//[ClassInitialize]
		void ConnectToTestDb()
		{
			DatabaseInteraction.ConnectToServer("BankingSiteTest", _servername, _u, _p);
			DatabaseInteraction.CreateTables(DatabaseInteraction.GetMissingTables());
			//DatabaseInteraction.InsertToAllTables();
		}

		//[ClassCleanup]
		void ClearDbData()
		{
			DatabaseInteraction.DeleteAllDataFromAllTables();
		}

		void RemoveAllTables(string myDb)
		{
			SqlConnectionStringBuilder builder = new SqlConnectionStringBuilder()
			{
				DataSource = _servername,
				InitialCatalog = myDb,
				UserID = _u,
				Password = _p,
				IntegratedSecurity = false,
				TrustServerCertificate = true,
				ConnectTimeout = 5
			};

			using (SqlConnection cn = new SqlConnection(builder.ConnectionString))
			{
				cn.Open();
				using (SqlCommand command = cn.CreateCommand())
				{
					command.CommandText = "DROP TABLE [dbo].[Transaction], [dbo].[Account], [dbo].[Customer], [dbo].[Address]";
					command.ExecuteNonQuery();
				}
			}
		}
		#endregion

		#region DB connection tests
		[TestMethod]
		public void CanConnectToServer_IncorrectCredentials_ReturnsSqlException()
		{
			//Given: Declare Action
			Action connectMetod;

			//When: Try to connect to the server with wrong credentials
			connectMetod = () => DatabaseInteraction.ConnectToServer("BankingSiteTest", _servername, "wrong", "also wrong");

			//Then: We get a SqlException
			Assert.ThrowsException<SqlException>(connectMetod);
		}

		[TestMethod]
		public void CanConnectToServer_SqlInjection_ReturnsSqlException()
		{
			//Given: Declare Action
			Action connectMetod;

			//When: Pass an sql injection string as the password
			connectMetod = () => DatabaseInteraction.ConnectToServer("BankingSiteTest", _servername, _u, "NULL OR 1=1; DROP TABLE [dbo].[Customers]");

			//Then: We get a SqlException
			Assert.ThrowsException<SqlException>(connectMetod);
		}

		[TestMethod]
		public void GetDatabases_CompareAvailableDbsToSystemDbs_ReturnsFalse()
		{
			//Given: All system dbs
			ConnectToTestDb();
			string[] sysDbs = { "master", "tempdb", "model", "msdb"};

			//When: Get all available dbs that SHOULD exclude system dbs
			string[] currentDbs = DatabaseInteraction.GetDatabases();

			//Then: The currentDbs shouldn't contain any system db
			Assert.IsFalse(sysDbs.Any(db => currentDbs.Contains(db)));
		}

		//Method Names: MethodName_Scenario_ExpectedResult
		[TestMethod]
		public void GetMissingTables_DbHasNoTables_ReturnsFourMissingTables()
		{
			//Given: Connect to empty db (has no tables)
			DatabaseInteraction.ConnectToServer("EmptyBankingSiteTest", _servername, _u, _p);

			//When: Get the list of missing tables
			List<string> missingTables = DatabaseInteraction.GetMissingTables();

			//Then: since its empty, it should have 4 missing tables
			Assert.AreEqual(4, missingTables.Count);
		}

		[TestMethod]
		public void GetMissingTables_DbHasAllTables_ReturnsZeroMissingTables()
		{
			//Given: Connect to db that has all required tables
			DatabaseInteraction.ConnectToServer("BankingSiteTest", _servername, _u, _p);
		
			//When: Get the list of missing tables
			List<string> missingTables = DatabaseInteraction.GetMissingTables();
			
			//Then: The connected db should have no missing tables
			Assert.AreEqual(0, missingTables.Count);
		}

		[TestMethod]
		public void CreateTables_DbHasNoTables_ReturnsEmptyList()
		{
			//Given: Connect to db that doesn't have all required tables and get the list of them
			string db = "EmptyBankingSiteTest";
			DatabaseInteraction.ConnectToServer(db, _servername, _u, _p);
			List<string> missingTables = DatabaseInteraction.GetMissingTables();

			//When: Create all missing tables
			DatabaseInteraction.CreateTables(missingTables);

			//Assume: the db had 4 missing tables before creating them
			Assert.AreEqual(4, missingTables.Count);

			//Then: There are no more missing tables
			Assert.AreEqual(0, DatabaseInteraction.GetMissingTables().Count);

			//Cleanup: Remove the tables for other tests
			RemoveAllTables(db);
		}

		[TestMethod]
		[DataRow("master")]
		[DataRow("tempdb")]
		[DataRow("model")]
		[DataRow("msdb")]
		public void IsConnectedToSysDb_ConnectedDbIsSysDb_ReturnsTrue(string mySysDb)
		{
			//Given: Connect to a system db
			DatabaseInteraction.ConnectToServer(mySysDb, _servername, _u, _p);

			//When: Check if we're connected to a sys db
			bool isConnectedToSysDb = DatabaseInteraction.IsConnectedToSysDb();
			
			//Then: Should return true
			Assert.IsTrue(isConnectedToSysDb);
		}
		#endregion

		#region SQL Insert & Get Tests
		[TestMethod]
		[DataRow("Monster's Street", 67, 1225, "Home Town")]
		[DataRow("Graffity Alley", 3, 4004, "Canvas Town")]
		[DataRow("Gang Way", 2, 1712, "Orth")]
		public void InsertAndGetAllAddresses_CompareNewRowWithParameters_ReturnsTrue(string StreetName, int StreetNum, int ZipCode, string City)
		{
			//Given: A new address is added
			ConnectToTestDb();
			DatabaseInteraction.InsertAddress(StreetName, StreetNum, ZipCode, City);
			
			//When: We get the newly added address
			DataTable addrTable = DatabaseInteraction.GetAllAddresses();
			DataRow addedRow = addrTable.Rows[addrTable.Rows.Count - 1];

			//Then: The newly added row has the same data as the data we added
			bool addedRowHasEqualData = addedRow.ItemArray[1].Equals(StreetName) && addedRow.ItemArray[2].Equals(StreetNum) && addedRow.ItemArray[3].Equals(ZipCode) && addedRow.ItemArray[4].Equals(City);
			Assert.IsTrue(addedRowHasEqualData);

			//Cleanup: Clear the data for other tests
			ClearDbData();
		}

		[TestMethod]
		[DataRow("Lorenzo", "Waterman", 019255887, "lorenzo.waterman@bunnyfarm.com")]
		[DataRow("Rachel", "Waterman", 019245997, "rachel.waterman@bunnyfarm.com")]
		public void InsertAndGetAllCustomersNoAddress_CompareNewRowWithParameters_ReturnsTrue(string FirstName, string LastName, int PhoneNumber, string Email)
		{
			//Given: A new cutomer is added
			ConnectToTestDb();
			DatabaseInteraction.InsertCustomer(FirstName, LastName, PhoneNumber, Email);

			//When: We get the newly added customer
			DataTable custTable = DatabaseInteraction.GetAllCustomers();
			DataRow addedRow = custTable.Rows[custTable.Rows.Count - 1];

			//Then: The newly added row has the same data as the data we added. The 5th row (address) should be DbNull
			bool addedRowHasEqualData = addedRow.ItemArray[1].Equals(FirstName) && addedRow.ItemArray[2].Equals(LastName)
									 && addedRow.ItemArray[3].Equals(PhoneNumber) && addedRow.ItemArray[4].Equals(Email) && addedRow.ItemArray[5] is DBNull;
			Assert.IsTrue(addedRowHasEqualData);

			//Cleanup: Clear the data for other tests
			ClearDbData();
		}

		[TestMethod]
		[DataRow("Lorenzo", "Waterman", 019255887, "lorenzo.waterman@bunnyfarm.com")]
		[DataRow("Rachel", "Waterman", 019245997, "rachel.waterman@bunnyfarm.com")]
		public void InsertAndGetAllCustomers_CompareNewRowWithParameters_ReturnsTrue(string FirstName, string LastName, int PhoneNumber, string Email)
		{
			//Given: Insert a new address, retrieve its id and add a new cutomer living at that id
			ConnectToTestDb();
			DatabaseInteraction.InsertAddress("Sheepish Stay", 22, 19878, "Pumpkinville");
			int addrCount = DatabaseInteraction.GetAllAddresses().Rows.Count;
			int addrID = (int)DatabaseInteraction.GetAllAddresses().Rows[addrCount - 1].ItemArray[0];
			DatabaseInteraction.InsertCustomer(FirstName, LastName, PhoneNumber, Email, addrID);

			//When: We get the newly added customer
			DataTable custTable = DatabaseInteraction.GetAllCustomers();
			DataRow addedRow = custTable.Rows[custTable.Rows.Count - 1];

			//Then: The newly added row has the same data as the data we added. The 5th row (address) should be DbNull
			bool addedRowHasEqualData = addedRow.ItemArray[1].Equals(FirstName) && addedRow.ItemArray[2].Equals(LastName)
									 && addedRow.ItemArray[3].Equals(PhoneNumber) && addedRow.ItemArray[4].Equals(Email) && addedRow.ItemArray[5].Equals(addrID);
			Assert.IsTrue(addedRowHasEqualData);

			//Cleanup: Clear the data for other tests
			ClearDbData();
		}
		#endregion

		#region SQL Delete Tests
		[TestMethod]
		[DataRow("Monster's Street", 67, 1225, "Home Town")]
		[DataRow("Graffity Alley", 3, 4004, "Canvas Town")]
		[DataRow("Gang Way", 2, 1712, "Orth")]
		public void DeleteAddressWithID_AddressAddedAndDeleted_OldAndNewTablesAreEqual(string StreetName, int StreetNum, int ZipCode, string City)
		{
			//Given: A new address is added
			ConnectToTestDb();
			DataTable addrTable = DatabaseInteraction.GetAllAddresses();
			DatabaseInteraction.InsertAddress(StreetName, StreetNum, ZipCode, City);

			//When: We delete the newly added row
			DataTable updAddrTable = DatabaseInteraction.GetAllAddresses();
			int lastAddrID = (int)updAddrTable.Rows[updAddrTable.Rows.Count - 1].ItemArray[0];
			DatabaseInteraction.DeleteAddressWithID(lastAddrID);
			updAddrTable = DatabaseInteraction.GetAllAddresses();

			//Assume: The old and new row count are equal
			Assert.AreEqual(addrTable.Rows.Count, updAddrTable.Rows.Count);

			//Then: Both tables should have the same elements in the same order
			for (int i = 0; i < addrTable.Rows.Count - 1; i++)
			{
				Assert.AreEqual(addrTable.Rows[i].ItemArray[0], updAddrTable.Rows[i].ItemArray[0]);
			}
		}

		[TestMethod]
		public void InsertToAllTables_CompareRowCountsBeforeAndAfter_ReturnsTrue()
		{
			//Given: We have the row counts of all tables before inserting
			ConnectToTestDb();
			int oldAddrCount = DatabaseInteraction.GetAllAddresses().Rows.Count;
			int oldCustCount = DatabaseInteraction.GetAllCustomers().Rows.Count;
			int oldAccCount = DatabaseInteraction.GetAllAccounts().Rows.Count;
			int oldTransCount = DatabaseInteraction.GetAllTransactions().Rows.Count;

			//When: We insert to all tables and get the new row counts
			DatabaseInteraction.InsertToAllTables();
			int newAddrCount = DatabaseInteraction.GetAllAddresses().Rows.Count;
			int newCustCount = DatabaseInteraction.GetAllCustomers().Rows.Count;
			int newAccCount = DatabaseInteraction.GetAllAccounts().Rows.Count;
			int newTransCount = DatabaseInteraction.GetAllTransactions().Rows.Count;

			bool allNewCountsAreGreater = newAddrCount > oldAddrCount && newCustCount > oldCustCount && newAccCount > oldAccCount && newTransCount > oldTransCount;

			//Then: The new row counts should be greater than the old row counts
			Assert.IsTrue(allNewCountsAreGreater);

			//Cleanup: Clear the data for other tests
			ClearDbData();
		}
		#endregion
	}
}