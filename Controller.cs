using System.Web.Http;

namespace KeyValueStore
{
    public class KvsController : ApiController
    {
        public IHttpActionResult Get(string key)
        {
            var keyHash = Helpers.CreateMD5(key);
            var entry = Repository.GetByKey(keyHash);
            if (!string.IsNullOrWhiteSpace(entry))
            {
                return Ok(entry);
            }
            return NotFound();
        }

        public IHttpActionResult Put(string key, [FromBody]string value)
        {   
            var keyHash = Helpers.CreateMD5(key);
            if (Repository.Put(keyHash, value))
            {
                return Ok();
            }
            return BadRequest();
        }

        public IHttpActionResult Delete(string key)
        {
            var keyHash = Helpers.CreateMD5(key);
            if (Repository.Delete(keyHash))
            {
                return Ok();
            }
            return NotFound();
        }

    }
}