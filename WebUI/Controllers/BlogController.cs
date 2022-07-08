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
    public class BlogController : Controller
    {
        private readonly IBlogService _blogService;

        public BlogController(IBlogService blogService)
        {
            _blogService = blogService;
        }

        public IActionResult Index()
        {
            var model = _blogService.GetBlogListWithCategory();
            return View(model);
        }

        public IActionResult BlogReadAll(int id)
        {
            ViewBag.i = id;
            var result = _blogService.GetBlogByID(id);
            return View(result);
        }
    }
}
