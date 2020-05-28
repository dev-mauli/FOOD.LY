using FOOD.LY.BE;
using FOOD.LY.DataAccessLayer;
using System;
using System.Collections.Generic;
using System.Data;
using System.Web.Mvc;

namespace FOOD.LY.Controllers
{

	public class HomeController : Controller
	{
		private System.Web.Script.Serialization.JavaScriptSerializer serializer = new System.Web.Script.Serialization.JavaScriptSerializer();
		private ClassConverterHelper dtl = new ClassConverterHelper();
		// GET: Home
		public ActionResult Index()
		{

			return View();
		}

		public ActionResult Main()
		{

			return View();
		}

		public ActionResult _PartialNav()
		{
			return PartialView();
		}

		public ActionResult _PartialIndex()
		{
			return PartialView();
		}

		public ActionResult Logout()
		{
			Session.Clear();
			Session.Abandon();
			Session[SessionKeys.FULLNAME] = null;
			Session[SessionKeys.LOGINID] = null;
			Session[SessionKeys.EMAIL] = null;
			return Json(new { msg = "1" }, JsonRequestBehavior.AllowGet);
		}

		[HttpPost]
		public ActionResult Register(string mdl)
		{
			try
			{
				System.Web.Script.Serialization.JavaScriptSerializer serializer = new System.Web.Script.Serialization.JavaScriptSerializer();

				T_TOKEN_BE api = serializer.Deserialize<T_TOKEN_BE>(mdl);

				api.TOKENPATH = "/api/Home/Register";
				api.TOKEMSG = mdl;

				string m_x_Result = ClassConverterHelper.ConnectToAPI(api);
				return Json(new { msg = m_x_Result }, JsonRequestBehavior.AllowGet);
			}
			catch (Exception)
			{
				throw;
			}
		}

		[HttpPost]
		public ActionResult Login(string mdl)
		{

			try
			{


				T_TOKEN_BE api = serializer.Deserialize<T_TOKEN_BE>(mdl);

				api.TOKENPATH = "/api/Home/Login";
				api.TOKEMSG = mdl;

				string m_x_Result = ClassConverterHelper.ConnectToAPI(api);


				DataTable dt = dtl.ConverttoDatatabelfromList(serializer.Deserialize<List<T_LOGIN_BE>>(m_x_Result));
				if (dt.Rows.Count > 0)
				{
					string UserName = dt.Rows[0]["FULLNAME"].ToString();
					string LOGINID = dt.Rows[0]["ID"].ToString();
					string EMAIL = dt.Rows[0]["EMAIL"].ToString();

					Session[SessionKeys.FULLNAME] = UserName;
					Session[SessionKeys.LOGINID] = LOGINID;
					Session[SessionKeys.EMAIL] = EMAIL;

					if (LOGINID == "" || LOGINID == null)
					{
						return Json(new { msg = "-1" }, JsonRequestBehavior.AllowGet);
					}
					else
					{
						return Json(new { msg = "1" }, JsonRequestBehavior.AllowGet);
					}
				}
				else
				{
					return Json(new { msg = "-1" }, JsonRequestBehavior.AllowGet);
				}
			}
			catch (Exception)
			{
				throw;
			}
		}

		[HttpPost]
		public ActionResult AllPost()
		{
			T_POST p = new T_POST();
			//if (Session[SessionKeys.LOGINID].ToString() == "" || Session[SessionKeys.LOGINID] == null)
			//{
				p.ENTEREDBY = "0";
			//}
			//else
			//{
			//	p.ENTEREDBY = Convert.ToInt32(Session[SessionKeys.LOGINID]);
			//}

			T_TOKEN_BE api = new T_TOKEN_BE
			{
				TOKENPATH = "/api/Home/AllHomeDetails",
				TOKEMSG = serializer.Serialize(p)
			};

			string m_x_Result = ClassConverterHelper.ConnectToAPI(api);
			return Json(new { msg = m_x_Result }, JsonRequestBehavior.AllowGet);
		}
	}
}