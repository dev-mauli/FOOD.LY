using FOOD.LY.BE;
using FOOD.LY.DataAccessLayer;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace FOOD.LY.Controllers
{
    public class ProfileController : Controller
    {
        private System.Web.Script.Serialization.JavaScriptSerializer serializer = new System.Web.Script.Serialization.JavaScriptSerializer();
        private ClassConverterHelper dtl = new ClassConverterHelper();
        // GET: Profile
        public ActionResult ProfileHome()
        {
            return View();
        }

        public ActionResult Index()
        {
            return View();
        }

        [HttpPost]
        public ActionResult Profiledetails()
        {
            T_LOGIN_BE p = new T_LOGIN_BE();
            p.ID = Convert.ToInt32(Session[SessionKeys.LOGINID]);

            T_TOKEN_BE api = new T_TOKEN_BE
            {
                TOKENPATH = "/api/Profile/ProfileGETdetails",
                TOKEMSG = serializer.Serialize(p),
            };

            string m_x_Result = ClassConverterHelper.ConnectToAPI(api);
            return Json(new { msg = m_x_Result }, JsonRequestBehavior.AllowGet);
        }


        [HttpPost]
        public ActionResult ProfileDetailsUpdate(string mdl)
        {
            try
            {
                T_LOGIN_BE __mdl = serializer.Deserialize<T_LOGIN_BE>(mdl);
                __mdl.ID = Convert.ToInt32(Session[SessionKeys.LOGINID]);

                T_TOKEN_BE api = new T_TOKEN_BE
                {
                    TOKENPATH = "/api/Profile/ProfileUPDATEdetails",
                    TOKEMSG = serializer.Serialize(__mdl),
                    ENTEREDBY = Convert.ToInt32(Session[SessionKeys.LOGINID])
                };

                string m_x_Result = ClassConverterHelper.ConnectToAPI(api);
                return Json(new { msg = m_x_Result }, JsonRequestBehavior.AllowGet);
            }
            catch (Exception)
            {
                throw;
            }
        }
    }
}