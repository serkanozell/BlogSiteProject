using BusinessLayer.Abstract;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace WebUI.ViewComponents.Blog
{
    public class WriterLastBlog : ViewComponent
    {
        IBlogService _blogService;

        public WriterLastBlog(IBlogService blogService)
        {
            _blogService = blogService;
        }

        public IViewComponentResult Invoke()
        {
            _blogService.GetBlogListByWriterId(1);
            return View();
        }
    }
}
