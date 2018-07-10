using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace BlogSite.Data.InfraStructure
{
    public interface IRepository<T> where T : class
    {
        IEnumerable<T> GetAll();

        T GetByID(int ID);

        T Get(Expression<Func<T, bool>> expression);

        IQueryable<T> GetMany(Expression<Func<T, bool>> expression);

        void Insert(T obj);

        void Update(T obj);

        void Delete(int ID);

        int Count();

        void Save();
    }
}
