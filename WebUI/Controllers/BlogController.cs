using BusinessLayer.Abstract;
using BusinessLayer.ValidationRules;
using DataAccessLayer.Concrete;
using EntityLayer.Concrete;
using FluentValidation.Results;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace WebUI.Controllers
{
    public class BlogController : Controller
    {
        private readonly IBlogService _blogService;
        private readonly ICategoryService _categoryService;

        public BlogController(IBlogService blogService, ICategoryService categoryService)
        {
            _blogService = blogService;
            _categoryService = categoryService;
        }

        [AllowAnonymous]
        public IActionResult Index()
        {
            var model = _blogService.GetBlogListWithCategory();
            return View(model);
        }

        [AllowAnonymous]
        public IActionResult BlogReadAll(int id)
        {
            ViewBag.i = id;
            var result = _blogService.GetBlogByID(id);
            return View(result);
        }

        public IActionResult BlogListByWriter()
        {
            var userMail = User.Identity.Name;
            Context context = new Context();
            var writerId = context.Writers.Where(x => x.WriterMail == userMail)
                                            .Select(y => y.WriterID)
                                            .FirstOrDefault();
            var result = _blogService.GetListWtihCategoryByWriterId(writerId);
            return View(result);
        }

        [HttpGet]
        public IActionResult BlogAdd()
        {
            List<SelectListItem> categoryValues = (from x in _categoryService.GetList()
                                                   select new SelectListItem
                                                   {
                                                       Text = x.CategoryName,
                                                       Value = x.CategoryID.ToString()
                                                   }).ToList();
            ViewBag.cv = categoryValues;
            return View();
        }

        [HttpPost]
        public IActionResult BlogAdd(Blog blog)
        {
            var userMail = User.Identity.Name;
            Context context = new Context();
            var writerId = context.Writers.Where(x => x.WriterMail == userMail)
                                            .Select(y => y.WriterID)
                                            .FirstOrDefault();
            BlogValidator validationRules = new BlogValidator();
            ValidationResult result = validationRules.Validate(blog);
            if (result.IsValid)
            {
                blog.BlogStatus = true;
                blog.BlogCreatedDate = DateTime.Parse(DateTime.Now.ToShortDateString());
                blog.WriterID = writerId;
                _blogService.TAdd(blog);
                return RedirectToAction("BlogListByWriter", "Blog");
            }
            else
            {
                foreach (var item in result.Errors)
                {
                    ModelState.AddModelError(item.PropertyName, item.ErrorMessage);
                }
            }
            return View();
        }

        public IActionResult DeleteBlog(int id)
        {
            var blogValue = _blogService.TGetByID(id);
            _blogService.TDelete(blogValue);
            return RedirectToAction("BlogListByWriter", "Blog");
        }

        [HttpGet]
        public IActionResult EditBlog(int id)
        {
            var blogEntity = _blogService.TGetByID(id);
            List<SelectListItem> categoryValues = (from x in _categoryService.GetList()
                                                   select new SelectListItem
                                                   {
                                                       Text = x.CategoryName,
                                                       Value = x.CategoryID.ToString()
                                                   }).ToList();
            ViewBag.cv = categoryValues;
            return View(blogEntity);
        }

        [HttpPost]
        public IActionResult EditBlog(Blog blog)
        {
            var userMail = User.Identity.Name;
            Context context = new Context();
            var writerId = context.Writers.Where(x => x.WriterMail == userMail)
                                            .Select(y => y.WriterID)
                                            .FirstOrDefault();
            blog.WriterID = writerId;
            blog.BlogCreatedDate = DateTime.Parse(DateTime.Now.ToShortDateString());
            blog.BlogStatus = true;
            _blogService.TUptade(blog);
            return RedirectToAction("BlogListByWriter");
        }
    }
}
