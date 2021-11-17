using System;
using System.Collections.Generic;
using System.Linq.Expressions;

namespace SaveFood.Repositories
{
    public interface IRepositoryBase<T>
    {
        void Create(T entity);
        T SearchById(int id);
        void Update(T entity);
        void Delete(int id);
        IList<T> List();
        IList<T> SearchBy(Expression<Func<T, bool>> filter);
        void Save();
    }
}
