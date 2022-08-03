using BusinessLayer.Abstract;
using BusinessLayer.ValidationRules;
using DataAccessLayer.Concrete;
using EntityLayer.Concrete;
using FluentValidation.Results;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;
using WebUI.Models;

namespace WebUI.Controllers
{
    public class WriterController : Controller
    {
        IWriterService _writerService;
        private readonly UserManager<AppUser> _userManager;
        IUserService _userService;
        private readonly Context _context;

        public WriterController(IWriterService writerService, UserManager<AppUser> userManager, IUserService userService, Context context)
        {
            _writerService = writerService;
            _userManager = userManager;
            _userService = userService;
            _context = context;
        }
        [Authorize]
        public IActionResult Index()
        {
            var userMail = User.Identity.Name;
            ViewBag.v = userMail;
            var writerName = _context.Writers.Where(x => x.WriterMail == userMail).Select(y => y.WriterName).FirstOrDefault();
            ViewBag.writerName = writerName;
            return View();
        }

        public IActionResult WriterProfile()
        {
            return View();
        }

        public IActionResult WriterMail()
        {
            return View();
        }
        public IActionResult Test()
        {
            return View();
        }

        public PartialViewResult WriterNavBarPartial()
        {
            //var userName = User.Identity.Name;
            //var userNameSurname = _context.Users.Where(x => x.UserName == userName).Select(y => y.NameSurname).FirstOrDefault();
            //ViewBag.userName = userName;
            return PartialView();
        }

        public PartialViewResult WriterFooterPartial()
        {
            return PartialView();
        }

        [HttpGet]
        public async Task<IActionResult> WriterEditProfile()
        {
            //Context context = new Context();
            ////var user = User.Identity.Name;
            //var user = await _userManager.FindByNameAsync(User.Identity.Name);
            //var userId = context.Users.Where(x => x.UserName == user.UserName).Select(y => y.Id).FirstOrDefault();
            //var result = _userService.TGetByID(userId);
            //return View(result);

            var user = await _userManager.FindByNameAsync(User.Identity.Name);
            UserUpdateViewModel userUpdateViewModel = new UserUpdateViewModel();
            userUpdateViewModel.NameSurName = user.NameSurname;
            userUpdateViewModel.Email = user.Email;
            userUpdateViewModel.UserName = user.UserName;
            userUpdateViewModel.ImageURL = user.ImageUrl;
            return View(userUpdateViewModel);
        }
        [HttpPost]
        public async Task<IActionResult> WriterEditProfile(UserUpdateViewModel userUpdateViewModel)
        {
            var user = await _userManager.FindByNameAsync(User.Identity.Name);
            user.NameSurname = userUpdateViewModel.NameSurName;
            user.Email = userUpdateViewModel.Email;
            user.UserName = userUpdateViewModel.UserName;
            user.ImageUrl = userUpdateViewModel.ImageURL;
            user.PasswordHash = _userManager.PasswordHasher.HashPassword(user, userUpdateViewModel.Password);
            var result = await _userManager.UpdateAsync(user);
            if (result.Succeeded)
            {
                return RedirectToAction("Index", "Dashboard");
            }
            else
            {
                return RedirectToAction("Index", "Login");
            }
        }

        [HttpGet]
        public IActionResult WriterAdd()
        {
            return View();
        }

        [HttpPost]
        public IActionResult WriterAdd(AddProfileImage image)
        {
            Writer writer = new Writer();
            if (image.WriterImage != null)
            {
                var extension = Path.GetExtension(image.WriterImage.FileName);
                var newImageName = Guid.NewGuid() + extension;
                var location = Path.Combine(Directory.GetCurrentDirectory(), "wwwroot/WriterImageFiles/", newImageName);
                var stream = new FileStream(location, FileMode.Create);
                image.WriterImage.CopyTo(stream);
                writer.WriterImage = newImageName;
                image.WriterStatus = true;
            }
            writer.WriterMail = image.WriterMail;
            writer.WriterName = image.WriterName;
            writer.WriterPassword = image.WriterPassword;
            writer.WriterStatus = image.WriterStatus;
            writer.WriterAbout = image.WriterAbout;
            _writerService.TAdd(writer);
            return RedirectToAction("Index", "Dashboard");
        }
    }
}
