using Microsoft.AspNet.WebApi.Extensions.Compression.Server;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http.Extensions.Compression.Core.Compressors;
using System.Web.Http;
using Cursos.Api.Filters;

namespace Cursos.Api
{
    public static class WebApiConfig
    {
        public static void Register(HttpConfiguration config)
        {
            // Web API configuration and services

            // Web API routes
            config.MapHttpAttributeRoutes();
            //config.EnableCors();
            config.Routes.MapHttpRoute(
              "DefaultApi",
              "services/{controller}/{id}",
              new { id = RouteParameter.Optional });
            config.MessageHandlers.Insert(0, new ServerCompressionHandler(new GZipCompressor(), new DeflateCompressor()));
            config.Filters.Add(new AuthenticationFilter());
        }
    }
}
