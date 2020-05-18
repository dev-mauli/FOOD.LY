using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace FOOD.LY.Controllers
{
    public class ProfileController : Controller
    {
        // GET: Profile
        public ActionResult ProfileHome()
        {
            return View();
        }
    }
}