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

        public void WriterAdd(Writer writer)
        {
            _writerRepository.Add(writer);
        }
    }
}
