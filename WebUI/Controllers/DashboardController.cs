using BusinessLayer.Abstract;
using DataAccessLayer.Concrete;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace WebUI.Controllers
{
    public class DashboardController : Controller
    {
        IBlogService _blogService;

        public DashboardController(IBlogService blogService)
        {
            _blogService = blogService;
        }

        public IActionResult Index()
        {
            Context context = new Context();

            var userName = User.Identity.Name;
            var userMail = context.Users.Where(x => x.UserName == userName).Select(y => y.Email).FirstOrDefault();
            var writerId = context.Writers.Where(x => x.WriterMail == userMail).Select(y => y.WriterID).FirstOrDefault();

            ViewBag.v1 = context.Blogs.Count().ToString();
            ViewBag.v2 = context.Blogs.Where(x => x.WriterID == writerId).Count();
            ViewBag.v3 = context.Categories.Count();

            return View();
        }
    }
}
