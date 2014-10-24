using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using Models;
using Bussiness;

namespace MiniWareAPI.Controllers
{
    public class UserController : ApiController
    {
        BussinessUsuario repository = new BussinessUsuario();
        // GET api/user
        public IEnumerable<string> Get()
        {
            return new string[] { "value1", "value2" };
        }

        // GET api/user/5
        public string Get(int id)
        {
            return "test";
        }

        // POST api/user
        public bool Post([FromBody]User Usuario)
        {
            
            ResponseAPI<User> Respuesta = repository.Save(Usuario);
            if (Respuesta.Error)
                throw new HttpResponseException(HttpStatusCode.BadRequest);
            return true;
        }

        // PUT api/user/5
        public void Put(int id, [FromBody]string value)
        {
        }

        // DELETE api/user/5
        public void Delete(int id)
        {
        }
    }
}
