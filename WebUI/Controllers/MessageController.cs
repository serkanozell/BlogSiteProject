using BusinessLayer.Abstract;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace WebUI.Controllers
{
    [AllowAnonymous]
    public class MessageController : Controller
    {
        IMessage2Service _message2Service;

        public MessageController(IMessage2Service message2Service)
        {
            _message2Service = message2Service;
        }

        public IActionResult InBox()
        {
            int id = 1;
            var result = _message2Service.GetMessageInBoxListByWriterId(id);
            return View(result);
        }


        [HttpGet]
        public IActionResult MessageDetails(int id)
        {
            var result = _message2Service.TGetByID(id);
            return View(result);
        }

    }
}
