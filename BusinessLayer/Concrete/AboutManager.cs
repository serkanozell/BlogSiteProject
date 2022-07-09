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
    public class AboutManager : IAboutService
    {
        IAboutRepository _aboutRepository;

        public AboutManager(IAboutRepository aboutRepository)
        {
            _aboutRepository = aboutRepository;
        }
        public void TAdd(About entity)
        {
            _aboutRepository.Add(entity);
        }

        public void TDelete(About entity)
        {
            _aboutRepository.Delete(entity);
        }

        public void TUptade(About entity)
        {
            _aboutRepository.Update(entity);
        }
        public About GetByID(int id)
        {
            return _aboutRepository.GetById(id);
        }

        public List<About> GetList()
        {
            return _aboutRepository.GetAll();
        }


    }
}
