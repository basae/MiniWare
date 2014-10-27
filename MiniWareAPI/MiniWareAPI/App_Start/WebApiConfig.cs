using System;
using System.Collections.Generic;
using System.Linq;
using System.Web.Http;

namespace MiniWareAPI
{
    public static class WebApiConfig
    {
        public static void Register(HttpConfiguration config)
        {
            config.Routes.MapHttpRoute(
                name: "DefaultApi",
                routeTemplate: "api/{controller}/{id}",
                defaults: new { id = RouteParameter.Optional }
            );

            config.Routes.MapHttpRoute(
                name: "Usuarios",
                routeTemplate: "api/{controller}/Grado/{grado}/Grupo/{grupo}",
                defaults: new { grado= RouteParameter.Optional,grupo=RouteParameter.Optional}
            );

<<<<<<< HEAD
            config.Routes.MapHttpRoute(
                name: "MensajesGenerales",
                routeTemplate: "api/{controller}/Fecha/{Date}",
                defaults: new { Date = RouteParameter.Optional }
            );
=======
>>>>>>> 8f895ee678f178ed6cc2c58a467f97b0dba90303
        }
    }
}
