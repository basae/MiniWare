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
    public class MensajePersonalController : ApiController
    {
        // GET api/mensajepersonal
        private BussinessMensajePersonal _repositorio = new BussinessMensajePersonal();

        public IEnumerable<MensajeGeneral> Get(int id)
        {
            ResponseAPI<MensajePersonal> Respuesta = new ResponseAPI<MensajePersonal>();
            Respuesta = _repositorio.Get(id);
            if (Respuesta.Error)
                throw new HttpResponseException(Request.CreateErrorResponse(HttpStatusCode.BadRequest, Respuesta.Mensage));
            return Respuesta.List.Select(x => x.Mensaje);
        }


        // POST api/mensajepersonal
        public void Post([FromBody]string value)
        {
        }

        // PUT api/mensajepersonal/5
        public void Put(int id, [FromBody]string value)
        {
        }

        // DELETE api/mensajepersonal/5
        public void Delete(int id)
        {
        }
    }
}
