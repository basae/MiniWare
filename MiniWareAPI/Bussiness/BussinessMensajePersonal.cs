using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Models;
using Data;

namespace Bussiness
{
    public class BussinessMensajePersonal
    {
        private RepositorioMensajePersonal _repositorio;
        public BussinessMensajePersonal()
        {
            _repositorio = new RepositorioMensajePersonal();
        }

        public ResponseAPI<MensajePersonal> Save(MensajePersonal msg)
        {
            ResponseAPI<MensajePersonal> Respuesta = new ResponseAPI<MensajePersonal>();
            try
            {
                if (!msg.IdUsuario.HasValue)
                    throw new Exception("El Id del Alumno es Requerido");
                if (msg.Mensaje!=null && !msg.Mensaje.Id.HasValue)
                    throw new Exception("Es Necesario el Id del Mensaje General");
                Respuesta = _repositorio.Save(msg);
                if (Respuesta.Error)
                    throw new Exception(Respuesta.Mensage);
            }
            catch (Exception ex)
            {
                Respuesta.Error = true;
                Respuesta.Mensage = ex.Message;

            }
            return Respuesta;

        }

        public ResponseAPI<MensajePersonal> Get(int id)
        {
            ResponseAPI<MensajePersonal> Respuesta = new ResponseAPI<MensajePersonal>();
            try
            {
                if (id==null || id==0)
                    throw new Exception("El Id del Alumno es Requerido");
                
                Respuesta = _repositorio.Get(id);
                if (Respuesta.Error)
                    throw new Exception(Respuesta.Mensage);
            }
            catch (Exception ex)
            {
                Respuesta.Error = true;
                Respuesta.Mensage = ex.Message;

            }
            return Respuesta;

        }

    }
}
