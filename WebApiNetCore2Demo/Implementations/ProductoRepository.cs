using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WebApiNetCore2Demo.Models.Database;
using WebApiNetCore2Demo.Repositories;

namespace WebApiNetCore2Demo.Implementations
{
    public class ProductoRepository : IProductoRepository
    {
        private readonly ComprasContext context;

        public ProductoRepository(ComprasContext context)
        {
            this.context = context;
        }

        public async Task<Producto> Add(Producto entity)
        {
            context.Entry(entity).State = EntityState.Added;
            await context.SaveChangesAsync();
            return entity;
        }

        public async Task<bool> Delete(int id)
        {
            var entity = await context.Producto.FirstOrDefaultAsync(e => e.Id == id);
            if (entity != null)
            {
                context.Entry(entity).State = EntityState.Deleted;
                await context.SaveChangesAsync();
                return true;
            }
            else
                return false;
        }

        public async Task<IEnumerable<Producto>> GetAll()
        {
            return await context.Producto.ToListAsync();
        }

        public async Task<Producto> GetById(int id)
        {
            return await context.Producto.FirstOrDefaultAsync(e => e.Id == id);
        }

        public async Task<Producto> Update(Producto entity)
        {
            context.Entry(entity).State = EntityState.Modified;
            await context.SaveChangesAsync();
            return entity;
        }
    }
}
