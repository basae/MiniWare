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

        public ResponseAPI<MensajePersonal> Get(int id)
        {
            ResponseAPI<MensajePersonal> Respuesta = new ResponseAPI<MensajePersonal>();
            try
            {
                using (Conexion)
                {
                    Conexion.Open();
                    using (SqlCommand cmd = new SqlCommand("SP_S_MensajesByAlumno", Conexion))
                    {
                        cmd.CommandType = CommandType.StoredProcedure;
                        cmd.Parameters.AddWithValue("@IdUsuario", id);
                        SqlDataAdapter adapter = new SqlDataAdapter(cmd);
                        DataTable dt = new DataTable();
                        adapter.Fill(dt);
                        Respuesta.List = from row in dt.Rows.Cast<DataRow>()
                                         select new MensajePersonal()
                                         {
                                             Id = (int)row["Id"],
                                             IdUsuario = (int)row["IdUsuario"],
                                             Visto = (bool)row["Visto"],
                                             Mensaje =(MensajeGeneral) new RepositorioMensajeGeneral().Get((int)row["IdMensajeGeneral"]).Modelo
                                         };
                        if (Respuesta.List.OfType<Exception>().Count() > 0)
                            throw new Exception(Respuesta.List.OfType<Exception>().FirstOrDefault().Message);
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
