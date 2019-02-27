using Microsoft.VisualStudio.TestTools.UnitTesting;
using APIDemo.Controllers;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Net.Http;
using APIDemo.Models;

namespace APIDemo.Controllers.Tests
{
    [TestClass()]
    public class TransformControllerTests
    {
        [TestMethod()]
        public void PostTest()
        {
            var controller = new TransformController();
            RawInfo rawInfo = new RawInfo {Name = "Anita", Value = 123.45M};
            var response = controller.Post(rawInfo);
           Response  converted= response.Data as Response ;
           Assert.IsTrue(converted.ConvertedInfoValues.ConvertedValue.Equals("ONE HUNDRED AND TWENTY-THREE DOLLARS AND FORTY-FIVE CENTS"));
           Assert.IsTrue(converted.ConvertedInfoValues.Name.Equals(rawInfo.Name));
           Assert.IsNotNull(response.Data);
          
        }
    }
}