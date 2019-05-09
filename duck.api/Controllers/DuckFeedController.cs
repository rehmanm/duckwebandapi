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
    public class DuckFeedController : ApiController
    {
        // GET: api/DuckFeed
        public IEnumerable<DuckFeeding> Get()
        {

            DuckFeedingModel dfm = new DuckFeedingModel();
            return dfm.GetDuckFeedings();
        }

        // GET: api/DuckFeed/5
        public string Get(int id)
        {
            return "value";
        }

        // POST: api/DuckFeed
        public object Post([FromBody]DuckFeeding df )
        {
            DuckFeedingModel dfm = new DuckFeedingModel();

            //return Request.CreateResponse(HttpStatusCode.OK, new
            //{
            //    Status = dfm.SaveDuckFeeding(df)
            //});

            return dfm.SaveDuckFeeding(df);

        }

        // PUT: api/DuckFeed/5
        public void Put(int id, [FromBody]string value)
        {
        }

        // DELETE: api/DuckFeed/5
        public void Delete(int id)
        {
        }
    }
}
