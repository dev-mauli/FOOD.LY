using FOOD.LY.BE;
using FOOD.LY.DataAccessLayer;
using System;
using System.IO;
using System.Web;
using System.Web.Helpers;
using System.Web.Mvc;

namespace FOOD.LY.Controllers
{
	public class AddRecipeController : Controller
	{
		private readonly System.Web.Script.Serialization.JavaScriptSerializer serializer = new System.Web.Script.Serialization.JavaScriptSerializer();
		// GET: AddRecipe
		public ActionResult Index()
		{
			return View();
		}
		public ActionResult ADDRECEIPE()
		{
			return View();
		}


		[AcceptVerbs(HttpVerbs.Post)]
		public JsonResult UploadFile()
		{
			string filepathrtn = "";
			string _imgname = string.Empty;
			HttpFileCollectionBase files = Request.Files;

			for (int i = 0; i < files.Count; i++)
			{
				HttpPostedFile pic = System.Web.HttpContext.Current.Request.Files["MyImages" + i];
				if (pic.ContentLength > 0)
				{
					string fileName = Path.GetFileName(pic.FileName);
					string _ext = Path.GetExtension(pic.FileName);

					_imgname = Guid.NewGuid().ToString();
					string _comPath = Server.MapPath("/UploadedImage/") + _imgname + _ext;
					if (filepathrtn == "")
					{
						filepathrtn += "../UploadedImage/" + _imgname + _ext;
					}
					else
					{
						filepathrtn += "|../UploadedImage/" + _imgname + _ext;
					}
					string path = _comPath;
					// Saving Image in Original Mode
					pic.SaveAs(path);

					// resizing image
					//MemoryStream ms = new MemoryStream();
					//WebImage img = new WebImage(_comPath);

					//if (img.Width > 200)
					//{
					//	img.Resize(200, 200);
					//}

					//img.Save(_comPath);
					// end resize
				}
			}

			return Json(Convert.ToString(filepathrtn), JsonRequestBehavior.AllowGet);
		}

		[HttpPost]
		[ValidateInput(false)]
		public ActionResult SAVE(string mdl)
		{
			try
			{
				M_RECIPE_BE __mdl = serializer.Deserialize<M_RECIPE_BE>(mdl);
				__mdl.ENTEREDBY = Convert.ToInt32(Session[SessionKeys.LOGINID]);
				T_TOKEN_BE api = new T_TOKEN_BE
				{
					TOKENPATH = "/api/AddRecipe/AddRecipe",
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