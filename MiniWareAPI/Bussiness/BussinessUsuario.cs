using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Models;
using Data;

namespace Bussiness
{
    public class BussinessUsuario
    {
        private RepositorioUsuario repositorio;
        public BussinessUsuario()
        {
            repositorio = new RepositorioUsuario();
        }

        public ResponseAPI<User> Save(User Usuario)
        {
            ResponseAPI<User> Respuesta = new ResponseAPI<User>();
            try
            {
                if (Usuario == null)
                    throw new Exception("Objeto Usuario Con Valor Nulo");
                if (Usuario.Id.HasValue && Usuario.Id != 0)
                    throw new Exception("El id debe contener valor nulo o 0 para un nuevo registro");
                if (string.IsNullOrWhiteSpace(Usuario.Nombre))
                    throw new Exception("El nombre no puede estar vacio o nulo");
                if (string.IsNullOrWhiteSpace(Usuario.ApPaterno))
                    throw new Exception("El Apellido Paterno no puede estar vacio o nulo");
                if (string.IsNullOrWhiteSpace(Usuario.Username))
                    throw new Exception("El Nombre de Usuario no puede estar vacio o nulo");
                if (string.IsNullOrWhiteSpace(Usuario.Password))
                    throw new Exception("La Contraseña no puede estar vacia o nula");
                if (string.IsNullOrWhiteSpace(Usuario.Grupo))
                    throw new Exception("El Grupo no puede estar vacio o nulo");
                if (!Usuario.Grado.HasValue || Usuario.Grado==0)
                    throw new Exception("El Grado no puede estar vacio o ser 0");
                if (!Usuario.Id.HasValue)
                    Usuario.Id = 0;

                Respuesta = repositorio.Save(Usuario);
            }
            catch (Exception ex)
            {
                Respuesta.Error = true;
                Respuesta.Mensage = ex.Message;
            }
            return Respuesta;
        }

        public ResponseAPI<User> Update(User Usuario)
        {
            ResponseAPI<User> Respuesta = new ResponseAPI<User>();
            try
            {
                if (Usuario == null)
                    throw new Exception("Objeto Usuario Con Valor Nulo");
                if (!Usuario.Id.HasValue || Usuario.Id == 0)
                    throw new Exception("El id debe contener valor nulo o 0 para un nuevo registro");
                if (string.IsNullOrWhiteSpace(Usuario.Nombre))
                    throw new Exception("El nombre no puede estar vacio o nulo");
                if (string.IsNullOrWhiteSpace(Usuario.ApPaterno))
                    throw new Exception("El Apellido Paterno no puede estar vacio o nulo");
                if (string.IsNullOrWhiteSpace(Usuario.Username))
                    throw new Exception("El Nombre de Usuario no puede estar vacio o nulo");
                if (string.IsNullOrWhiteSpace(Usuario.Password))
                    throw new Exception("La Contraseña no puede estar vacia o nula");
                if (string.IsNullOrWhiteSpace(Usuario.Grupo))
                    throw new Exception("El Grupo no puede estar vacio o nulo");
                if (!Usuario.Grado.HasValue || Usuario.Grado == 0)
                    throw new Exception("El Grado no puede estar vacio o ser 0");

                Respuesta = repositorio.Save(Usuario);
            }
            catch (Exception ex)
            {
                Respuesta.Error = true;
                Respuesta.Mensage = ex.Message;
            }
            return Respuesta;
        }

        public User Get(int id)
        {
            ResponseAPI<User> Respuesta = new ResponseAPI<User>();
            try
            {
                if (id == 0)
                    throw new Exception("Se debe espesificar un ID");
                
                Respuesta = repositorio.Get(id);
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
