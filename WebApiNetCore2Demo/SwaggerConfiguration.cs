using Swashbuckle.AspNetCore.Swagger;
using Swashbuckle.AspNetCore.SwaggerGen;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace WebApiNetCore2Demo
{
    /// <summary>
    /// Contiene la configuracion de Swagger para la documentacion de la api
    /// </summary>
    public static class SwaggerConfiguration
    {
        /// <summary>
        /// <para>Jesus Flores</para>
        /// </summary>
        public const string ContactName = "Jesus Flores";

        /// <summary>
        /// <para>Web API Net Core 2.1</para>
        /// </summary>
        public const string DocInfoTitle = "Web API Net Core 2.1";

        /// <summary>
        /// <para>Ejemplo de Web API en ASP.NET Core 2</para>
        /// </summary>
        public const string DocInfoDescription = "Ejemplo de Web API en ASP.NET Core 2 con IoC y DI";

        /// <summary>
        /// <para>Web API Net Core 2.1</para>
        /// </summary>
        public const string EndpointDescription = "Web API Net Core 2.1";

        /// <summary>
        /// <para>Web API Net Core 2.1</para>
        /// </summary>
        public const string EndpointUrl = "/swagger/" + JsonVersion + "/swagger.json";

        /// <summary>
        /// <para>Web API Net Core 2.1</para>
        /// </summary>
        public const string JsonVersion = "v1";

        /// <summary>
        /// Obtiene la url del json de swagger en base a una version
        /// </summary>
        /// <param name="ApiVersion"></param>
        /// <returns></returns>
        public static string GetEndpointUrl(string ApiVersion)
        {
            return "/swagger/" + ApiVersion + "/swagger.json";
        }
    }
}
