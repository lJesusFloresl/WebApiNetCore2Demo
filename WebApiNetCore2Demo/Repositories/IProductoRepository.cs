using System.Collections.Generic;
using WebApiNetCore2Demo.Models.Database;

namespace WebApiNetCore2Demo.Repositories
{
    /// <summary>
    /// Repositorio de Producto
    /// </summary>
    public interface IProductoRepository
    {
        /// <summary>
        /// Agrega un nuevo registro
        /// </summary>
        /// <param name="entity"></param>
        void Add(Producto entity);

        /// <summary>
        /// Elimina un registro en base a su id
        /// </summary>
        /// <param name="id"></param>
        void Delete(int id);

        /// <summary>
        /// Actualiza un registro
        /// </summary>
        /// <param name="entity"></param>
        void Update(Producto entity);

        /// <summary>
        /// Obtiene todos los registros
        /// </summary>
        /// <returns></returns>
        IEnumerable<Producto> GetAll();

        /// <summary>
        /// Obtiene un registro en base a su id
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        Producto GetById(int id);
    }
}
