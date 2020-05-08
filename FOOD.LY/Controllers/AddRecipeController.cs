using FOOD.LY.BE;
using FOOD.LY.DataAccessLayer;
using System;
using System.Collections.Generic;
using System.Data;
using System.Web.Mvc;

namespace FOOD.LY.Controllers
{
    public class AddRecipeController : Controller
    {
        // GET: AddRecipe
        public ActionResult Index()
        {
            return View();
        }
        public ActionResult ADDRECEIPE()
        {
            return View();
        }

        [HttpPost]
        public ActionResult SAVE(string mdl)
        {
            try
            {
                System.Web.Script.Serialization.JavaScriptSerializer serializer = new System.Web.Script.Serialization.JavaScriptSerializer();

                T_TOKEN_BE api = serializer.Deserialize<T_TOKEN_BE>(mdl);

                api.TOKENPATH = "/api/AddRecipe/AddRecipe";
                api.TOKEMSG = mdl;

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