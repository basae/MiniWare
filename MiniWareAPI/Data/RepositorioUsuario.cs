using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data.SqlClient;
using Models;
using System.Data;
using System.Configuration;

namespace Data
{
    public class RepositorioUsuario:RepositorioBase
    {
        /// <summary>
        /// Guarda o Actualiza un Usuario
        /// </summary>
        /// <param name="usuario"></param>
        /// <returns></returns>
        public ResponseAPI<User> Save(User usuario)
        {
            ResponseAPI<User> Respuesta = new ResponseAPI<User>();
            try
            {
                using (Conexion)
                {
                    Conexion.Open();
                    using (SqlCommand cmd = new SqlCommand("SP_IU_USER", Conexion))
                    {
                        cmd.CommandType = CommandType.StoredProcedure;
                        cmd.Parameters.AddWithValue("@Id", usuario.Id);
                        cmd.Parameters.AddWithValue("@Nombre", usuario.Nombre);
                        cmd.Parameters.AddWithValue("@ApPaterno", usuario.ApPaterno);
                        cmd.Parameters.AddWithValue("@ApMaterno", usuario.ApMaterno);
                        cmd.Parameters.AddWithValue("@Username", usuario.Username);
                        cmd.Parameters.AddWithValue("@Password", usuario.Password);
                        cmd.Parameters.AddWithValue("@Celular", usuario.Celular);
                        cmd.Parameters.AddWithValue("@Correo", usuario.Correo);
                        cmd.Parameters.AddWithValue("@Grado", usuario.Grado);
                        cmd.Parameters.AddWithValue("@Grupo", usuario.Grupo);

                        cmd.ExecuteNonQuery();
                    }
                }
            }
            catch (SqlException ex)
            {
                Respuesta.Error = true;
                Respuesta.Mensage = ex.Message;
            }
            catch (Exception ex)
            {
                Respuesta.Error = true;
                Respuesta.Mensage = ex.Message;
            }
            return Respuesta;
        }

        /// <summary>
        /// Extrae un Usuario de acuerdo al ID proporcionado
        /// </summary>
        /// <param name="Id"></param>
        /// <returns></returns>
        public ResponseAPI<User> Get(int Id)
        {
                        ResponseAPI<User> Respuesta = new ResponseAPI<User>();
            try
            {
                using (Conexion)
                {
                    Conexion.Open();
                    using (SqlCommand cmd = new SqlCommand("SP_S_User", Conexion))
                    {
                        cmd.CommandType = CommandType.StoredProcedure;
                        cmd.Parameters.AddWithValue("@Id", Id);
                        SqlDataAdapter adaptador = new SqlDataAdapter(cmd);
                        DataTable dt = new DataTable();
                        adaptador.Fill(dt);
                        Respuesta.Modelo=new User
                                         {
                                             Id=(int)dt.Rows[0]["Id"],
                                             Nombre = (string)dt.Rows[0]["Nombre"],
                                             ApPaterno = (string)dt.Rows[0]["ApPaterno"],
                                             ApMaterno = (string)dt.Rows[0]["ApMaterno"],
                                             Username = (string)dt.Rows[0]["Username"],
                                             Password = (string)dt.Rows[0]["Password"],
                                             Celular = (Int64)dt.Rows[0]["Celular"],
                                             Correo = (string)dt.Rows[0]["Correo"],
                                             Grado = (int)dt.Rows[0]["Grado"],
                                             Grupo = (string)dt.Rows[0]["Grupo"]
                                         };
                    }
                }
            }
            catch (SqlException ex)
            {
                Respuesta.Error = true;
                Respuesta.Mensage = ex.Message;
            }
            catch (Exception ex)
            {
                Respuesta.Error = true;
                Respuesta.Mensage = ex.Message;
            }
            return Respuesta;

        }

        /// <summary>
        /// Devuelve una Lista de usuarios con el mismo grado y grupo
        /// </summary>
        /// <param name="Grado"></param>
        /// <param name="Grupo"></param>
        /// <returns></returns>
        public ResponseAPI<User> Get(int Grado,string Grupo)
        {
            ResponseAPI<User> Respuesta = new ResponseAPI<User>();
            try
            {
                using (Conexion)
                {
                    Conexion.Open();
                    using (SqlCommand cmd = new SqlCommand("SP_S_UserByGroup", Conexion))
                    {
                        cmd.CommandType = CommandType.StoredProcedure;
                        cmd.Parameters.AddWithValue("@Grado", Grado);
                        cmd.Parameters.AddWithValue("@Grupo", Grupo);
                        SqlDataAdapter adaptador = new SqlDataAdapter(cmd);
                        DataTable dt = new DataTable();
                        adaptador.Fill(dt);
                         Respuesta.List= from row in dt.Rows.Cast<DataRow>()
                                         select new User
                                         {
                                             Id = (int)row["Id"],
                                             Nombre = (string)row["Nombre"],
                                             ApPaterno = (string)row["ApPaterno"],
                                             ApMaterno = (string)row["ApMaterno"],
                                             Username = (string)row["Username"],
                                             Password = (string)row["Password"],
                                             Celular = (Int64)row["Celular"],
                                             Correo = (string)row["Correo"],
                                             Grado = (int)row["Grado"],
                                             Grupo = (string)row["Grupo"]
                                         };
                         if (Respuesta.List.OfType<Exception>().Count() > 0)
                             throw new Exception(Respuesta.List.OfType<Exception>().FirstOrDefault().Message);
                    }
                }
            }
            catch (SqlException ex)
            {
                Respuesta.Error = true;
                Respuesta.Mensage = ex.Message;
            }
            catch (Exception ex)
            {
                Respuesta.Error = true;
                Respuesta.Mensage = ex.Message;
            }
            return Respuesta;

        }

        /// <summary>
        /// Selecciona todos los usuario de la BD
        /// </summary>
        /// <param name="Grado"></param>
        /// <param name="Grupo"></param>
        /// <returns></returns>
        public ResponseAPI<User> Get()
        {
            ResponseAPI<User> Respuesta = new ResponseAPI<User>();
            try
            {
                using (Conexion)
                {
                    Conexion.Open();
                    using (SqlCommand cmd = new SqlCommand("SP_S_Users", Conexion))
                    {
                        cmd.CommandType = CommandType.StoredProcedure;
                        SqlDataAdapter adaptador = new SqlDataAdapter(cmd);
                        DataTable dt = new DataTable();
                        adaptador.Fill(dt);
                        Respuesta.List = from row in dt.Rows.Cast<DataRow>()
                                         select new User
                                         {
                                             Id = (int)row["Id"],
                                             Nombre = (string)row["Nombre"],
                                             ApPaterno = (string)row["ApPaterno"],
                                             ApMaterno = (string)row["ApMaterno"],
                                             Username = (string)row["Username"],
                                             Password = (string)row["Password"],
                                             Celular = (Int64)row["Celular"],
                                             Correo = (string)row["Correo"],
                                             Grado = (int)row["Grado"],
                                             Grupo = (string)row["Grupo"]
                                         };
                        if (Respuesta.List.OfType<Exception>().Count() > 0)
                            throw new Exception(Respuesta.List.OfType<Exception>().FirstOrDefault().Message);
                    }
                }
            }
            catch (SqlException ex)
            {
                Respuesta.Error = true;
                Respuesta.Mensage = ex.Message;
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
