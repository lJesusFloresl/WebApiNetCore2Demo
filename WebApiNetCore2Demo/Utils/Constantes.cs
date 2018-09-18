namespace WebApiNetCore2Demo.Utils
{
    /// <summary>
    /// Constantes utilizadas en la api
    /// </summary>
    public static class Constantes
    {
        public const string MENSAJE_OK = "Ok";
        public const string MENSAJE_ERROR = "Oops!, Error inesperado";
        public const string MENSAJE_NOT_FOUND = "No encontrado";
        public const string MENSAJE_BAD_REQUEST = "Solicitud incorrecta";

        public const string FORMATO_LOGGER_DEBUG_VOID = "--- Metodo {method} llamado ---";
        public const string FORMATO_LOGGER_DEBUG_ID = "--- Metodo {method} llamado con {id} ---";
        public const string FORMATO_MENSAJE_EXCEPCION = MENSAJE_ERROR + ": {0}";
    }
}
