using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DAL.Entities;

namespace DAL.Interfaces
{
    public interface IRepository<T> where T : Entity

    {
        IEnumerable<T> GetAll();

        T Get(string id);

        IEnumerable<T> Find(Func<T, Boolean> predicate);

        void Create(T entity);

        void Update(T entity);

        void Delete(string id);
    }
}
