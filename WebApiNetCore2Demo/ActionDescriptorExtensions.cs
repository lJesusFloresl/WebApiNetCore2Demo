using Microsoft.AspNetCore.Mvc.Abstractions;
using Microsoft.AspNetCore.Mvc.Versioning;
using System;
using System.Linq;

namespace WebApiNetCore2Demo
{
    /// <summary>
    /// Clase utilizada para manipular el control de versionamiento de la api
    /// </summary>
    public static class ActionDescriptorExtensions
    {
        /// <summary>
        /// Obtiene la version de la api
        /// </summary>
        /// <param name="actionDescriptor"></param>
        /// <returns></returns>
        public static ApiVersionModel GetApiVersion(this ActionDescriptor actionDescriptor)
        {
            return actionDescriptor?.Properties
              .Where((kvp) => ((Type)kvp.Key).Equals(typeof(ApiVersionModel)))
              .Select(kvp => kvp.Value as ApiVersionModel).FirstOrDefault();
        }
    }
}
