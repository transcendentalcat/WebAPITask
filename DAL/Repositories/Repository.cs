using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DAL.Entities;
using DAL.Interfaces;

namespace DAL.Repositories
{
    public class Repository<T> : IRepository<T> where T : Entity
    {
        private GameStoreContext db;
        //private IQueryable<T> dbSet;

        public Repository(GameStoreContext context)
        {
            db = context;
            //dbSet = context.Set<T>();
        }

        public Repository()
        {
            db = new GameStoreContext();           
        }

        public void Create(T entity)
        {
            db.Set<T>().Add(entity);
            db.SaveChangesAsync();

        }

        public void Delete(int id)
        {
            var entity = db.Set<T>().Find(id);

            if (entity != null)

                db.Entry(entity).State = EntityState.Deleted;
            db.SaveChangesAsync();
        }

        public IEnumerable<T> Find(Func<T, bool> predicate)
        {          
            var result = db.Set<T>().Where(predicate).ToList();

            return result;
        }

        public T Get(int id)
        {
            T result = null;

            result = db.Set<T>().Find(id);

            return result;
        }

        public IEnumerable<T> GetAll()
        {
            var result = new List<T>();
            result = db.Set<T>().ToList();
            return result;
        }

        public void Update(T item)
        {
            db.Entry(item).State = EntityState.Modified;
            db.SaveChanges();
        }
    }
}
