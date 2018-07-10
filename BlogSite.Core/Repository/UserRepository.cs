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
    public class UserRepository : IUserRepository
    {
        private readonly BlogContext _context = new BlogContext();
        public int Count()
        {
            return _context.User.Count();
        }

        public void Delete(int ID)
        {
            var User = GetByID(ID);
            if (User != null)
            {
                _context.User.Remove(User);
            }
        }

        public User Get(Expression<Func<User, bool>> expression)
        {
            return _context.User.FirstOrDefault(expression);
        }

        public IEnumerable<User> GetAll()
        {
            return _context.User.Select(x => x);
        }

        public User GetByID(int ID)
        {
            return _context.User.FirstOrDefault(x => x.ID == ID);
        }

        public IQueryable<User> GetMany(Expression<Func<User, bool>> expression)
        {
            return _context.User.Where(expression);
        }

        public void Insert(User obj)
        {
            _context.User.Add(obj);
        }

        public void Save()
        {
            _context.SaveChanges();
        }

        public void Update(User obj)
        {
            _context.User.AddOrUpdate(obj);
        }
    }
}
