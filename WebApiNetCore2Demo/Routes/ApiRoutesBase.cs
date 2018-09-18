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


        /// <summary>
        /// Obtiene la descripcion para el endpoint que utiliza swagger
        /// </summary>
        /// <param name="ApiVersion"></param>
        /// <returns></returns>
        public static string GetSwaggerEndpointDescription(string ApiVersion)
        {
            return "Web API Net Core 2.1 v" + ApiVersion;
        }

        /// <summary>
        /// Obtiene la url para el endpoint que utiliza swagger
        /// </summary>
        /// <param name="ApiVersion"></param>
        /// <returns></returns>
        public static string GetSwaggerEndpointUrl(string ApiVersion)
        {
            return "/swagger/" + ApiVersion + "/swagger.json";
        }
    }
}
