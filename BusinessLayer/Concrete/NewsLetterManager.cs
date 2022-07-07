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

        public void AddNewsLetter(NewsLetter newsLetter)
        {
            _newsLetterRepository.Add(newsLetter);
        }
    }
}
