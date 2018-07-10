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
    public class PicturesRepository : IPicturesRepository
    {
        private readonly BlogContext _context = new BlogContext();
        public int Count()
        {
            return _context.Pictures.Count();
        }

        public void Delete(int ID)
        {
            var Pictures = GetByID(ID);
            if (Pictures != null)
            {
                _context.Pictures.Remove(Pictures);
            }
        }

        public Pictures Get(Expression<Func<Pictures, bool>> expression)
        {
            return _context.Pictures.FirstOrDefault(expression);
        }

        public IEnumerable<Pictures> GetAll()
        {
            return _context.Pictures.Select(x => x);
        }

        public Pictures GetByID(int ID)
        {
            return _context.Pictures.FirstOrDefault(x => x.ID == ID);
        }

        public IQueryable<Pictures> GetMany(Expression<Func<Pictures, bool>> expression)
        {
            return _context.Pictures.Where(expression);
        }

        public void Insert(Pictures obj)
        {
            _context.Pictures.Add(obj);
        }

        public void Save()
        {
            _context.SaveChanges();
        }

        public void Update(Pictures obj)
        {
            _context.Pictures.AddOrUpdate(obj);
        }
    }
}
