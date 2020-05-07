using FOOD.LY.BE;
using FOOD.LY.DataAccessLayer;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace FOOD.LY.Controllers
{

    public class HomeController : Controller
    {

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
                System.Web.Script.Serialization.JavaScriptSerializer serializer = new System.Web.Script.Serialization.JavaScriptSerializer();

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
                        return RedirectToAction("Login", "Home");
                    }
                    else
                    {
                        return RedirectToAction("Index", "Home");
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
    }
}