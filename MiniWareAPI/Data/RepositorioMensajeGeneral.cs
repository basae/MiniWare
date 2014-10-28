using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Models;
using System.Data.SqlClient;
using System.Data;

namespace Data
{
    public class RepositorioMensajeGeneral:RepositorioBase
    {
        public ResponseAPI<MensajeGeneral> Save(MensajeGeneral Msg)
        {
            ResponseAPI<MensajeGeneral> Respuesta = new ResponseAPI<MensajeGeneral>();
            try
            {
                using (Conexion)
                {
                    Conexion.Open();
                    using (SqlCommand cmd = new SqlCommand("SP_I_MENSAJEGENERAL", Conexion))
                    {
                        cmd.CommandType = CommandType.StoredProcedure;
                        cmd.Parameters.AddWithValue("@Id", Msg.Id);
                        cmd.Parameters.AddWithValue("@Descripcion", Msg.Descripcion);
                        cmd.Parameters.AddWithValue("@De", Msg.De);
                        cmd.Parameters.AddWithValue("@FechaCierre", Msg.FechaCierre);
                        cmd.Parameters.AddWithValue("@Grado", Msg.Grado);
                        cmd.Parameters.AddWithValue("@Grupo", Msg.Grupo);
                        cmd.Parameters["@Id"].Direction = ParameterDirection.InputOutput;
                        cmd.ExecuteNonQuery();
                        Respuesta.Modelo = cmd.Parameters["@Id"].Value;
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

        public ResponseAPI<MensajeGeneral> Get(DateTime? date)
        {
            ResponseAPI<MensajeGeneral> Respuesta = new ResponseAPI<MensajeGeneral>();
            try
            {
                using (Conexion)
                {
                    Conexion.Open();
                    using (SqlCommand cmd = new SqlCommand("SP_S_GetMensagesGeneralesByDay", Conexion))
                    {
                        cmd.CommandType = CommandType.StoredProcedure;
                        cmd.Parameters.AddWithValue("@Date", date);
                        SqlDataAdapter adapter = new SqlDataAdapter(cmd);
                        DataTable dt = new DataTable();
                        adapter.Fill(dt);
                        Respuesta.List = from row in dt.Rows.Cast<DataRow>()
                                         select new MensajeGeneral
                                         {
                                             Id=(int)row["Id"],
                                             De=(string)row["De"],
                                             Descripcion=(string)row["Descripcion"],
                                             FechaCierre=(DateTime)row["FechaCierre"],
                                             Grado=(row["Grado"]==DBNull.Value)?0:(int)row["Grado"],
                                             Grupo=(row["Grupo"]==DBNull.Value)?"":(string)row["Grupo"],
                                             FechaCreacion=(DateTime)row["FechaCreacion"]
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

        
        public ResponseAPI<MensajeGeneral> Get(int id)
        {
            ResponseAPI<MensajeGeneral> Respuesta = new ResponseAPI<MensajeGeneral>();
            try
            {
                using (Conexion)
                {
                    Conexion.Open();
                    using (SqlCommand cmd = new SqlCommand("SP_S_MensajesGeneralById", Conexion))
                    {
                        cmd.CommandType = CommandType.StoredProcedure;
                        cmd.Parameters.AddWithValue("@IdMensaje", id);
                        SqlDataAdapter adapter = new SqlDataAdapter(cmd);
                        DataTable dt = new DataTable();
                        adapter.Fill(dt);
                        Respuesta.Modelo = new MensajeGeneral
                                         {
                                             Id=(int)dt.Rows[0]["Id"],
                                             De = (string)dt.Rows[0]["De"],
                                             Descripcion = (string)dt.Rows[0]["Descripcion"],
                                             FechaCierre = (DateTime)dt.Rows[0]["FechaCierre"],
                                             FechaCreacion=(DateTime)dt.Rows[0]["FechaCreacion"],
                                             Grado=(int)dt.Rows[0]["Grado"],
                                             Grupo=(string)dt.Rows[0]["Grupo"]
                                         };
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
