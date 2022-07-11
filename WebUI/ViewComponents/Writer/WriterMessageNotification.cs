using BusinessLayer.Abstract;
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
        IMessageService _messageService;

        public WriterMessageNotification(IWriterService writerService, IMessageService messageService)
        {
            _writerService = writerService;
            _messageService = messageService;
        }

        public IViewComponentResult Invoke()
        {
            string p;
            p = "serkan@mail.com";
            var result = _messageService.GetMessageInBoxListByWriterId(p);
            return View(result);
        }
    }
}
