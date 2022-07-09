using DataAccessLayer.Abstract;
using DataAccessLayer.Concrete;
using DataAccessLayer.EntityFrameworkRepository;
using EntityLayer.Concrete;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccessLayer.Repositories
{
    public class BlogRepository : EntityRepositoryBase<Blog>, IBlogRepository
    {
        public List<Blog> GetBlogListWithCategory()
        {
            using (var context = new Context())
            {
                return context.Blogs.Include(x => x.Category).ToList();
            }
        }

        public List<Blog> GetBlogListWithCategoryByWriterId(int id)
        {
            using (var context = new Context())
            {
                return context.Blogs.Include(x => x.Category)
                                    .Where(x => x.WriterID == id)
                                    .ToList();
            }
        }
    }
}
