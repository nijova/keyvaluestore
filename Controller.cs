﻿using System;
using System.Web.Http;

namespace KeyValueStore
{
    public class KvsController : ApiController
    {
        public IHttpActionResult Get(string key)
        {
            var keyHash = Helpers.CreateMD5(key);

            return Ok("got " + key);
            // return BadRequest();
        }

        public IHttpActionResult Put(string key, [FromBody]string value)
        {
            var keyHash = Helpers.CreateMD5(key);
            Repository.Put(keyHash, value);

            return Ok("put " + key);
            // return BadRequest();
        }

        public IHttpActionResult Delete(string key)
        {
            var keyHash = Helpers.CreateMD5(key);

            return Ok("deleted " + key);
            // return BadRequest();
        }

    }
}