using System.Collections.Generic;
using System.Threading.Tasks;
using WebApiNetCore2Demo.Utils;

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
        Task<IEnumerable<TEntity>> GetAll();

        /// <summary>
        /// Obtiene un registro en base a su id
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        Task<TEntity> GetById(TKey id);

        /// <summary>
        /// Guarda un registro en base de datos
        /// </summary>
        /// <param name="entity"></param>
        /// <returns></returns>
        Task<ServerResponse> Add(TEntity entity);

        /// <summary>
        /// Actualiza un registro en base de datos
        /// </summary>
        /// <param name="entity"></param>
        /// <returns></returns>
        Task<ServerResponse> Update(TEntity entity);

        /// <summary>
        /// Elimina un registro en base de datos
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        Task<ServerResponse> Delete(TKey id);
    }
}
