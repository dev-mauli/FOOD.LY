using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace FOOD.LY.BE
{
    public class M_RECIPE_BE
    {
         public int ID {get; set;}
         public string TITLE {get; set;}
         public string CAT {get; set;}
		 [AllowHtml]
		 public string DESCRIPTION {get; set;}
         public int ENTEREDBY {get; set;}
    }
}








