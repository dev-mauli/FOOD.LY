using FOOD.LY.BE;
using FOOD.LY.DataAccessLayer;
using System;
using System.Data;
using System.Data.SqlClient;

namespace FOOD.LY.BL
{
	public class SAVETOKEN : AbstractDatabaseFactory
	{
		public int SAVE_TOKDEN_INS(T_TOKEN_BE TKT)
		{
			using (SqlConnection connection = new SqlConnection(MConnStr))
			{
				// open the connection
				connection.Open();
				SqlTransaction transaction;
				transaction = connection.BeginTransaction(IsolationLevel.ReadCommitted);
				int ReturnedValue = 0;
				string ACTION = "1";
				try
				{
					string[] parameters = new string[] { Convert.ToString(TKT.ID), Convert.ToString(TKT.USERID), Convert.ToString(TKT.TOKEMSG), Convert.ToString(TKT.TOKENPATH), Convert.ToString(TKT.ENTEREDBY), Convert.ToString(ACTION) };

					ReturnedValue = Convert.ToInt32(RetreiveValueWithTransaction(transaction, "STP_TOKEN", parameters));
					transaction.Commit();
					return ReturnedValue;
				}
				catch (Exception)
				{
					transaction.Rollback();
					throw;
				}
			}
		}
	}
}