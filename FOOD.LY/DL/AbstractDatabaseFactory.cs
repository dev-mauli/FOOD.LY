using Microsoft.ApplicationBlocks.Data;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;

namespace FOOD.LY.DataAccessLayer
{
	public class AbstractDatabaseFactory
	{
		public static string MConnStr = System.Configuration.ConfigurationManager.ConnectionStrings["ConStr"].ConnectionString;
		//String MConnStr = System.Configuration.ConfigurationManager.ConnectionStrings["MLMconnectionString"].ConnectionString;
		public RetrievedData RetreiveList(string SPName, params string[] Parameters)
		{
			DataSet ds = SqlHelper.ExecuteDataset(MConnStr, SPName, Parameters);
			RetrievedData data = new RetrievedData
			{
				Result = ds.Tables[0].AsEnumerable().ToList()
			};
			return data;
		}
		protected DataSet RetreiveDataSet(string SPName, params string[] Parameters)
		{
			DataSet ds = SqlHelper.ExecuteDataset(MConnStr, SPName, Parameters);
			//RetrievedData data = new RetrievedData();
			//data.Result = ds.Tables[0].AsEnumerable().ToList();
			return ds;
		}

		protected string RetreiveValue(string sqlSelectComand)
		{
			DataSet ds = SqlHelper.ExecuteDataset(MConnStr, CommandType.Text, sqlSelectComand);
			string data = "";
			data = ds.Tables[0].Rows[0].ItemArray[0].ToString();
			return data;
		}

		protected string RetreiveValue(string SPName, params string[] Parameters)
		{
			DataSet ds = SqlHelper.ExecuteDataset(MConnStr, SPName, Parameters);
			string data = "";
			data = Convert.ToString(ds.Tables[0].Rows[0].ItemArray[0]);
			return data;
		}

		protected RetrievedDataMultiple RetreiveListMultipleTables(string SPName, params string[] Parameters)
		{
			DataSet ds = SqlHelper.ExecuteDataset(MConnStr, SPName, Parameters);
			RetrievedDataMultiple datamultiple = new RetrievedDataMultiple();
			foreach (DataTable item in ds.Tables)
			{
				List<DataRow> dr = item.AsEnumerable().ToList();
				datamultiple.Result.Add(dr);
			}
			return datamultiple;
		}

		public RetrievedData RetreiveListWithTransaction(SqlTransaction transaction, string SPName, params string[] Parameters)
		{
			DataSet ds = SqlHelper.ExecuteDataset(transaction, SPName, Parameters);
			RetrievedData data = new RetrievedData
			{
				Result = ds.Tables[0].AsEnumerable().ToList()
			};
			return data;
		}

		public string RetreiveValueWithTransaction(SqlTransaction transaction, string SPName, params string[] Parameters)
		{
			DataSet ds = SqlHelper.ExecuteDataset(transaction, SPName, Parameters);
			string data = "";
			data = Convert.ToString(ds.Tables[0].Rows[0].ItemArray[0]);
			return data;
		}


	}

	public class RetrievedData
	{
		public RetrievedData()
		{
			Result = new List<DataRow>();
		}

		public List<DataRow> Result { get; set; }
	}

	public class RetrievedDataMultiple
	{
		public RetrievedDataMultiple()
		{
			Result = new List<List<DataRow>>();
		}

		public List<List<DataRow>> Result { get; set; }
	}

}
