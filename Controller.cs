using System;
using System.Web.Http;

namespace KeyValueStore
{
    public class KvsController : ApiController
    {
        public IHttpActionResult Get(string key)
        {
            return Ok("got " + key);
            // return BadRequest();
        }
    }
}