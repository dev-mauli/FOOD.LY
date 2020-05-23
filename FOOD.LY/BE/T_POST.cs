using System;
using System.ComponentModel.DataAnnotations;

namespace FOOD.LY.BE
{
	public class T_POST
	{
		[Key]
		public int RID { get; set; }
		public string TITLE { get; set; }
		public string CAT { get; set; }
		public string DESCRIPTION { get; set; }
		public string PATH { get; set; }
		public int COUNTER { get; set; }
		public string FULLNAME { get; set; }
		public int LOGINID { get; set; }
		public int ENTEREDBY { get; set; }
		public string AGO { get; set; }
		public string IMAGE { get; set; }
		public string VIDEO { get; set; }
		public DateTime ENTEREDON { get; set; }
	}
}