using Microsoft.Owin.Security.OAuth;
using Newtonsoft.Json;
using System.Web.Http;

namespace OnlineShop
{
    public static class WebApiConfig
    {
        public static void Register(HttpConfiguration config)
        {
            // Prevent circular reference in HTTP response json 
            config.Formatters.JsonFormatter.SerializerSettings.ReferenceLoopHandling = ReferenceLoopHandling.Ignore;

            // Web API configuration and services
            // Configure Web API to use only bearer token authentication.
            config.SuppressDefaultHostAuthentication();
            config.Filters.Add(new HostAuthenticationFilter(OAuthDefaults.AuthenticationType));

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
