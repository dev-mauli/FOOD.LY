using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace FOOD.LY.BE
{
    public class PROFILE_BE
    {
        [Key]
        public string ID { get; set; }
        public string FULLNAME { get; set; }
        public string EMAIL { get; set; }
        public string PASSWORD { get; set; }
        public string USERPHOTO { get; set; }
        public string INSTALINK { get; set; }
        public string FBLINK { get; set; }
        public string YOUTUBELINK { get; set; }
        public string MOBILENO { get; set; }
        public string ISBLOCK { get; set; }
        public string BLOCKBY { get; set; }
        public string ISVERIFIED { get; set; }
        public string ENTEREDBY { get; set; }
        public DateTime ENTEREDON { get; set; }
        public string ADMIN { get; set; }
        public string ACTIVE { get; set; }
    }
}