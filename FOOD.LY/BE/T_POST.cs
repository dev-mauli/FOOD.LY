using System;
using System.ComponentModel.DataAnnotations;

namespace FOOD.LY.BE
{
	public class T_POST
	{
		[Key]
		public string RID { get; set; }
		public string TITLE { get; set; }
		public string CAT { get; set; }
		public string DESCRIPTION { get; set; }
		public string PATH { get; set; }
		public string COUNTER { get; set; }
		public string FULLNAME { get; set; }
		public string LOGINID { get; set; }
		public string ENTEREDBY { get; set; }
		public string IMAGE { get; set; }
		public string VIDEO { get; set; }
		public string AGO { get; set; }
		public string ENTEREDON { get; set; }
		public string USERPHOTO { get; set; }
		public string INSTA { get; set; }
		public string FB { get; set; }
		public string YOUTUBE { get; set; }
	}
}