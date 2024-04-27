using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Data.Entity.Validation;
using System.Linq;
using System.Linq.Expressions;
using System.Runtime.Remoting.Contexts;
using System.Text;
using System.Threading.Tasks;

namespace EJFilter.Repository
{
    public class EFGenericRepository<TEntity> : IRepository<TEntity>
        where TEntity : class
    {
        private DbContext Context { get; set; }

        public EFGenericRepository(DbContext inContext)
        {
            Context = inContext;
            Context.Database.CommandTimeout = 0;
        }

        public void Create(TEntity entity)
        {
            Context.Set<TEntity>().Add(entity);
        }

        public TEntity Read(Expression<Func<TEntity, bool>> predicate)
        {
            return Context.Set<TEntity>().Where(predicate).FirstOrDefault();
        }

        public IQueryable<TEntity> GetAll()
        {
            return Context.Set<TEntity>().AsQueryable();
        }

        public void Update(TEntity entity)
        {
            Context.Entry<TEntity>(entity).State = EntityState.Modified;
        }

        public void Update(TEntity entity, Expression<Func<TEntity, object>>[] updateProperties)
        {
            // Context.Configuration.ValidateOnSaveEnabled = false;

            Context.Entry<TEntity>(entity).State = EntityState.Unchanged;

            if (updateProperties != null)
            {
                foreach (var property in updateProperties)
                {
                    Context.Entry<TEntity>(entity).Property(property).IsModified = true;
                }
            }
        }

        public void Delete(TEntity entity)
        {
            Context.Entry<TEntity>(entity).State = EntityState.Deleted;
        }

        public void DeleteRange(TEntity entity, Expression<Func<TEntity, bool>> predicate)
        {
            Context.Set<TEntity>().RemoveRange(Context.Set<TEntity>().Where(predicate));
        }

        public int SaveChanges()
        {
            try
            {
                var result = Context.SaveChanges();
                return result;

            }

            catch (DbEntityValidationException e)
            {
                foreach (var eve in e.EntityValidationErrors)
                {
                    Console.WriteLine("Entity of type \"{0}\" in state \"{1}\" has the following validation errors:",
                        eve.Entry.Entity.GetType().Name, eve.Entry.State);
                    foreach (var ve in eve.ValidationErrors)
                    {
                        Console.WriteLine("- Property: \"{0}\", Error: \"{1}\"",
                            ve.PropertyName, ve.ErrorMessage);
                    }
                }
                throw;
            }

        }

        public TEntity GetById(int id)
        {
            return Context.Set<TEntity>().Find(id);
        }


        public IEnumerable<TEntity> GetWhere(Expression<Func<TEntity, bool>> predicate)
        {
            return Context.Set<TEntity>().Where(predicate);
        }

        public int CountWhere(Expression<Func<TEntity, bool>> predicate)
        {
            return Context.Set<TEntity>().Count(predicate);
        }

        public int CountAll()
        {
            return Context.Set<TEntity>().Count();
        }

        public void DeleteRange(Expression<Func<TEntity, bool>> predicate)
        {
            Context.Set<TEntity>().RemoveRange(Context.Set<TEntity>().Where(predicate));

        }

        public void View(TEntity entity)
        {
            throw new NotImplementedException();
        }
    }
}
