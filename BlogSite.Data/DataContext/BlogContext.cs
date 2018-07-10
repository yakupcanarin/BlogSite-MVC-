using BlogSite.Data.Models;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BlogSite.Data.DataContext
{
    public class BlogContext : DbContext
    {
        public DbSet<User> User { get; set; }

        public DbSet<Role> Role { get; set; }

        public DbSet<Article> Article { get; set; }

        public DbSet<Pictures> Pictures { get; set; }

        public DbSet<Category> Category { get; set; }
    }
}
