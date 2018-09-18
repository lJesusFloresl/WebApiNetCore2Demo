using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace WebApiNetCore2Demo.Utils
{
    /// <summary>
    /// Utilerias
    /// </summary>
    public static class Utilerias
    {
        /// <summary>
        /// Crea un objeto ServerResponse para las respuestas correctas
        /// </summary>
        /// <param name="datos"></param>
        /// <returns></returns>
        public static ServerResponse GenerarRespuestaCorrecta(object datos)
        {
            return new ServerResponse(true, Constantes.MENSAJE_OK, datos);
        }

        /// <summary>
        /// Crea un objeto ServerResponse para el manejo de excepciones
        /// </summary>
        /// <param name="ex"></param>
        /// <param name="datos"></param>
        /// <returns></returns>
        public static ServerResponse GenerarRespuestaExcepcion(Exception ex, object datos)
        {
            return new ServerResponse(false, string.Format(Constantes.FORMATO_MENSAJE_EXCEPCION, ex.ToString()), datos);
        }
    }
}
