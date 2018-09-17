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
        /// <para>Web API Net Core 2.1 v1</para>
        /// </summary>
        public const string EndpointDescriptionV1 = "Web API Net Core 2.1 v1";

        /// <summary>
        /// <para>/swagger/v1/swagger.json</para>
        /// </summary>
        public const string EndpointUrlV1 = "/swagger/v1/swagger.json";

        /// <summary>
        /// <para>Web API Net Core 2.1 v2</para>
        /// </summary>
        public const string EndpointDescriptionV2 = "Web API Net Core 2.1 v2";

        /// <summary>
        /// <para>/swagger/v1/swagger.json</para>
        /// </summary>
        public const string EndpointUrlV2 = "/swagger/v2/swagger.json";

        /// <summary>
        /// <para>Jesus Flores</para>
        /// </summary>
        public const string ContactName = "Jesus Flores";

        /// <summary>
        /// <para>v1</para>
        /// </summary>
        public const string DocNameV1 = "v1";

        /// <summary>
        /// <para>v2</para>
        /// </summary>
        public const string DocNameV2 = "v2";

        /// <summary>
        /// <para>Web API Net Core 2.1</para>
        /// </summary>
        public const string DocInfoTitle = "Web API Net Core 2.1";

        /// <summary>
        /// <para>v1</para>
        /// </summary>
        public const string DocInfoVersionV1 = "v1";

        /// <summary>
        /// <para>v2</para>
        /// </summary>
        public const string DocInfoVersionV2 = "v2";

        /// <summary>
        /// <para>Ejemplo de Web API en ASP.NET Core 2</para>
        /// </summary>
        public const string DocInfoDescription = "Ejemplo de Web API en ASP.NET Core 2";
    }
}
