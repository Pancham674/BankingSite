using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections.Generic;
using System.Data;
using System.IO;
using System.Linq;

namespace BankingSite.UnitTest
{
	[TestClass]
	public class DatabaseInteractionTest
	{
		#region Init and Cleanup
		[ClassInitialize]
		public static void ConnectToDb(TestContext _)
		{
			string[] fileText = File.ReadAllText(@"..\..\secret.txt").Split();

			DatabaseInteraction.CanConnectToServer("BankingSiteTest", string.Concat(Environment.MachineName, @"\", "SQLEXPRESS"), fileText[0], fileText[2]);
			DatabaseInteraction.CreateTables(DatabaseInteraction.GetMissingTables());
			DatabaseInteraction.InsertToAllTables();
		}

		//Method Names: MethodName_Scenario_ExpectedResult

		[ClassCleanup]
		public static void ClearDbData()
		{
			DatabaseInteraction.DeleteAllDataFromAllTables();
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