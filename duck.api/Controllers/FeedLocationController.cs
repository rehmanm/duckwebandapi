using duck.model;
using duck.model.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace duck.api.Controllers
{
    public class FeedLocationController : ApiController
    {
        // GET: api/FeedLocation
        public IEnumerable<FeedLocation> Get()
        {
            FeedLocationModel flm = new FeedLocationModel();
            return flm.GetFeedLocations();
        }

        // GET: api/FeedLocation/5
        public string Get(int id)
        {
            return "value";
        }

        // POST: api/FeedLocation
        public void Post([FromBody]string value)
        {
        }

        // PUT: api/FeedLocation/5
        public void Put(int id, [FromBody]string value)
        {
        }

        // DELETE: api/FeedLocation/5
        public void Delete(int id)
        {
        }
    }
}
