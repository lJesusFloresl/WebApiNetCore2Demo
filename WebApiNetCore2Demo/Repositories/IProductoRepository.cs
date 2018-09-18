using System.Collections.Generic;
using System.Threading.Tasks;
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
        Task<Producto> Add(Producto entity);

        /// <summary>
        /// Elimina un registro en base a su id
        /// </summary>
        /// <param name="id"></param>
        Task<bool> Delete(int id);

        /// <summary>
        /// Actualiza un registro
        /// </summary>
        /// <param name="entity"></param>
        Task<Producto> Update(Producto entity);

        /// <summary>
        /// Obtiene todos los registros
        /// </summary>
        /// <returns></returns>
        Task<IEnumerable<Producto>> GetAll();

        /// <summary>
        /// Obtiene un registro en base a su id
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        Task<Producto> GetById(int id);
    }
}
