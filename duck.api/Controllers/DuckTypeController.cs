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
    public class DuckTypeController : ApiController
    {
        // GET: api/DuckType
        public IEnumerable<DuckType> Get()
        {
            DuckTypeModel dtm = new DuckTypeModel();

            return dtm.GetDuckTypes();
        }

        // GET: api/DuckType/5
        public string Get(int id)
        {
            return "value";
        }

        // POST: api/DuckType
        public void Post([FromBody]string value)
        {
        }

        // PUT: api/DuckType/5
        public void Put(int id, [FromBody]string value)
        {
        }

        // DELETE: api/DuckType/5
        public void Delete(int id)
        {
        }
    }
}
