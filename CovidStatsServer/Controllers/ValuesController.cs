using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using Newtonsoft.Json;


namespace CovidStats.Controllers
{
    public class ValuesController : ApiController
    {
        public class PostObj
        {
            public int userId;
            public int id;
            public string title;
            public string body;
        }

        // GET api/values
        public List<PostObj> Get()
        {
            string url = "https://jsonplaceholder.typicode.com/posts";
            List<PostObj> items = null;

            HttpWebRequest httpWebRequest = (HttpWebRequest)WebRequest.Create(url);
            HttpWebResponse httpWebResponse = (HttpWebResponse)httpWebRequest.GetResponse();

            using (StreamReader streamReader = new StreamReader(httpWebResponse.GetResponseStream()))
            {
                string response = streamReader.ReadToEnd();
                items = JsonConvert.DeserializeObject<List<PostObj>>(response);
                return items;
            }

            return items;
        }

        // GET api/values/5
        public string Get(int id)
        {
            return "value";
        }

        // POST api/values
        public void Post([FromBody] string value)
        {
        }

        // PUT api/values/5
        public void Put(int id, [FromBody] string value)
        {
        }

        // DELETE api/values/5
        public void Delete(int id)
        {
        }
    }
}
