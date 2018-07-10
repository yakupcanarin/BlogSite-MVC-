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
    public class ArticleRepository : IArticleRepository
    {
        private readonly BlogContext _context = new BlogContext();
        public int Count()
        {
            return _context.Article.Count();
        }

        public void Delete(int ID)
        {
            var Article = GetByID(ID);
            if (Article != null)
            {
                _context.Article.Remove(Article);
            }
        }

        public Article Get(Expression<Func<Article, bool>> expression)
        {
            return _context.Article.FirstOrDefault(expression);
        }

        public IEnumerable<Article> GetAll()
        {
            return _context.Article.Select(x => x); 
        }

        public Article GetByID(int ID)
        {
            return _context.Article.FirstOrDefault(x => x.ID == ID);
        }

        public IQueryable<Article> GetMany(Expression<Func<Article, bool>> expression)
        {
            return _context.Article.Where(expression);
        }

        public void Insert(Article obj)
        {
            _context.Article.Add(obj);
        }

        public void Save()
        {
            _context.SaveChanges();
        }

        public void Update(Article obj)
        {
            _context.Article.AddOrUpdate(obj); 
        }
    }
}
