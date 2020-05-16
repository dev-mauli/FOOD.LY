using FOOD.LY.BE;
using FOOD.LY.DataAccessLayer;
using System;
using System.Collections.Generic;
using System.Data;
using System.IO;
using System.Linq;
using System.Web;
using System.Web.Helpers;
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


        [AcceptVerbs(HttpVerbs.Post)]
        public JsonResult UploadFile()
        {
            string filepathrtn = "";
            string _imgname = string.Empty;
            if (System.Web.HttpContext.Current.Request.Files.AllKeys.Any())
            {
                var pic = System.Web.HttpContext.Current.Request.Files["MyImages"];
                if (pic.ContentLength > 0)
                {
                    var fileName = Path.GetFileName(pic.FileName);
                    var _ext = Path.GetExtension(pic.FileName);

                    _imgname = Guid.NewGuid().ToString();
                    var _comPath = Server.MapPath("/UploadedImage/") + _imgname + _ext;
                    filepathrtn = "../UploadedImage/" + _imgname + _ext;

                    var path = _comPath;

                    // Saving Image in Original Mode
                    pic.SaveAs(path);

                    // resizing image
                    MemoryStream ms = new MemoryStream();
                    WebImage img = new WebImage(_comPath);

                    if (img.Width > 200)
                        img.Resize(200, 200);
                    img.Save(_comPath);
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