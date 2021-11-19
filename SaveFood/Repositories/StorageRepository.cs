using Microsoft.EntityFrameworkCore;
using SaveFood.Models;
using SaveFood.Persistence;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;

namespace SaveFood.Repositories
{
    public class StorageRepository : IStorageRepository
    {
        private readonly SaveFoodContext _context;
        public StorageRepository(SaveFoodContext context)
        {
            _context = context;
        }
        public void Create(Storage entity)
        {
            _context.Storages.Add(entity);
        }

        public void Delete(int id)
        {
            throw new NotImplementedException();
        }

        public bool Exist(Storage storage)
        {
            return _context.Storages.Where(s => s.Name.ToLower().Contains(storage.Name.ToLower()) && s.UserId == storage.UserId).Any();
        }

        public IList<Storage> List()
        {
            return _context.Storages.ToList();
        }

        public void Save()
        {
            _context.SaveChanges();
        }

        public IList<Storage> SearchBy(Expression<Func<Storage, bool>> filter)
        {
            throw new NotImplementedException();
        }

        public Storage SearchById(int id)
        {
            throw new NotImplementedException();
        }
        public IList<Storage> SearchByUserId(int userId)
        {
            return _context.Storages.Where(s => s.UserId == userId).ToList();
        }

        public void Update(Storage entity)
        {
            throw new NotImplementedException();
        }
    }
}
