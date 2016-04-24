using System;
using System.Collections.Generic;
using System.Linq;
using System.Web.Http;

namespace QcaugmenteBackend
{
    public static class WebApiConfig
    {
        public static void Register(HttpConfiguration config)
        {
            // Web API configuration and services
            config.Formatters.XmlFormatter.WriterSettings.OmitXmlDeclaration = false;
            config.Formatters.Remove(config.Formatters.JsonFormatter);
            // Web API routes
            config.MapHttpAttributeRoutes();

            config.Routes.MapHttpRoute(
                name: "DefaultApi",
                routeTemplate: "api/{controller}/{id}",
                defaults: new { id = RouteParameter.Optional }
            );

            config.Routes.MapHttpRoute(
                name: "LatLonRay",
                routeTemplate: "api/{controller}/{Latitude}/{Longitude}/{Rayon}"
            );
        }
    }
}
