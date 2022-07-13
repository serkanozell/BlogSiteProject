using ClosedXML.Excel;
using DataAccessLayer.Concrete;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;
using WebUI.Areas.Admin.Models;

namespace WebUI.Areas.Admin.Controllers
{
    [Area("Admin")]
    public class BlogController : Controller
    {
        public IActionResult ExportStaticExcelBlogList()
        {
            using (var workBook = new XLWorkbook())
            {
                var workSheet = workBook.Worksheets.Add("Blog List");
                workSheet.Cell(1, 1).Value = "Blog ID";
                workSheet.Cell(1, 2).Value = "Blog Title";

                int blogRowCount = 2;

                foreach (var item in GetBlogList())
                {
                    workSheet.Cell(blogRowCount, 1).Value = item.BlogID;
                    workSheet.Cell(blogRowCount, 2).Value = item.BlogTitle;
                    blogRowCount++;
                }

                using (var stream = new MemoryStream())
                {
                    workBook.SaveAs(stream);
                    var content = stream.ToArray();
                    return File(content, "application/vnd.openxmlformats-officedocument.spreadsheetml.sheet", "Blog Listesi.xlsx");
                }
            }
        }

        public List<BlogModel> GetBlogList()
        {
            List<BlogModel> blogModels = new List<BlogModel>
            {
                new BlogModel{BlogID=1,BlogTitle="Test"},
                new BlogModel{BlogID=2,BlogTitle="Test2"},
                new BlogModel{BlogID=3,BlogTitle="Test3"},
            };
            return blogModels;
        }

        public IActionResult BlogListExcel()
        {
            return View();
        }

        public IActionResult ExportDynamicExcelBlogList()
        {
            using (var workBook = new XLWorkbook())
            {
                var workSheet = workBook.Worksheets.Add("Blog List");
                workSheet.Cell(1, 1).Value = "Blog ID";
                workSheet.Cell(1, 2).Value = "Blog Title";

                int blogRowCount = 2;

                foreach (var item in GetBlogListDynamic())
                {
                    workSheet.Cell(blogRowCount, 1).Value = item.BlogID;
                    workSheet.Cell(blogRowCount, 2).Value = item.BlogTitle;
                    blogRowCount++;
                }

                using (var stream = new MemoryStream())
                {
                    workBook.SaveAs(stream);
                    var content = stream.ToArray();
                    return File(content, "application/vnd.openxmlformats-officedocument.spreadsheetml.sheet", "Blog Listesi.xlsx");
                }
            }
        }

        public List<BlogModel2> GetBlogListDynamic()
        {
            List<BlogModel2> blogModels = new List<BlogModel2>();
            using (var context = new Context())
            {
                blogModels = context.Blogs.Select(x => new BlogModel2
                {
                    BlogID = x.BlogID,
                    BlogTitle = x.BlogTitle
                }).ToList();
            }
            return blogModels;
        }

        public IActionResult BlogListExcelDynamic()
        {
            return View();
        }
    }
}
