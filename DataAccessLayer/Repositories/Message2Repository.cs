using DataAccessLayer.Abstract;
using DataAccessLayer.Concrete;
using DataAccessLayer.EntityFrameworkRepository;
using EntityLayer.Concrete;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccessLayer.Repositories
{
    public class Message2Repository : EntityRepositoryBase<Message2>, IMessage2Repository
    {
        public List<Message2> GetMessageInBoxListByWriterRecieverId(int id)
        {
            using (var context = new Context())
            {
                return context.Messages2.Include(x => x.SenderUser)
                                        .Include(x => x.ReceiverUser)
                                        .Where(x => x.MessageReceiverID == id)
                                        .ToList();
            }
        }

        public List<Message2> GetMessageSendBoxListByWriterRecieverId(int id)
        {
            using (var context = new Context())
            {
                return context.Messages2.Include(x => x.ReceiverUser)
                                        .Include(x => x.SenderUser)
                                        .Where(x => x.MessageSenderID == id)
                                        .ToList();
            }
        }
    }
}
