using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using RESTApp.GoogleAPI;

namespace RESTApp.Controllers
{
    public class FireBaseMessageController : ApiController
    {
        //todo remove to config ...
        private static string SERVER_KEY = "AAAAK4i1ZVc:APA91bFiG1VeSR7pVUpOvvqdspp4BlPxO46uvPB7uoKal8evatTr0-qQ1L_S6phJA74IEPff4Pa7FIT-xiNDIdxl_T0NSNO9HeIm1BlW1_AmaTR_rsCZSUs4doF0oPOFAModJRRYqfcU";
        private static string SENDER_ID = "186977183063";
        // GET: api/FireBaseMessage
        public IEnumerable<string> Get()
        {
            
            return new string[] { "value1", "value2" };
        }

        // GET: api/FireBaseMessage/5
        public string Get(int id)
        {
           
            return "value";
        }

        // POST: api/FireBaseMessage
        public FCMResponse Post(FireBaseMessage fireBaseMessage)
        {
            return new FireBaseClient().send(SERVER_KEY, SENDER_ID, fireBaseMessage.To, fireBaseMessage.Title, fireBaseMessage.Body);

        }

        // PUT: api/FireBaseMessage/5
        public void Put(int id, [FromBody]string value)
        {
        }

        // DELETE: api/FireBaseMessage/5
        public void Delete(int id)
        {
        }
    }
}
