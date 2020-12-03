using System;
using System.Web;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Http;
using Blog.Models;
using System.IO;

namespace Blog.Controllers
{
    public class BlogerController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
        public IActionResult EditBloger(Bloger bloger,IFormFile file)
        {
            string filehead = DateTime.Now.ToString("yyyyMMddHHmmss");
          
                string pp = "../upload/ " + filehead + file.FileName;
                file.CopyTo(new FileStream(pp, FileMode.Create));
                string reurl = "../upload/" + Path.GetFileName(file.FileName);
        
            return View(bloger);
        }
    }
}
