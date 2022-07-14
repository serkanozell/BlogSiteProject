using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WebUI.Areas.Admin.Models;

namespace WebUI.Areas.Admin.Controllers
{
    [Area("Admin")]
    public class WriterController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }

        public IActionResult WriterList()
        {
            var jsonWriters = JsonConvert.SerializeObject(writers);
            return Json(jsonWriters);
        }

        public IActionResult GetWriterById(int writerId)
        {
            var writer = writers.FirstOrDefault(x => x.WriterId == writerId);
            var jsonWriter = JsonConvert.SerializeObject(writer);
            return Json(jsonWriter);
        }

        [HttpPost]
        public IActionResult AddWriter(WriterClass writer)
        {
            writers.Add(writer);
            var jsonWriter = JsonConvert.SerializeObject(writer);
            return Json(jsonWriter);
        }

        public IActionResult DeleteWriter(int writerId)
        {
            var writer = writers.FirstOrDefault(x => x.WriterId == writerId);
            writers.Remove(writer);
            return Json(writer);
        }

        public IActionResult UpdateWriter(WriterClass writerClass)
        {
            var writer = writers.FirstOrDefault(x => x.WriterId == writerClass.WriterId);
            writer.WriterName = writerClass.WriterName;
            var jsonWriter = JsonConvert.SerializeObject(writerClass);
            return Json(writer);
        }

        public static List<WriterClass> writers = new List<WriterClass>
        {
           new WriterClass
           {
               WriterId=1,
               WriterName="test"
           },
           new WriterClass
           {
               WriterId=2,
               WriterName="deneme"
           },
           new WriterClass
           {
               WriterId=3,
               WriterName="kontrol"
           }
        };
    }
}
