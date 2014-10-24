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
    public class MensajeGeneralController : ApiController
    {
        private BussinessMensajeGeneral _repository = new BussinessMensajeGeneral();
        // GET api/mensajegeneral
        public IEnumerable<MensajeGeneral> Get(DateTime Date)
        {
            ResponseAPI<MensajeGeneral> Respuesta = _repository.Get(Date);
            if (Respuesta.Error)
                throw new HttpResponseException(Request.CreateErrorResponse(HttpStatusCode.BadRequest, Respuesta.Mensage));
            return Respuesta.List;
        }

        // GET api/mensajegeneral/5
        public string Get(int id)
        {
            return "value";
        }

        // POST api/mensajegeneral
        public bool Post([FromBody]MensajeGeneral msg)
        {
            ResponseAPI<MensajeGeneral> Respuesta = _repository.Save(msg);
            if (Respuesta.Error)
                throw new HttpResponseException(Request.CreateErrorResponse(HttpStatusCode.BadRequest, Respuesta.Mensage));
            return true;
        }

        // PUT api/mensajegeneral/5
        public void Put(int id, [FromBody]string value)
        {
        }

        // DELETE api/mensajegeneral/5
        public void Delete(int id)
        {
        }
    }
}
