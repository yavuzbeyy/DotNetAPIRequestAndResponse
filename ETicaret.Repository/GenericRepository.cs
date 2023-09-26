using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ETicaret.Repository
{
    public class GenericRepository <T> where T : class, new()
    {
        Context Db = new Context();
        public List<T> List()
        {
            return Db.Set<T>().ToList();
        }

        public void Add(T entity)
        {
            Db.Set<T>().Add(entity);
            Db.SaveChanges();
        }

        public void Delete(T entity)
        {
            Db.Set<T>().Remove(entity);
            Db.SaveChanges();
        }

        public virtual IQueryable<T> Queryable()
        {
            return Db.Set<T>().AsQueryable();
        }
    }

}
