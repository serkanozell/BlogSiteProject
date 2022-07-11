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
    public class MessageManager : IMessageService
    {
        IMessageRepository _messageRepository;

        public MessageManager(IMessageRepository messageRepository)
        {
            _messageRepository = messageRepository;
        }

        public void TAdd(Message entity)
        {
            _messageRepository.Add(entity);
        }
        public void TDelete(Message entity)
        {
            _messageRepository.Delete(entity);
        }
        public void TUptade(Message entity)
        {
            _messageRepository.Update(entity);
        }
        public Message TGetByID(int id)
        {
            return _messageRepository.GetById(id);
        }
        public List<Message> GetList()
        {
            return _messageRepository.GetAll();
        }

        public List<Message> GetMessageInBoxListByWriterId(string mail)
        {
            return _messageRepository.GetAll(x => x.MessageReceiver == mail);
        }
    }
}
