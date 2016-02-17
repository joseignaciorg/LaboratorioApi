using System;
using System.Collections.Generic;
using System.Linq;
using System.Web.Http;
using System.Web.Http.OData.Builder;
using System.Web.Http.OData.Extensions;
using DemoApiRest.Extensiones;
using DemoApiRest.Models;

namespace DemoApiRest
{
    public static class WebApiConfig
    {
        public static void Register(HttpConfiguration config)
        {
            // Web API configuration and services
            config.MessageHandlers.Add(new LogHandler());
            // Web API routes
            config.MapHttpAttributeRoutes();

            //Definir	el	encargado	de	serializar	los	objetos
            var json = config.Formatters.JsonFormatter;
            //Establecemos	que	queremos	mantener	las	referencias	en	el	formateo	
                                                json.SerializerSettings.PreserveReferencesHandling =
Newtonsoft.Json.PreserveReferencesHandling.Objects;
            //Deshabilitamos	la	serializacion	en	XML
            config.Formatters.Remove(config.Formatters.XmlFormatter);


            ODataConventionModelBuilder builder = new ODataConventionModelBuilder(); //registra los modelos de datos para all OData
            builder.EntitySet<Usuario>("Usuarios"); //conjunto de datos de cada una de las tablas que queremos mapear
            builder.EntitySet<Mensaje>("Mensaje");//conjunto de datos de cada una de las tablas que queremos mapear
            config.Routes.MapODataServiceRoute("odata", "odata", builder.GetEdmModel()); //la ruta cuando queremos utilizar OData

            config.Routes.MapHttpRoute(
                name: "DefaultApi",
                routeTemplate: "api/{controller}/{id}",
                defaults: new { id = RouteParameter.Optional }
            );
        }
    }
}
