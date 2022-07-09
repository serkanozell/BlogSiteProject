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

        public WriterMessageNotification(IWriterService writerService)
        {
            _writerService = writerService;
        }

        public IViewComponentResult Invoke()
        {
            return View();
        }
    }
}
