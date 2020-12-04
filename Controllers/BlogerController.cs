using System;
using System.Web;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Http;
using Blog.Models;
using System.IO;
using Microsoft.AspNetCore.Hosting;
using Blog.Other;

namespace Blog.Controllers
{
    public class BlogerController : Controller
    {


        private readonly IWebHostEnvironment _hostingEnvironment;
        public BlogerController(IWebHostEnvironment hostingEnvironment)
        {
            _hostingEnvironment = hostingEnvironment;
        }
        public IActionResult Index()
        {
            
            return View();
        }
        public IActionResult List(int index=1,int number=24)
        {            
            ViewData["Count"] = 0;
            ViewData["Page"] = 0;
            ViewData["Index"] = index;
            List<EFBloger> blogers = new List<EFBloger>();
            using (SQLContext DB=new SQLContext()) 
            {
                int count = DB.Bloger.Count();
                int page = 0;

                if (count != 0)
                {
                    if (count % number != 0) { page = count / number + 1; }
                    else { page = count / number; }
                    blogers = (from o in DB.Bloger
                               join m in DB.Mix
                               on o.Mid equals m.PKID
                               join b in DB.UserInfo
                               on o.Uid equals b.Id
                               select new EFBloger
                               {
                                   Uname = b.Username,
                                   Briefly = o.Briefly,
                                   Title = o.Title,
                                   Mname = m.MixName,
                                   Datestr = o.UpdateTime.ToString("yy-MMM-dd"),
                                   Backpic = o.Backpic

                               }).Skip((index - 1) * number).Take(number).ToList();
                }
                else { blogers = null; }
            };
            return View(blogers);
        }
        public IActionResult EditBloger(Bloger bloger,IFormFile file)
        {
            string filehead = DateTime.Now.ToString("yyyyMMddHHmmss");

            if (file != null) 
            {
                bloger.Backpic= Other.Other.UpFile(file);
                bloger.Mid = ",1";
                bloger.Status = 0;
                bloger.AddTime= bloger.UpdateTime = DateTime.Now;
                using (SQLContext DB=new SQLContext())
                {
                    try
                    {
                        DB.Bloger.Add(bloger);
                        DB.SaveChanges();
                    }
                    catch (Exception ex)
                    {
                        Logger.Error(ex.Message);
                        throw ex;                       
                    }
                    return RedirectToAction("Index");
                };
            }
            return View(bloger);
        }
       
    }
}
