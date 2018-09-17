using System.Collections.Generic;

namespace WebApiNetCore2Demo.Interfaces
{
    /// <summary>
    /// Interfaz que implementa todos los metodos que debe tener cualquier repositorio
    /// </summary>
    /// <typeparam name="TKey"></typeparam>
    /// <typeparam name="TEntity"></typeparam>
    public interface IRepository<TKey, TEntity>
    {
        /// <summary>
        /// Agrega un nuevo registro
        /// </summary>
        /// <param name="entity"></param>
        void Add(TEntity entity);

        /// <summary>
        /// Elimina un registro en base a su id
        /// </summary>
        /// <param name="id"></param>
        void Delete(TKey id);

        /// <summary>
        /// Actualiza un registro
        /// </summary>
        /// <param name="entity"></param>
        void Update(TEntity entity);

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
