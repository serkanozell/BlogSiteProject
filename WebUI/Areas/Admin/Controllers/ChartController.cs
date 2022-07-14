using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WebUI.Areas.Admin.Models;

namespace WebUI.Areas.Admin.Controllers
{
    [Area("Admin")]
    public class ChartController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }

        public IActionResult CategoryChart()
        {
            List<CategoryClass> categoryclasses = new List<CategoryClass>();

            categoryclasses.Add(new CategoryClass
            {
                categoryname = "Technology",
                categorycount = 10,
            });
            categoryclasses.Add(new CategoryClass
            {
                categoryname = "Software",
                categorycount = 7,

            });
            categoryclasses.Add(new CategoryClass
            {
                categoryname = "Sport",
                categorycount = 14,
            });
            categoryclasses.Add(new CategoryClass
            {
                categoryname = "Social",
                categorycount = 34,
            });
            return Json(new { jsonlist = categoryclasses });
        }
    }
}
