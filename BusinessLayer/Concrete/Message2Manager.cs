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
    public class Message2Manager : IMessage2Service
    {
        IMessage2Repository _message2Repository;

        public Message2Manager(IMessage2Repository message2Repository)
        {
            _message2Repository = message2Repository;
        }
        public void TAdd(Message2 entity)
        {
            _message2Repository.Add(entity);
        }

        public void TDelete(Message2 entity)
        {
            _message2Repository.Delete(entity);
        }

        public void TUptade(Message2 entity)
        {
            _message2Repository.Update(entity);
        }
        public Message2 TGetByID(int id)
        {
            return _message2Repository.GetById(id);
        }
        public List<Message2> GetList()
        {
            return _message2Repository.GetAll();
        }

        public List<Message2> GetMessageInBoxListByWriterId(int id)
        {
            return _message2Repository.GetMessageInBoxListByWriterRecieverId(id);
        }
    }
}
