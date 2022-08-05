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
    public class CommentRepository : EntityRepositoryBase<Comment>, ICommentRepository
    {
        public List<Comment> GetCommentListWithBlog()
        {
            using (Context context = new Context())
            {
                return context.Comments.Include(x => x.Blog).ToList();
            }
        }
    }
}
