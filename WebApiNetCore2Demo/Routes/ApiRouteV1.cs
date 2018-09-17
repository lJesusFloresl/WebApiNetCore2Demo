namespace WebApiNetCore2Demo.Routes
{
    /// <summary>
    /// Clase utilizada para el manejo del versionamiento de la web api
    /// </summary>
    public static class ApiRouteV1
    {
        /// <summary>
        /// <para>api/v1</para>
        /// </summary>
        private const string ApiVersionRoute = "api/v1";

        /// <summary>
        /// <para>api/v1/[controller]</para>
        /// </summary>
        public const string ControllerRoute = ApiVersionRoute + "/[controller]";

        /// <summary>
        /// <para>application/json</para>
        /// </summary>
        public const string ApiResponseFormat = "application/json";
    }
}
