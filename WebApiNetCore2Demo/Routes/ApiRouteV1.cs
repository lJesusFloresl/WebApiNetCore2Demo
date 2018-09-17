namespace WebApiNetCore2Demo.Routes
{
    /// <summary>
    /// Clase utilizada para el manejo del versionamiento de la web api
    /// </summary>
    public static class ApiRouteV1
    {
        /// <summary>
        /// Obtiene ApiVersion
        /// </summary>
        public const string ApiVersion = "1.0";

        /// <summary>
        /// <para>api/[ApiVersion]</para>
        /// </summary>
        public const string ApiVersionRoute = "api/" + ApiVersion;

        /// <summary>
        /// <para>api/[ApiVersion]/[controller]</para>
        /// </summary>
        public const string ControllerRoute = ApiVersionRoute + "/[controller]";

        /// <summary>
        /// <para>application/json</para>
        /// </summary>
        public const string ApiResponseFormat = "application/json";

        /// <summary>
        /// <para>Web API Net Core 2.1 v[ApiVersion]</para>
        /// </summary>
        public const string SwaggerEndpointDescription = "Web API Net Core 2.1 v" + ApiVersion;

        /// <summary>
        /// <para>/swagger/v[ApiVersion]/swagger.json</para>
        /// </summary>
        public const string SwaggerEndpointUrl = "/swagger/" + ApiVersion + "/swagger.json";
    }
}
