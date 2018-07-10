using BlogSite.Data.InfraStructure;
using BlogSite.Data.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BlogSite.Core.InfraStructure
{
    public interface ICategoryRepository : IRepository<Category>
    {
    }
}
