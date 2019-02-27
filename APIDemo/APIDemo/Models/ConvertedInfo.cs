using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Web;

namespace APIDemo.Models
{
    [DataContract]
    public class ConvertedInfo
    {
        [DataMember(Name="name")]
        public string Name { get; set; }

        [DataMember(Name="value")]
        public string ConvertedValue { get; set; }
    }
}