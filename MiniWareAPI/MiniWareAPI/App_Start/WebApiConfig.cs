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

            config.Routes.MapHttpRoute(
                name: "MensajesGenerales",
                routeTemplate: "api/{controller}/Fecha/{Date}",
                defaults: new { Date = RouteParameter.Optional }
            );
        }
    }
}
