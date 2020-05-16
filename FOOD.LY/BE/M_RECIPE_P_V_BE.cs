using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace FOOD.LY.BE
{
    public class M_RECIPE_P_V_BE
    {
         public string ID { get; set;}
         public string RID { get; set;}
         public string TYPE { get; set;}
         public HttpPostedFileWrapper PATH { get; set;}
         public string ENTEREDBY { get; set;}
    }
}
