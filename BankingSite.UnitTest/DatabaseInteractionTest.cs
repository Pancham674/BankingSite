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
		string _u = File.ReadAllText(@"..\..\secret.txt").Split()[0];
		string _p = File.ReadAllText(@"..\..\secret.txt").Split()[2];
		
		#region Init and Cleanup
		//[ClassInitialize]
		void ConnectToTestDb()
		{
			DatabaseInteraction.CanConnectToServer("BankingSiteTest", _servername, _u, _p);
			DatabaseInteraction.CreateTables(DatabaseInteraction.GetMissingTables());
			//DatabaseInteraction.InsertToAllTables();
		}

		[ClassCleanup]
		public static void ClearDbData()
		{
			if (!DatabaseInteraction.ConnectedDatabase.Equals("EmptyBankingSiteTest"))
			{
				DatabaseInteraction.DeleteAllDataFromAllTables();
			}
		}
		#endregion

		#region Methods
		void RemoveAllTables(string myDb)
		{
			string cnString = string.Concat("Data Source=", _servername, ";Initial Catalog=", myDb, ";UID=", _u, ";Password=", _p,
			";Integrated Security=False;TrustServerCertificate=True");

			SqlConnectionStringBuilder builder = new SqlConnectionStringBuilder(cnString);
			builder.ConnectTimeout = 5;

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
			connectMetod = () => DatabaseInteraction.CanConnectToServer("BankingSiteTest", _servername, "wrong", "also wrong");

			//Then: We get a SqlException
			Assert.ThrowsException<SqlException>(connectMetod);
		}

		[TestMethod]
		public void GetDatabases_CompareToSystemDatabases_AreNotEquivalent()
		{
			//Given: All system dbs
			ConnectToTestDb();
			string[] sysDbs = { "master", "tempdb", "model", "msdb" };

			//When: Get all dbs that exclude system dbs
			string[] currentDbs = DatabaseInteraction.GetDatabases().ToArray();

			//Then: The currentDbs shouldn't contain any system db
			CollectionAssert.AreNotEquivalent(currentDbs, sysDbs);
		}

		//Method Names: MethodName_Scenario_ExpectedResult
		[TestMethod]
		public void GetMissingTables_DbHasNoTables_ReturnsFourMissingTables()
		{
			//Given: Connect to empty db (has no tables)
			DatabaseInteraction.CanConnectToServer("EmptyBankingSiteTest", _servername, _u, _p);

			//When: Get the list of missing tables
			List<string> missingTables = DatabaseInteraction.GetMissingTables();

			//Then: since its empty, it should have 4 missing tables
			Assert.AreEqual(4, missingTables.Count);
		}

		[TestMethod]
		public void GetMissingTables_DbHasAllTables_ReturnsZeroMissingTables()
		{
			//Given: Connect to db that has all required tables
			DatabaseInteraction.CanConnectToServer("BankingSiteTest", _servername, _u, _p);
		
			//When: Get the list of missing tables
			List<string> missingTables = DatabaseInteraction.GetMissingTables();
			
			//Then: The connected db should have no missing tables
			Assert.AreEqual(0, missingTables.Count);
		}

		[TestMethod]
		public void CreateTables_DbHasNoTables_ReturnsEmptyList()
		{
			//Given: Connect to db that has all required tables
			string db = "EmptyBankingSiteTest";
			DatabaseInteraction.CanConnectToServer(db, _servername, _u, _p);
			List<string> missingTables = DatabaseInteraction.GetMissingTables();

			//When: Get the list of missing tables
			DatabaseInteraction.CreateTables(missingTables);

			//Assume: the db had 4 missing tables before creating them
			Assert.AreEqual(4, missingTables.Count);

			//Then: There are no more missing tables
			Assert.AreEqual(0, DatabaseInteraction.GetMissingTables().Count);

			//Cleanup: Remove the tables for other tests
			RemoveAllTables(db);
		}
		#endregion

		#region Address Tests
		[TestMethod]
		[DataRow("Monster's Street", 67, 1225, "Home Town")]
		[DataRow("Graffity Alley", 3, 4004, "Canvas Town")]
		[DataRow("Gang Way", 2, 1712, "Orth")]
		public void GetAllAddresses_NewRowAdded_NewRowExistsWithEqualData(string StreetName, int StreetNum, int ZipCode, string City)
		{
			//Given: A new address is added
			ConnectToTestDb();
			DatabaseInteraction.InsertAddress(StreetName, StreetNum, ZipCode, City);
			DataTable addrTable = DatabaseInteraction.GetAllAddresses();
			
			//When: We get the newly added row
			DataRow addedRow = addrTable.Rows[addrTable.Rows.Count - 1];

			//Then: The newly added row has the same data as the data we added
			bool addedRowHasEqualData = addedRow.ItemArray[1].Equals(StreetName) && addedRow.ItemArray[2].Equals(StreetNum) && addedRow.ItemArray[3].Equals(ZipCode) && addedRow.ItemArray[4].Equals(City);
			Assert.IsTrue(addedRowHasEqualData);
		}

		[TestMethod]
		[DataRow("Monster's Street", 67, 1225, "Home Town")]
		[DataRow("Graffity Alley", 3, 4004, "Canvas Town")]
		[DataRow("Gang Way", 2, 1712, "Orth")]
		public void GetAllAddressesDeleteNewAddress_AddressAddedAndDeleted_OldAndNewTablesAreEqual(string StreetName, int StreetNum, int ZipCode, string City)
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
		#endregion

		#region Customer Tests
		#endregion

		#region Account Tests
		#endregion

		#region Transaction Tests
		#endregion
	}
}