
using FOOD.LY.BE;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.IO;
using System.Net;
using System.Net.Mail;
using System.Reflection;
using System.Security.Cryptography;
using System.Text;

namespace FOOD.LY.DataAccessLayer
{

	public class ClassConverterHelper
	{
		/// <summary>
		/// Converts Generic Class From Model to Relevant DataContract Instance.
		/// </summary>
		/// <typeparam name="Source">Source Class Name</typeparam>
		/// <typeparam name="Target">Destination Class Name (DataContract Name)</typeparam>
		/// <param name="src">Source Class Object</param>
		/// <returns>List of Destination Class Objects populated with data from Model</returns>
		public static Target ConvertToClassSingleRow<Source, Target>(Source src)
		{
			Type destinationType = typeof(Target);
			PropertyInfo[] destPropertyInfo = destinationType.GetProperties();

			Target result = (Target)Activator.CreateInstance(destinationType);

			Type sourceType = src.GetType();
			PropertyInfo[] srcPropertyInfo = sourceType.GetProperties();
			List<DataRow> drs = (List<DataRow>)srcPropertyInfo[0].GetValue(src, null);

			foreach (DataRow dr in drs)
			{
				Target destpart = (Target)Activator.CreateInstance(destinationType);
				foreach (DataColumn dc in dr.Table.Columns)
				{
					foreach (PropertyInfo item in destPropertyInfo)
					{
						if (item.Name == dc.ColumnName)
						{
							if (dr[dc] != DBNull.Value)
							{
								item.SetValue(destpart, dr[dc], null);
							}
							break;
						}
					}
				}
				result = destpart;
				break;
			}
			return result;
		}

		/// <summary>
		/// Converts Generic Class From Model to Relevant DataContract Instance.
		/// </summary>
		/// <typeparam name="Source">Source Class Name</typeparam>
		/// <typeparam name="Target">Destination Class Name (DataContract Name)</typeparam>
		/// <param name="src">Source Class Object</param>
		/// <returns>List of Destination Class Objects populated with data from Model</returns>
		public static List<Target> ConvertToClass<Source, Target>(Source src)
		{
			List<Target> result = new List<Target>();

			Type destinationType = typeof(Target);
			PropertyInfo[] destPropertyInfo = destinationType.GetProperties();

			Type sourceType = src.GetType();
			PropertyInfo[] srcPropertyInfo = sourceType.GetProperties();
			List<DataRow> drs = (List<DataRow>)srcPropertyInfo[0].GetValue(src, null);

			foreach (DataRow dr in drs)
			{
				Target destpart = (Target)Activator.CreateInstance(destinationType);
				foreach (DataColumn dc in dr.Table.Columns)
				{
					foreach (PropertyInfo item in destPropertyInfo)
					{
						if (item.Name == dc.ColumnName)
						{
							if (dr[dc] != DBNull.Value)
							{
								item.SetValue(destpart, dr[dc], null);
							}
							break;
						}
					}
				}
				result.Add(destpart);
			}
			return result;
		}

		/// <summary>
		/// Converts Generic Class From Model to Relevant DataContract Instance.
		/// </summary>
		/// <typeparam name="Source">Source Class Name</typeparam>
		/// <typeparam name="Target">Destination Class Name (DataContract Name)</typeparam>
		/// <param name="src">Source Class Object</param>
		/// <param name="TableNo">Number of the table to be retrived if Source is RetrievedDataMultiple</param>
		/// <returns>List of Destination Class Objects populated with data from Model</returns>
		public static Target ConvertToClassSingleRow<Source, Target>(Source src, int TableNo)
		{
			Type destinationType = typeof(Target);
			PropertyInfo[] destPropertyInfo = destinationType.GetProperties();

			Target result = (Target)Activator.CreateInstance(destinationType);

			Type sourceType = src.GetType();
			PropertyInfo[] srcPropertyInfo = sourceType.GetProperties();
			List<List<DataRow>> Multipledrs = (List<List<DataRow>>)srcPropertyInfo[0].GetValue(src, null);

			if (TableNo <= Multipledrs.Count)
			{
				List<DataRow> drs = Multipledrs[TableNo - 1];
				foreach (DataRow dr in drs)
				{
					Target destpart = (Target)Activator.CreateInstance(destinationType);
					foreach (DataColumn dc in dr.Table.Columns)
					{
						foreach (PropertyInfo item in destPropertyInfo)
						{
							if (item.Name == dc.ColumnName)
							{
								if (dr[dc] != DBNull.Value)
								{
									item.SetValue(destpart, dr[dc], null);
								}
								break;
							}
						}
					}
					result = destpart;
					break;
				}
			}
			return result;
		}

