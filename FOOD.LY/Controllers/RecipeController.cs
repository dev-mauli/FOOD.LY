using FOOD.LY.BE;
using FOOD.LY.DataAccessLayer;
using System;
using System.Web.Mvc;

namespace FOOD.LY.Controllers
{
	public class RecipeController : Controller
	{
		private System.Web.Script.Serialization.JavaScriptSerializer serializer = new System.Web.Script.Serialization.JavaScriptSerializer();
		private readonly ClassConverterHelper dtl = new ClassConverterHelper();
		// GET: Recipe
		public ActionResult Index()
		{
			return View();
		}

		[HttpPost]
		public ActionResult SingleDetails(string mdl)
		{
			try
			{
				T_TOKEN_BE api = new T_TOKEN_BE
				{
					TOKENPATH = "/api/AddRecipe/SingleDetails",
					TOKEMSG = mdl
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