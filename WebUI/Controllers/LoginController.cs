using DataAccessLayer.Concrete;
using EntityLayer.Concrete;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Threading.Tasks;
using WebUI.Models;

namespace WebUI.Controllers
{
    [AllowAnonymous]
    public class LoginController : Controller
    {
        private readonly SignInManager<AppUser> _signInManager;

        public LoginController(SignInManager<AppUser> signInManager)
        {
            _signInManager = signInManager;
        }

        public IActionResult Index()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> Index(UserLoginViewModel userLoginViewModel)
        {
            if (ModelState.IsValid)
            {
                var result = await _signInManager.PasswordSignInAsync(userLoginViewModel.UserName, userLoginViewModel.Password, false, true);
                if (result.Succeeded)
                {
                    return RedirectToAction("Index", "Dashboard");
                }
                else
                {
                    return RedirectToAction("Index", "Login");
                }
            }
            return View();
        }



        //[HttpPost]
        //public async Task<IActionResult> Index(Writer writer)
        //{
        //    Context context = new Context();
        //    var data = context.Writers.FirstOrDefault(w => w.WriterMail == writer.WriterMail && w.WriterPassword == writer.WriterPassword);
        //    if (data is not null)
        //    {
        //        var claims = new List<Claim>
        //        {
        //            new Claim(ClaimTypes.Name, writer.WriterMail)
        //        };
        //        var userIdentity = new ClaimsIdentity(claims, "a");
        //        ClaimsPrincipal claimsPrincipal = new ClaimsPrincipal(userIdentity);
        //        await HttpContext.SignInAsync(claimsPrincipal);
        //        return RedirectToAction("Index", "Dashboard");
        //    }
        //    else
        //    {
        //        return View();
        //    }
        //    //Context context = new Context();
        //    //var data = context.Writers.FirstOrDefault(w => w.WriterMail == writer.WriterMail && w.WriterPassword == writer.WriterPassword);
        //    //if (data != null)
        //    //{
        //    //    HttpContext.Session.SetString("username", writer.WriterMail);
        //    //    return RedirectToAction("Index", "Writer");
        //    //}
        //    //else
        //    //{
        //    //    return View();
        //    //}
        //}
    }
}