		/// <summary>
		/// Converts Generic Class From Model to Relevant DataContract Instance.
		/// </summary>
		/// <typeparam name="Source">Source Class Name</typeparam>
		/// <typeparam name="Target">Destination Class Name (DataContract Name)</typeparam>
		/// <param name="src">Source Class Object</param>
		/// <param name="TableNo">Number of the table to be retrived if Source is RetrievedDataMultiple</param>
		/// <returns>List of Destination Class Objects populated with data from Model</returns>
		public static List<Target> ConvertToClass<Source, Target>(Source src, int TableNo)
		{
			List<Target> result = new List<Target>();

			Type destinationType = typeof(Target);
			PropertyInfo[] destPropertyInfo = destinationType.GetProperties();

			Type sourceType = src.GetType();
			PropertyInfo[] srcPropertyInfo = sourceType.GetProperties();
			List<List<DataRow>> Multipledrs = (List<List<DataRow>>)srcPropertyInfo[0].GetValue(src, null);

			if (TableNo <= Multipledrs.Count)
			{
				List<DataRow> drs = Multipledrs[TableNo - 1];
				foreach (DataRow dr in drs)
				{
					Target destpart = (Target)Activator.CreateInstance(destinationType);
					foreach (DataColumn dc in dr.Table.Columns)
					{
						foreach (PropertyInfo item in destPropertyInfo)
						{
							if (item.Name == dc.ColumnName)
							{
								if (dr[dc] != DBNull.Value)
								{
									item.SetValue(destpart, dr[dc], null);
								}
								break;
							}
						}
					}
					result.Add(destpart);
				}
			}
			return result;
		}

		//Send Email To Client...!!!
		public static bool SendEmail(string mailbody, string email, string subject)
		{
			string to = email; //To address    
			string from = "premlad961@gmail.com"; //From address    
			MailMessage message = new MailMessage(from, to)
			{
				Subject = subject,
				Body = mailbody,
				BodyEncoding = Encoding.UTF8,
				IsBodyHtml = true
			};
			SmtpClient client = new SmtpClient("smtp.gmail.com", 587); //Gmail smtp    
			System.Net.NetworkCredential basicCredential1 = new System.Net.NetworkCredential("premlad961@gmail.com", "Premlad961@#");
			//System.Net.NetworkCredential basicCredential1 = new System.Net.NetworkCredential("dreal.software.solutions@gmail.com", "DReal@@123");
			client.EnableSsl = true;
			client.UseDefaultCredentials = true;
			client.Credentials = basicCredential1;
			try
			{
				client.Send(message);
				return true;
			}

			catch (Exception ex)
			{
				throw ex;
			}


		}

		//Get GEo LOcation of the Client in Latitude and Longitude
		public static string GetGeoLocation()
		{
			try
			{


				//GeoCoordinateWatcher watcher = new GeoCoordinateWatcher();

				//// Do not suppress prompt, and wait 1000 milliseconds to start.
				//watcher.TryStart(false, TimeSpan.FromMilliseconds(1000));

				//GeoCoordinate coord = watcher.Position.Location;

				//if (coord.IsUnknown != true)
				//{
				//	return "Lat:" + coord.Latitude + "|Long:" + coord.Longitude;
				//	//Console.WriteLine("Lat: {0}, Long: {1}",
				//	//	coord.Latitude,
				//	//	coord.Longitude);
				//}
				//else
				//{
				return "Unknown latitude and longitude.";
				//Console.WriteLine("Unknown latitude and longitude.");
				//}
			}
			catch (Exception e)
			{
				return "Unknown latitude and longitude with Exception:" + e.ToString();
			}
		}

