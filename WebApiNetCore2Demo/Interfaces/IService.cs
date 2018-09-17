using System.Collections.Generic;

namespace WebApiNetCore2Demo.Interfaces
{
    /// <summary>
    /// Interfaz que implementa todos los metodos que debe tener cualquier servicio
    /// </summary>
    /// <typeparam name="TKey"></typeparam>
    /// <typeparam name="TEntity"></typeparam>
    public interface IService<TKey, TEntity>
    {
        /// <summary>
        /// Obtiene todos los registros
        /// </summary>
        /// <returns></returns>
        IEnumerable<TEntity> GetAll();

        /// <summary>
        /// Obtiene un registro en base a su id
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        TEntity GetById(TKey id);
    }
}
