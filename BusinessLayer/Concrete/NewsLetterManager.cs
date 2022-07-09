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
    public class NewsLetterManager : INewsLetterService
    {
        INewsLetterRepository _newsLetterRepository;

        public NewsLetterManager(INewsLetterRepository newsLetterRepository)
        {
            _newsLetterRepository = newsLetterRepository;
        }

        public void TAdd(NewsLetter entity)
        {
            _newsLetterRepository.Add(entity);
        }

        public void TDelete(NewsLetter entity)
        {
            _newsLetterRepository.Delete(entity);
        }

        public void TUptade(NewsLetter entity)
        {
            _newsLetterRepository.Update(entity);
        }
        public NewsLetter GetByID(int id)
        {
            return _newsLetterRepository.GetById(id);
        }

        public List<NewsLetter> GetList()
        {
            return _newsLetterRepository.GetAll();
        }
    }
}
