using BusinessLayer.Abstract;
using DataAccessLayer.Concrete;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace WebUI.Areas.Admin.ViewComponents.Statistic
{
    public class Statistic1 : ViewComponent
    {
        IBlogService _blogService;

        public Statistic1(IBlogService blogService)
        {
            _blogService = blogService;
        }

        Context context = new Context();

        public IViewComponentResult Invoke()
        {
            var result = _blogService.GetList();
            ViewBag.messageCount = context.Contacts.Count();
            ViewBag.commentCount = context.Comments.Count();
            return View(result);
        }
    }
}
