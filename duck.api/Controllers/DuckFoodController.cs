using duck.model;
using duck.model.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using System.Web.Http.Cors;

namespace duck.api.Controllers
{
 
    public class DuckFoodController : ApiController
    {
        // GET: api/DuckFood
        public IEnumerable<DuckFood> Get()
        {
            DuckFoodModel dfm = new DuckFoodModel();

            return dfm.GetDuckFoods();
        }

        // GET: api/DuckFood/5
        public string Get(int id)
        {
            return "value";
        }

        // POST: api/DuckFood
        public void Post([FromBody]string value)
        {
        }

        // PUT: api/DuckFood/5
        public void Put(int id, [FromBody]string value)
        {
        }

        // DELETE: api/DuckFood/5
        public void Delete(int id)
        {
        }
    }
}
