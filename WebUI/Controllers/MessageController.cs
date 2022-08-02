using BusinessLayer.Abstract;
using DataAccessLayer.Concrete;
using EntityLayer.Concrete;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace WebUI.Controllers
{
    public class MessageController : Controller
    {
        IMessage2Service _message2Service;
        private readonly Context _context;

        public MessageController(IMessage2Service message2Service, Context context)
        {
            _message2Service = message2Service;
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
        public IActionResult MessageDetails(int id)
        {
            var result = _message2Service.TGetByID(id);
            return View(result);
        }

        [HttpGet]
        public IActionResult SendMessage()
        {

            return View();
        }

        [HttpPost]
        public IActionResult SendMessage(Message2 message2, string receiverUserMail)
        {
            var userName = User.Identity.Name;
            var userMail = _context.Users.Where(x => x.UserName == userName)
                                        .Select(y => y.Email)
                                        .FirstOrDefault();

            var writerId = _context.Writers.Where(x => x.WriterMail == userMail)
                                          .Select(y => y.WriterID)
                                          .FirstOrDefault();

            var receiverUserId = _context.Writers.Where(x => x.WriterMail == receiverUserMail)
                                               .Select(y => y.WriterID)
                                               .FirstOrDefault();

            message2.MessageSenderID = writerId;
            message2.MessageReceiverID = receiverUserId;
            message2.MessageStatus = true;
            message2.MessageDate = Convert.ToDateTime(DateTime.Now.ToShortDateString());
            _message2Service.TAdd(message2);
            return RedirectToAction("Inbox");
        }

    }
}
