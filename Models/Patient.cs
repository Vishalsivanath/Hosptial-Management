using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace HosptialMangement1.Models
{
    public class Patient
    {
        public int Pid { get; set; }
        public string Fname { get; set; }
        public string Lname { get; set; }
        public int Age { get; set; }
        public string Bg { get; set; }
    }
}