		//Get IP Address of the Client
		public static string GetIPAdd()
		{
			try
			{


				string hostName = Dns.GetHostName(); // Retrive the Name of HOST  
				Console.WriteLine(hostName);
				// Get the IP  
				string myIP = Dns.GetHostByName(hostName).AddressList[0].ToString();
				return myIP;
				//Console.WriteLine("My IP Address is :" + myIP);
				//Console.ReadKey();
			}
			catch (Exception e)
			{
				return "Unknown IP with Exception:" + e.ToString();
			}
		}

		//Convert the List into Datatable
		public DataTable ConverttoDatatabelfromList<T>(List<T> items)
		{
			DataTable dataTable = new DataTable(typeof(T).Name);

			//Get all the properties
			PropertyInfo[] Props = typeof(T).GetProperties(BindingFlags.Public | BindingFlags.Instance);
			foreach (PropertyInfo prop in Props)
			{
				//Defining type of data column gives proper data table 
				Type type = (prop.PropertyType.IsGenericType && prop.PropertyType.GetGenericTypeDefinition() == typeof(Nullable<>) ? Nullable.GetUnderlyingType(prop.PropertyType) : prop.PropertyType);
				//Setting column names as Property names
				dataTable.Columns.Add(prop.Name, type);
			}
			foreach (T item in items)
			{
				object[] values = new object[Props.Length];
				for (int i = 0; i < Props.Length; i++)
				{
					//inserting property values to datatable rows
					values[i] = Props[i].GetValue(item, null);
				}
				dataTable.Rows.Add(values);
			}
			//put a breakpoint here and check datatable
			return dataTable;
		}

		//Encode Value to Base64
		public static string Base64Encode(string plainText)
		{
			byte[] plainTextBytes = System.Text.Encoding.UTF8.GetBytes(plainText);
			return System.Convert.ToBase64String(plainTextBytes);
		}

		//Decode Value to Base64
		public static string Base64Decode(string base64EncodedData)
		{
			byte[] base64EncodedBytes = System.Convert.FromBase64String(base64EncodedData);
			return System.Text.Encoding.UTF8.GetString(base64EncodedBytes);
		}

		public static string Encrypt(string toEncrypt, bool useHashing = true)
		{
			byte[] keyArray;
			byte[] toEncryptArray = UTF8Encoding.UTF8.GetBytes(toEncrypt);

			System.Configuration.AppSettingsReader settingsReader = new AppSettingsReader();
			// Get the key from config file
			string key = (string)settingsReader.GetValue("SecurityKey", typeof(string));
			//System.Windows.Forms.MessageBox.Show(key);
			if (useHashing)
			{
				MD5CryptoServiceProvider hashmd5 = new MD5CryptoServiceProvider();
				keyArray = hashmd5.ComputeHash(UTF8Encoding.UTF8.GetBytes(key));
				hashmd5.Clear();
			}
			else
			{
				keyArray = UTF8Encoding.UTF8.GetBytes(key);
			}

			TripleDESCryptoServiceProvider tdes = new TripleDESCryptoServiceProvider
			{
				Key = keyArray,
				Mode = CipherMode.ECB,
				Padding = PaddingMode.PKCS7
			};

			ICryptoTransform cTransform = tdes.CreateEncryptor();
			byte[] resultArray = cTransform.TransformFinalBlock(toEncryptArray, 0, toEncryptArray.Length);
			tdes.Clear();
			return Convert.ToBase64String(resultArray, 0, resultArray.Length);
		}

