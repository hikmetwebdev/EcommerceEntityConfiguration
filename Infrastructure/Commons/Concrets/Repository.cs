using Infrastructure.Commons.Abstracts;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace Infrastructure.Commons.Concrets
{
    public abstract class Repository<T>:IRepository<T>
        where T : class
    {
        private readonly DbContext _db;
        private readonly DbSet<T> _table;
        protected Repository(DbContext db)
        {
            _db = db; 
            _table=_db.Set<T>();
        }
        public T Add(T model) 
        {
           _table.Add(model);
            Save();
            return model;
        }

        public T Edit(T model)
        {
          _table.Entry(model).State=EntityState.Modified;
            return model;
        }

        public T Get(Expression<Func<T, bool>> predicate = null)
        {
            if (predicate == null)
            {
                return _table.FirstOrDefault();
            }
            var model=_table.FirstOrDefault(predicate);
            return model;
        }

        public IEnumerable<T> GetAll(Expression<Func<T, bool>> predicate = null)
        {
            if(predicate == null)
            {
               return _table.ToList();
            }
            var models=_table.Where(predicate).ToList();
            return models;
        }

        public void Remove(T model)
        {
            _table.Remove(model);
            Save();
        }

        public int Save()
        {
            return _db.SaveChanges();
        }
    }
}
