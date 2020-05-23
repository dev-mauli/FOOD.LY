using System.Web.Mvc;

namespace FOOD.LY.BE
{
	public class M_RECIPE_BE
	{
		public int ID { get; set; }
		public string TITLE { get; set; }
		public string CAT { get; set; }
		public string PATH { get; set; }
		[AllowHtml]
		public string DESCRIPTION { get; set; }
		public string IMAGE { get; set; }
		public string VIDEO { get; set; }
		public int ENTEREDBY { get; set; }
	}
}








