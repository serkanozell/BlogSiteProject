using BusinessLayer.Abstract;
using DataAccessLayer.Abstract;
using EntityLayer.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLayer.Concrete
{
    public class CommentManager : ICommentService
    {
        ICommentRepository _commentRepository;

        public CommentManager(ICommentRepository commentRepository)
        {
            _commentRepository = commentRepository;
        }

        public void TAdd(Comment entity)
        {
            _commentRepository.Add(entity);
        }

        public void TDelete(Comment entity)
        {
            _commentRepository.Delete(entity);
        }

        public void TUptade(Comment entity)
        {
            _commentRepository.Update(entity);
        }
        public Comment TGetByID(int id)
        {
            return _commentRepository.GetById(id);
        }

        public List<Comment> GetList()
        {
            return _commentRepository.GetAll();
        }

        public List<Comment> GetListById(int id)
        {
            return _commentRepository.GetAll(c => c.CommentID == id);
        }

        public List<Comment> GetCommentWithBlog()
        {
            return _commentRepository.GetCommentListWithBlog();
        }
    }
}
