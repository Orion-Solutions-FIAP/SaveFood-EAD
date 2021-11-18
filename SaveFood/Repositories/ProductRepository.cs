using SaveFood.Models;
using SaveFood.Persistence;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;

namespace SaveFood.Repositories
{
    public class ProductRepository : IProductRepository
    {
        private readonly SaveFoodContext _context;
        public ProductRepository(SaveFoodContext context)
        {
            _context = context;
        }

        public void Create(Product entity)
        {
            _context.Products.Add(entity);
        }

        public void Delete(int id)
        {
            var product = _context.Products.Find(id);
            _context.Products.Remove(product);
        }

        public IList<Product> List()
        {
            return _context.Products.ToList();
        }

        public void Save()
        {
            _context.SaveChanges();
        }

        public IList<Product> SearchBy(Expression<Func<Product, bool>> filter)
        {
            throw new NotImplementedException();
        }

        public Product SearchById(int id)
        {
            return _context.Products.AsNoTracking().Include(p => p.Storage).Include(p => p.Category)
                .FirstOrDefault(p => p.Id == id); ;
        }

        public IList<Product> SearchByUserIdAndStatus(int userId, Status status = Status.Enabled)
        {
            return _context.Products.Include(p => p.Storage).Include(p => p.Category)
                    .Where(p => p.UserId == userId && p.Status == status).ToList();
        }

        public void Update(Product entity)
        {
            _context.Products.Update(entity);
        }
    }
}
