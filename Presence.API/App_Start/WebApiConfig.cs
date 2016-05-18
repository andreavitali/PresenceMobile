using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Reflection;
using System.Web.Http;
using System.Web.Http.ExceptionHandling;
using Autofac;
using Autofac.Integration.WebApi;
using Presence.API.Filters;
using Presence.DataServices;

namespace Presence.API
{
    public static class WebApiConfig
    {
        public static void Register(HttpConfiguration config)
        {
            // Dependencies
            var builder = new ContainerBuilder();
            builder.RegisterApiControllers(Assembly.GetExecutingAssembly());
            builder.RegisterWebApiFilterProvider(config);
            builder.RegisterType<GlobalExceptionFilter>().AsWebApiExceptionFilterFor<ApiController>();

            // Presence services
            string connString = ConfigurationManager.AppSettings["ConnectionStringName"];
            string iniFilesPath = ConfigurationManager.AppSettings["IniFilesPath"];
            builder.RegisterModule(new PresenceAutofacModule(connString, iniFilesPath));

            var container = builder.Build();
            var resolver = new AutofacWebApiDependencyResolver(container);
            config.DependencyResolver = resolver;

            // JSON
            config.Formatters.JsonFormatter.SupportedMediaTypes.Add(new System.Net.Http.Headers.MediaTypeHeaderValue("text/html"));

            // Web API routes
            config.MapHttpAttributeRoutes();
            config.Routes.MapHttpRoute(
                name: "DefaultApi",
                routeTemplate: "api/{controller}/{id}",
                defaults: new { id = RouteParameter.Optional }
            );
        }
    }
}
