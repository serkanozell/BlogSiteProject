using BusinessLayer.Abstract;
using DataAccessLayer.Concrete;
using EntityLayer.Concrete;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace WebUI.Areas.Admin.Controllers
{
    [Area("Admin")]
    public class AdminMessageController : Controller
    {
        IMessage2Service _message2Service;
        private readonly Context _context;
        public AdminMessageController(IMessage2Service messageService, Context context)
        {
            _message2Service = messageService;
            _context = context;
        }

        public IActionResult InBox()
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

        public IActionResult SendBox()
        {
            var userName = User.Identity.Name;
            var userMail = _context.Users.Where(x => x.UserName == userName)
                                        .Select(y => y.Email)
                                        .FirstOrDefault();

            var writerId = _context.Writers.Where(x => x.WriterMail == userMail)
                                          .Select(y => y.WriterID)
                                          .FirstOrDefault();
            var result = _message2Service.GetMessageSendBoxListByWriterId(writerId);
            return View(result);
        }

        [HttpGet]
        public IActionResult ComposeMessage()
        {
            return View();
        }

        [HttpPost]
        public IActionResult ComposeMessage(Message2 message2, string messageReceiverId)
        {
            var userName = User.Identity.Name;
            var userMail = _context.Users.Where(x => x.UserName == userName)
                                        .Select(y => y.Email)
                                        .FirstOrDefault();

            var writerId = _context.Writers.Where(x => x.WriterMail == userMail)
                                          .Select(y => y.WriterID)
                                          .FirstOrDefault();
            var receiverId = _context.Users.Where(x => x.Email == messageReceiverId).Select(y => y.Id).FirstOrDefault();
            message2.MessageSenderID = writerId;
            message2.MessageReceiverID = receiverId;
            message2.MessageDate = Convert.ToDateTime(DateTime.Now.ToShortDateString());
            message2.MessageStatus = true;
            _message2Service.TAdd(message2);
            return RedirectToAction("SendBox");
        }
    }
}
