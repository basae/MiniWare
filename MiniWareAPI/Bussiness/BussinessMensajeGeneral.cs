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
                    throw new Exception("El id Debe ser nulo o 0");
                else
                    Msg.Id = 0;
                if (string.IsNullOrWhiteSpace(Msg.De))
                    throw new Exception("El Remitente Debe Tener un Valor");
                if (string.IsNullOrWhiteSpace(Msg.Descripcion))
                    throw new Exception("Debe Contener un Mensaje");
                if (Msg.Grado == null || Msg.Grado <= 0)
                    throw new Exception("Falta Asignar el Grado a donde se Mandara el Mensaje");
                if (string.IsNullOrWhiteSpace(Msg.Grupo) || Msg.Grupo.Length > 2)
                    throw new Exception("Debe Tener un Grupo a donde se Mandara el Mensaje y Debe ser mayor a 2 caracteres");
                Respuesta = repository.Save(Msg);
                if (Respuesta.Modelo != null && Convert.ToInt16(Respuesta.Modelo) > 0)
                {
                    Msg.Id = (int)Respuesta.Modelo;
                    ResponseAPI<User> GrupoAsignado = new BussinessUsuario().Get(Msg.Grado, Msg.Grupo);
                    if (GrupoAsignado.Error)
                        throw new Exception("Ocurrio un Error al Obtener los Alumnos del Grupo, el Mensaje no podra Enviarse");
                    ResponseAPI<MensajePersonal> StatusSave = new ResponseAPI<MensajePersonal>();
                    foreach (User usr in GrupoAsignado.List)
                    {
                        BussinessMensajePersonal objSaveMensaje = new BussinessMensajePersonal();
                        StatusSave = objSaveMensaje.Save(new MensajePersonal()
                        {
                            IdUsuario = usr.Id,
                            Mensaje = Msg
                        });
                        if (StatusSave.Error)
                        {
                            Respuesta.Modelo = Msg;
                            throw new Exception(StatusSave.Mensage);
                        }
                    }
                }
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
