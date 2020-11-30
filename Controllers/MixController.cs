using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
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
        public JsonResult GetMixsbyLevel()
        {
            var level = Request;
            return Json(0);
        }
    }
}
