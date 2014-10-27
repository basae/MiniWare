using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Models;
using System.Data.SqlClient;
using System.Data;

namespace Data
{
    public class RepositorioMensajePersonal:RepositorioBase
    {
        public ResponseAPI<MensajePersonal> Save(MensajePersonal msg)
        {
            ResponseAPI<MensajePersonal> Respuesta = new ResponseAPI<MensajePersonal>();
            try
            {
                using (Conexion)
                {
                    Conexion.Open();
                    using (SqlCommand cmd = new SqlCommand("SP_I_MENSAJEPERSONAL", Conexion))
                    {
                        cmd.CommandType = CommandType.StoredProcedure;
                        cmd.Parameters.AddWithValue("@IdMensajeGeneral", msg.Mensaje.Id);
                        cmd.Parameters.AddWithValue("@IdUsuario", msg.IdUsuario);
                        cmd.ExecuteNonQuery();
                    }
                }
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
