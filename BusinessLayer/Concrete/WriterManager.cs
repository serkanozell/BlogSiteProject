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
    public class WriterManager : IWriterService
    {
        IWriterRepository _writerRepository;

        public WriterManager(IWriterRepository writerRepository)
        {
            _writerRepository = writerRepository;
        }
        public void TAdd(Writer entity)
        {
            _writerRepository.Add(entity);
        }

        public void TDelete(Writer entity)
        {
            _writerRepository.Delete(entity);
        }

        public void TUptade(Writer entity)
        {
            _writerRepository.Update(entity);
        }

        public Writer TGetByID(int id)
        {
            return _writerRepository.GetById(id);
        }

        public List<Writer> GetList()
        {
            return _writerRepository.GetAll();
        }

        public List<Writer> GetWriterById(int id)
        {
            return _writerRepository.GetAll(x => x.WriterID == id);
        }
    }
}
