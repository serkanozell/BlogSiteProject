using BusinessLayer.Abstract;
using DataAccessLayer.Concrete;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Xml.Linq;

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

            string api = "3a9ff604fd9b6a270336fbfc4b1c993b";
            string connection = "https://api.openweathermap.org/data/2.5/weather?q=istanbul&mode=xml&lang=tr&units=metric&appid=" + api;
            XDocument document = XDocument.Load(connection);
            ViewBag.temp = document.Descendants("temperature").ElementAt(0).Attribute("value").Value;
            return View(result);
        }
    }
}
