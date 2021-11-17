using SaveFood.Models;
using SaveFood.Persistence;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;

namespace SaveFood.Repositories
{
    public class UserRepository : IUserRepository
    {
        private readonly SaveFoodContext _context;
        public UserRepository(SaveFoodContext context)
        {
            _context = context;
        }
        public void Create(User entity)
        {
            entity.GenerateSalt();
            entity.EncryptPassword();
            _context.Users.Add(entity);
        }

        public void Delete(int id)
        {
            throw new NotImplementedException();
        }

        public IList<User> List()
        {
            return _context.Users.ToList();
        }

        public void Save()
        {
            _context.SaveChanges();
        }

        public IList<User> SearchBy(Expression<Func<User, bool>> filter)
        {
            throw new NotImplementedException();
        }

        public User SearchByEmail(string email)
        {
            return _context.Users.Where(u => u.Email == email).FirstOrDefault();
        }

        public User SearchById(int id)
        {
            throw new NotImplementedException();
        }

        public void Update(User entity)
        {
            throw new NotImplementedException();
        }
    }
}
