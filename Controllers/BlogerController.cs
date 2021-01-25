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
using Blog.Models.EFModel;

namespace Blog.Controllers
{
    public class BlogerController : ControllerBase
    {

        private readonly IWebHostEnvironment _hostingEnvironment;
        public BlogerController(IWebHostEnvironment hostingEnvironment)
        {
            _hostingEnvironment = hostingEnvironment;
        }
        public  string UpFile(IFormFile file)
        {
            //获取文件名后缀
            string extName = Path.GetExtension(file.FileName).ToLower();
            //获取保存目录的物理路径
            if (System.IO.Directory.Exists(_hostingEnvironment.WebRootPath + "/upload/bgpic/") == false)//如果不存在就创建images文件夹
            {
                System.IO.Directory.CreateDirectory(_hostingEnvironment.WebRootPath + "/upload/bgpic/");
            }
            string path ="/upload/bgpic/"; //path为某个文件夹的绝对路径，不要直接保存到数据库
                                                                        //    string path = "F:\\TgeoSmart\\Image\\";
                                                                        //生成新文件的名称，guid保证某一时刻内图片名唯一（文件不会被覆盖）
            string fileNewName = Guid.NewGuid().ToString();
            string ImageUrl = path + fileNewName + extName;

            using (var stream = new FileStream(ImageUrl, FileMode.Create))
            {
                file.CopyToAsync(stream);
            }
            return ImageUrl;
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
                                   Backpic = o.Backpic,
                                   PKid=o.PKid

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
                bloger.Backpic= UpFile(file);
                bloger.Mid = 1;
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

        public IActionResult Details(int id=3) 
        {
            EFBlogDetails mo=new EFBlogDetails();
            try
            {
                using (SQLContext DB = new SQLContext())
                {
                    mo.Blog = DB.Bloger.Where(a => a.PKid == id && a.Status == 0).FirstOrDefault();
                    mo.BlogComments = DB.Comment.Where(a => a.Bid == id && a.Status == 0).ToList();
                }
            }
            catch (Exception ex)
            {
                Logger.Error(ex.Message);
                throw ex;
            }
                return View(mo);
        }

    }
}
