using BusinessLayer.Abstract;
using DataAccessLayer.Concrete;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace WebUI.ViewComponents.Writer
{
    public class WriterMessageNotification : ViewComponent
    {
        IWriterService _writerService;
        IMessage2Service _message2Service;
        private readonly Context _context;

        public WriterMessageNotification(IWriterService writerService, IMessageService messageService, IMessage2Service message2Service, Context context)
        {
            _writerService = writerService;
            _message2Service = message2Service;
            _context = context;
        }

        public IViewComponentResult Invoke()
        {
            var userName = User.Identity.Name;
            var userMail = _context.Users.Where(x => x.UserName == userName)
                                        .Select(y => y.Email)
                                        .FirstOrDefault();

            var writerId = _context.Writers.Where(x => x.WriterMail == userMail)
                                          .Select(y => y.WriterID)
                                          .FirstOrDefault();
            var result = _message2Service.GetMessageInBoxListByWriterId(writerId);
            return View(result);
        }
    }
}
