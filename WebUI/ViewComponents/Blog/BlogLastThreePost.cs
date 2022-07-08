using BusinessLayer.Abstract;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace WebUI.ViewComponents.Blog
{
    public class BlogLastThreePost : ViewComponent
    {
        IBlogService _blogService;

        public BlogLastThreePost(IBlogService blogService)
        {
            _blogService = blogService;
        }

        public IViewComponentResult Invoke()
        {
            var result = _blogService.GetLastThreeBlog();
            return View(result);
        }
    }
}
