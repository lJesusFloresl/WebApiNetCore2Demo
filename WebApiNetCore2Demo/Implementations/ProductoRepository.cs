using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
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

        public void Add(Producto entity)
        {
            context.Entry(entity).State = EntityState.Added;
            context.SaveChanges();
        }

        public void Delete(int id)
        {
            var entity = context.Producto.FirstOrDefault(e => e.Id == id);
            if (entity != null)
            {
                context.Entry(entity).State = EntityState.Deleted;
                context.SaveChanges();
            }
        }

        public IEnumerable<Producto> GetAll()
        {
            return context.Producto.ToList();
        }

        public Producto GetById(int id)
        {
            return context.Producto.FirstOrDefault(e => e.Id == id);
        }

        public void Update(Producto entity)
        {
            context.Entry(entity).State = EntityState.Modified;
            context.SaveChanges();
        }
    }
}
