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
        public IEnumerable<User> Get()
        {
            ResponseAPI<User> Respuesta = new ResponseAPI<User>();
            Respuesta = repository.Get();
            if (Respuesta.Error)
                throw new HttpResponseException(Request.CreateErrorResponse(HttpStatusCode.BadRequest, Respuesta.Mensage));
            return Respuesta.List;
        }

        // GET api/user/5
        public User Get(int id)
        {
            ResponseAPI<User> Respuesta = new ResponseAPI<User>();
            Respuesta = repository.Get(id);
            if(Respuesta.Error)
                throw new HttpResponseException(Request.CreateErrorResponse(HttpStatusCode.BadRequest, Respuesta.Mensage));
            return (User)Respuesta.Modelo;
        }

        public IEnumerable<User> Get(int grado,string grupo)
        {
            ResponseAPI<User> Respuesta = new ResponseAPI<User>();
            Respuesta = repository.Get(grado, grupo);
            if (Respuesta.Error)
                throw new HttpResponseException(Request.CreateErrorResponse(HttpStatusCode.BadRequest, Respuesta.Mensage));
            else
            return Respuesta.List;

        }
        // POST api/user
        public bool Post([FromBody]User Usuario)
        {
            
            ResponseAPI<User> Respuesta = repository.Save(Usuario);
            if (Respuesta.Error)
                throw new HttpResponseException(Request.CreateErrorResponse(HttpStatusCode.BadRequest, Respuesta.Mensage));
            return true;
        }

        // PUT api/user/5
        public bool Put([FromBody]User Usuario)
        {
            ResponseAPI<User> Respuesta = repository.Update(Usuario);
            if(Respuesta.Error)
                throw new HttpResponseException(Request.CreateErrorResponse(HttpStatusCode.BadRequest,Respuesta.Mensage));
            return true;
        }

        // DELETE api/user/5
        public void Delete(int id)
        {
        }
    }
}
