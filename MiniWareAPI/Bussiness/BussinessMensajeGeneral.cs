using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Models;
using Data;

namespace Bussiness
{
    public class BussinessMensajeGeneral
    {
        private RepositorioMensajeGeneral repository;
        public BussinessMensajeGeneral()
        {
            repository = new RepositorioMensajeGeneral();
        }

        public ResponseAPI<MensajeGeneral> Save(MensajeGeneral Msg)
        {
            ResponseAPI<MensajeGeneral> Respuesta = new ResponseAPI<MensajeGeneral>();
            try
            {
                if (Msg == null)
                    throw new Exception("El Objeto Mensaje es Nulo o Vacio");
                if (Msg.Id.HasValue && Msg.Id != 0)
                    throw new Exception("El id debe ser nulo o 0");
                else
                    Msg.Id = 0;
                if (string.IsNullOrWhiteSpace(Msg.De))
                    throw new Exception("El remitente debe tener un Valor");
                if (string.IsNullOrWhiteSpace(Msg.Descripcion))
                    throw new Exception("Debe contener un mensaje");
                Respuesta = repository.Save(Msg);
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

        public ResponseAPI<MensajeGeneral> Get(DateTime? Date)
        {
            ResponseAPI<MensajeGeneral> Respuesta = new ResponseAPI<MensajeGeneral>();
            try
            {
                if (!Date.HasValue)
                    throw new Exception("Debe establecer una fecha de Consulta");
                Respuesta = repository.Get(Date);
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
