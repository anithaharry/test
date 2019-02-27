using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace APIDemo.Models
{
    public class Response
    {
        public string Status { get; set; }
        public string Code { get; set; }
        public ConvertedInfo ConvertedInfoValues { get; set; }
        public string Error { get; set; }
    }
}