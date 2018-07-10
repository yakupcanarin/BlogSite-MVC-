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
    public class CategoryRepository : ICategoryRepository
    {
        private readonly BlogContext _context = new BlogContext();
        public int Count()
        {
            return _context.Category.Count();
        }

        public void Delete(int ID)
        {
            var Category = GetByID(ID);
            if (Category != null)
            {
                _context.Category.Remove(Category);
            }
        }

        public Category Get(Expression<Func<Category, bool>> expression)
        {
            return _context.Category.FirstOrDefault(expression);
        }

        public IEnumerable<Category> GetAll()
        {
            return _context.Category.Select(x => x);
        }

        public Category GetByID(int ID)
        {
            return _context.Category.FirstOrDefault(x => x.ID == ID);
        }

        public IQueryable<Category> GetMany(Expression<Func<Category, bool>> expression)
        {
            return _context.Category.Where(expression);
        }

        public void Insert(Category obj)
        {
            _context.Category.Add(obj);
        }

        public void Save()
        {
            _context.SaveChanges();
        }

        public void Update(Category obj)
        {
            _context.Category.AddOrUpdate(obj);
        }
    }
}
