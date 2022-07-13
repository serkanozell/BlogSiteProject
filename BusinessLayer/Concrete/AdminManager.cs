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
    public class AdminManager : IAdminService
    {
        IAdminRepository _adminRepository;

        public AdminManager(IAdminRepository adminRepository)
        {
            _adminRepository = adminRepository;
        }
        public void TAdd(Admin entity)
        {
            _adminRepository.Add(entity);
        }
        public void TDelete(Admin entity)
        {
            _adminRepository.Delete(entity);
        }

        public void TUptade(Admin entity)
        {
            _adminRepository.Update(entity);
        }
        public Admin TGetByID(int id)
        {
            return _adminRepository.GetById(id);
        }
        public List<Admin> GetList()
        {
            return _adminRepository.GetAll();
        }
    }
}
