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
    public class BlogManager : IBlogService
    {
        IBlogRepository _blogRepository;
        public BlogManager(IBlogRepository blogRepository)
        {
            _blogRepository = blogRepository;
        }

        public void TAdd(Blog entity)
        {
            _blogRepository.Add(entity);
        }

        public void TDelete(Blog entity)
        {
            _blogRepository.Delete(entity);
        }

        public void TUptade(Blog entity)
        {
            _blogRepository.Update(entity);
        }

        public List<Blog> GetBlogListWithCategory()
        {
            return _blogRepository.GetBlogListWithCategory();
        }

        public Blog GetByID(int id)
        {
            return _blogRepository.GetById(id);
        }

        public List<Blog> GetBlogByID(int id)
        {
            return _blogRepository.GetAll(x => x.BlogID == id);
        }

        public List<Blog> GetList()
        {
            return _blogRepository.GetAll();
        }

        public List<Blog> GetLastThreeBlog()
        {
            return _blogRepository.GetAll().TakeLast(3).ToList();
        }

        public List<Blog> GetBlogListByWriterId(int id)
        {
            return _blogRepository.GetAll(x => x.WriterID == id);
        }
    }
}
