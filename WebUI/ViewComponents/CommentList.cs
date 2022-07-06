using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WebUI.Models;

namespace WebUI.ViewComponents
{
    public class CommentList : ViewComponent
    {
        public IViewComponentResult Invoke()
        {
            var commentList = new List<UserComment>()
            {
                new UserComment
                {
                    ID=1,
                    UserName="Seko"
                },
                new UserComment
                {
                    ID=2,
                    UserName="Berkan"
                },
                new UserComment
                {
                    ID=3,
                    UserName="AAA"
                }
            };
            return View(commentList);
        }
    }
}
