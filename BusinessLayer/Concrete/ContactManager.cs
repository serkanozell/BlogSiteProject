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
    public class ContactManager : IContactService
    {
        IContactRepository _contactRepository;

        public ContactManager(IContactRepository contactRepository)
        {
            _contactRepository = contactRepository;
        }
        public void TAdd(Contact entity)
        {
            _contactRepository.Add(entity);
        }
        public void TDelete(Contact entity)
        {
            _contactRepository.Delete(entity);
        }
        public void TUptade(Contact entity)
        {
            _contactRepository.Update(entity);
        }
        public Contact TGetByID(int id)
        {
            return _contactRepository.GetById(id);
        }
        public List<Contact> GetList()
        {
            return _contactRepository.GetAll();
        }
    }
}
