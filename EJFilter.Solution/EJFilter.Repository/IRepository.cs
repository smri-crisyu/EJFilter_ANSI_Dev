using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace EJFilter.Repository
{
    public interface IRepository<T>
    {
   
        void Create(T entity);

 
        T Read(Expression<Func<T, bool>> predicate);

        IEnumerable<T> GetWhere(Expression<Func<T, bool>> predicate);

        int CountWhere(Expression<Func<T, bool>> predicate);

        int CountAll();

        T GetById(int id);

  
        IQueryable<T> GetAll();

        void Update(T entity);

        void Delete(T entity);

        void DeleteRange(Expression<Func<T, bool>> predicate);


        int SaveChanges();
    }

}
