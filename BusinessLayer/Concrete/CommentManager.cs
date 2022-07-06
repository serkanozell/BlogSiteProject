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

        public void CommentAdd(Comment comment)
        {
            _commentRepository.Add(comment);
        }

        public void CommentDelete(Comment comment)
        {
            _commentRepository.Delete(comment);
        }

        public void CommentUpdate(Comment comment)
        {
            _commentRepository.Update(comment);
        }

        public Comment GetByID(int id)
        {
            return _commentRepository.GetById(id);
        }

        public List<Comment> GetList(int id)
        {
            return _commentRepository.GetAll(x => x.BlogID == id);
        }
    }
}
