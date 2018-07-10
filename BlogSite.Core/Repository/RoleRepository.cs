using BlogSite.Core.InfraStructure;
using BlogSite.Data.DataContext;
using BlogSite.Data.Models;
using System;
using System.Collections.Generic;
using System.Data.Entity.Migrations;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace BlogSite.Core.Repository
{
    public class RoleRepository : IRoleRepository
    {
        private readonly BlogContext _context = new BlogContext();
        public int Count()
        {
            return _context.Role.Count();
        }

        public void Delete(int ID)
        {
            var Role = GetByID(ID);
            if (Role != null)
            {
                _context.Role.Remove(Role);
            }
        }

        public Role Get(Expression<Func<Role, bool>> expression)
        {
            return _context.Role.FirstOrDefault(expression);
        }

        public IEnumerable<Role> GetAll()
        {
            return _context.Role.Select(x => x);
        }

        public Role GetByID(int ID)
        {
            return _context.Role.FirstOrDefault(x => x.ID == ID);
        }

        public IQueryable<Role> GetMany(Expression<Func<Role, bool>> expression)
        {
            return _context.Role.Where(expression);
        }

        public void Insert(Role obj)
        {
            _context.Role.Add(obj);
        }

        public void Save()
        {
            _context.SaveChanges();
        }

        public void Update(Role obj)
        {
            _context.Role.AddOrUpdate(obj);
        }
    }
}
