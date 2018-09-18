namespace WebApiNetCore2Demo.Routes
{
    /// <summary>
    /// Clase que maneja las configuraciones de versionamiento de api
    /// </summary>
    public class ApiRoutesBase
    {
        /// <summary>
        /// <para>api/[ApiVersion]</para>
        /// </summary>
        public const string ApiVersionRoute = "api/{version:apiVersion}";

        /// <summary>
        /// <para>api/[ApiVersion]/[controller]</para>
        /// </summary>
        public const string ControllerRoute = ApiVersionRoute + "/[controller]";

        /// <summary>
        /// <para>application/json</para>
        /// </summary>
        public const string ApiResponseFormat = "application/json";
    }
}
