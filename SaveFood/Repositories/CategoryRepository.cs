using Microsoft.EntityFrameworkCore;
using SaveFood.Models;
using SaveFood.Persistence;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;

namespace SaveFood.Repositories
{
    public class CategoryRepository : ICategoryRepository
    {
        private readonly SaveFoodContext _context;
        public CategoryRepository(SaveFoodContext context)
        {
            _context = context;
        }
        public void Create(Category entity)
        {
            _context.Categories.Add(entity);
        }

        public void Delete(int id)
        {
            throw new NotImplementedException();
        }

        public bool Exist(Category category)
        {
            return _context.Categories.Where(s => s.Name.ToLower().Contains(category.Name.ToLower()) && s.UserId == category.UserId).Any();

        }

        public IList<Category> List()
        {
            return _context.Categories.ToList();
        }

        public void Save()
        {
            _context.SaveChanges();
        }

        public IList<Category> SearchBy(Expression<Func<Category, bool>> filter)
        {
            throw new NotImplementedException();
        }

        public Category SearchById(int id)
        {
            throw new NotImplementedException();
        }

        public IList<Category> SearchByUserId(int userId)
        {
          return _context.Categories.Where(c => c.UserId == userId).ToList();
        }

        public void Update(Category entity)
        {
            throw new NotImplementedException();
        }
    }
}
