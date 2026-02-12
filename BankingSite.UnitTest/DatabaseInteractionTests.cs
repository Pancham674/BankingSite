using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;

namespace BankingSite.UnitTest
{
	[TestClass]
	public class DatabaseInteractionTest
	{
		[ClassInitialize]
		public static void ConnectToDb()
		{
			DatabaseInteraction.CanConnectToServer("BankingSiteTest", string.Concat(Environment.MachineName, @"\", "SQLEXPRESS"), "user", "password");
			DatabaseInteraction.CreateTables(DatabaseInteraction.GetMissingTables());
			DatabaseInteraction.InsertToAllTables(); //r
		}

		//Method Names: MethodName_Scenario_ExpectedResult

		[ClassCleanup]
		public static void ClearDbData()
		{
			DatabaseInteraction.DeleteAllDataFromAllTables();
		}

		[TestMethod]
		public void AddressAdded_AddressExists()
		{
			DataTable dt = DatabaseInteraction.GetAllAddresses();
			var temp = dt.Rows[0].ItemArray;
			Assert.IsTrue(true);
		}
	}
}