		public static string Decrypt(string cipherString, bool useHashing = true)
		{
			byte[] keyArray;
			byte[] toEncryptArray = Convert.FromBase64String(cipherString);

			System.Configuration.AppSettingsReader settingsReader = new AppSettingsReader();
			//Get your key from config file to open the lock!
			string key = (string)settingsReader.GetValue("SecurityKey", typeof(string));

			if (useHashing)
			{
				MD5CryptoServiceProvider hashmd5 = new MD5CryptoServiceProvider();
				keyArray = hashmd5.ComputeHash(UTF8Encoding.UTF8.GetBytes(key));
				hashmd5.Clear();
			}
			else
			{
				keyArray = UTF8Encoding.UTF8.GetBytes(key);
			}

			TripleDESCryptoServiceProvider tdes = new TripleDESCryptoServiceProvider
			{
				Key = keyArray,
				Mode = CipherMode.ECB,
				Padding = PaddingMode.PKCS7
			};

			ICryptoTransform cTransform = tdes.CreateDecryptor();
			byte[] resultArray = cTransform.TransformFinalBlock(toEncryptArray, 0, toEncryptArray.Length);

			tdes.Clear();
			return UTF8Encoding.UTF8.GetString(resultArray);
		}

		//Send Email To Client...!!!
		public static bool SendEmailOfException(string mailbody, List<string> email, string subject)
		{
			List<string> to = email; //To address   
			string From = "premlad961@gmail.com";
			MailMessage message = new MailMessage();
			foreach (string mutiemail in to)
			{
				message.To.Add(new MailAddress(mutiemail));
			}
			message.From = new MailAddress(From);
			message.Subject = subject;
			message.Body = mailbody;
			message.BodyEncoding = Encoding.UTF8;
			message.IsBodyHtml = true;
			SmtpClient client = new SmtpClient("smtp.gmail.com", 587); //Gmail smtp    
			System.Net.NetworkCredential basicCredential1 = new System.Net.NetworkCredential("premlad961@gmail.com", "Premlad961@#");
			//System.Net.NetworkCredential basicCredential1 = new System.Net.NetworkCredential("dreal.software.solutions@gmail.com", "DReal@@123");
			client.EnableSsl = true;
			client.UseDefaultCredentials = true;
			client.Credentials = basicCredential1;
			try
			{
				client.Send(message);
				return true;
			}

			catch (Exception ex)
			{
				throw ex;
			}


		}

		public static string ConnectToAPI(T_TOKEN_BE TKT)
		{
			try
			{

				int ReturnedValue = 0;
				using (SqlConnection connection = new SqlConnection(AbstractDatabaseFactory.MConnStr))
				{
					AbstractDatabaseFactory ab = new AbstractDatabaseFactory();
					// open the connection
					connection.Open();
					SqlTransaction transaction;
					transaction = connection.BeginTransaction(IsolationLevel.ReadCommitted);
					//int ReturnedValue = 0;
					string ACTION = "1";
					try
					{
						string[] parameters = new string[] { Convert.ToString(TKT.ID), Convert.ToString(TKT.USERID), Convert.ToString(Encrypt(TKT.TOKEMSG)), Convert.ToString(Encrypt(TKT.TOKENPATH)), Convert.ToString(TKT.ENTEREDBY), Convert.ToString(ACTION) };

						ReturnedValue = Convert.ToInt32(ab.RetreiveValueWithTransaction(transaction, "STP_TOKEN", parameters));
						transaction.Commit();
					}
					catch (Exception)
					{
						transaction.Rollback();
						throw;
					}
				}
				string json = Encrypt(ReturnedValue.ToString());

				//HttpWebRequest httpWebRequest = (HttpWebRequest)WebRequest.Create(System.Configuration.ConfigurationManager.AppSettings["APIKEYURL"] + "/api/apiBookingMaster/PostBookingIsPaid");
				HttpWebRequest httpWebRequest = (HttpWebRequest)WebRequest.Create(System.Configuration.ConfigurationManager.AppSettings["APIKEYURL"] + TKT.TOKENPATH + "?J=" + json.Trim());
				httpWebRequest.ContentType = "text/json";
				httpWebRequest.Method = "POST";
				using (StreamWriter streamWriter = new StreamWriter(httpWebRequest.GetRequestStream()))
				{
					streamWriter.Write(json);
					streamWriter.Flush();
					streamWriter.Close();
				}
				HttpWebResponse httpResponse = (HttpWebResponse)httpWebRequest.GetResponse();

				Stream stream = httpResponse.GetResponseStream();
				StreamReader re = new StreamReader(stream);
				string getjson = re.ReadToEnd();
				return getjson;
			}
			catch (Exception e)
			{
				throw;
			}
		}
	}
}