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
        IMessage2Service _message2Service;

        public WriterMessageNotification(IWriterService writerService, IMessageService messageService, IMessage2Service message2Service)
        {
            _writerService = writerService;
            _message2Service = message2Service;
        }

        public IViewComponentResult Invoke()
        {
            int id = 1;
            var result = _message2Service.GetMessageInBoxListByWriterId(id);
            return View(result);
        }
    }
}
