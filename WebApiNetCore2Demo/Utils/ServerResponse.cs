namespace WebApiNetCore2Demo.Utils
{
    /// <summary>
    /// Clase para manejar las respuestas
    /// </summary>
    /// <typeparam name="TEntity"></typeparam>
    public class ServerResponse
    {
        public bool exito { get; set; }
        public string mensaje { get; set; }
        public object datos { get; set; }

        public ServerResponse() { }
        public ServerResponse(bool exito, string mensaje, object datos)
        {
            this.exito = exito;
            this.mensaje = mensaje;
            this.datos = datos;
        }
    }
}
