using BusinessLayer.Abstract;
using DataAccessLayer.Concrete;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace WebUI.ViewComponents.Writer
{
    public class WriterAboutOnDashboard : ViewComponent
    {
        IWriterService _writerService;

        public WriterAboutOnDashboard(IWriterService writerService)
        {
            _writerService = writerService;
        }

        public IViewComponentResult Invoke()
        {
            var userMail = User.Identity.Name;
            Context context = new Context();
            var writerId = context.Writers.Where(x => x.WriterMail == userMail)
                                            .Select(y => y.WriterID)
                                            .FirstOrDefault();
            var result = _writerService.GetWriterById(writerId);
            return View(result);
        }
    }
}
