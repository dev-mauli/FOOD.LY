using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace FOOD.LY.BE
{
    public class T_LOGIN_BE
    {
		public int ID { get; set; }
		public string FULLNAME { get; set; }
		public string EMAIL { get; set; }
		public string PASSWORD { get; set; }
		public string USERPHOTO { get; set; }
		public string INSTALINK { get; set; }
		public string FBLINK { get; set; }
		public string YOUTUBELINK { get; set; }
		public string MOBILENO { get; set; }
		public string ISBLOCK { get; set; }
		public int BLOCKBY { get; set; }
		public string ISVERIFIED { get; set; }
		public int ENTEREDBY { get; set; }
		public DateTime ENTEREDON { get; set; }
		public string ADMIN { get; set; }
		public string ACTIVE { get; set; }

        public string OLDPASSWORD { get; set; }
    }
}