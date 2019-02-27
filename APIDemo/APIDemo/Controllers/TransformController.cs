using APIDemo.Models;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Runtime.Serialization;
using System.Security.Cryptography.X509Certificates;
using System.Web.Http;
using System.Web.Http.Cors;
using System.Web.Mvc;

namespace APIDemo.Controllers
{
    public class TransformController : ApiController
    {
        // GET: api/Transform
        public IEnumerable<string> Get()
        {
            return new string[] { "value1", "value2" };
        }

        // GET: api/Transform/5
        public string Get(int id)
        {
            return "value";
        }

        // POST: api/Transform
        //public void Post([FromBody]string value)
        //{
        //}

        // PUT: api/Transform/5
        public void Put(int id, [FromBody]string value)
        {
        }

        // DELETE: api/Transform/5
        public void Delete(int id)
        {
        }

        /// <summary>
        /// Method to convert a number into its equivalent curreny format
        /// </summary>
        /// <param name="value"></param>
        /// <returns></returns>
        [EnableCors(origins: "*", headers: "*", methods: "*")]
        public JsonResult Post([FromBody]RawInfo value)
        {
            try
            {
                var conveterInfo = new ConvertedInfo {Name = value.Name, ConvertedValue = value.Value.ToString()};

                decimal valueOfDecimal;
                if (Decimal.TryParse(value.Value.ToString(), out valueOfDecimal))

                {
                    conveterInfo.ConvertedValue = Utilities.Converter.NumberToWords(value.Value).ToUpper();
                    return new JsonResult
                        { Data = new Response { Status = "success", Code = HttpStatusCode.OK.ToString(), ConvertedInfoValues = conveterInfo } };
                }

               
            else
                 return new JsonResult { Data = new Response { Status = "error",Code = HttpStatusCode.BadRequest.ToString(), ConvertedInfoValues = null,Error = "The value cannot be converted to a decimal"} };
            }
            catch (Exception e)
            {
                return new JsonResult { Data = new Response { Code = HttpStatusCode.BadRequest.ToString(), ConvertedInfoValues = null,Error = e.InnerException.ToString()} };
            }
        }


       
       
    }

   
}
