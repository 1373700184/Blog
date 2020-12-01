using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Blog.Models;
using Blog.Other;
using Microsoft.AspNetCore.Mvc;

namespace Blog.Controllers
{
    public class MixController : Controller
    {
        private readonly Logger logger;
        public IActionResult Index()
        {
            return View();
        }
        public IActionResult EditMix()
        {
            return View();
        }
        [HttpPost]
        public IActionResult SaveMix()
        {
            int level =Convert.ToInt32(Request.Form["level"]);
            string name = Request.Form["text"];
            bool add = (Request.Form["add"]=="on")?true:false;
            bool edit = (Request.Form["edit"] == "on") ? true : false;
            using ( SQLContext DB=new SQLContext())
            {
                Mix mix = new Mix()
                {
                 MixName=name,
                  Allowadd=add,
                   Allowedit=edit,
                   
                };
            }

                return RedirectToAction("EditMix", new { text = "ok" }); 
        }
        [HttpPost]
        public JsonResult GetMixsbyLevel()
        {
            var level = Convert.ToInt32(Request.Form["level"]);
            return Json(0);
        }
    }
}
