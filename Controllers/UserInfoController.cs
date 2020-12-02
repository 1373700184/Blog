using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Blog.Models;
using Blog.Other;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Http;
using System.ComponentModel;
using Microsoft.AspNetCore.Mvc.ModelBinding.Binders;
using System.IO;
using System.Runtime.Serialization;
using System.Runtime.Serialization.Formatters.Binary;

namespace Blog.Controllers
{
    public class UserInfoController : Controller
    {
        private static readonly Logger logger;
        public IActionResult Index()
        {
            return View();
        } 
        public IActionResult Login(EFLogin user)
        {
            string error = null;
            if (ModelState.IsValid)
            {
               
                using (SQLContext DB = new SQLContext())
                {
                    var userinfo = DB.UserInfo.Where(a => (a.Email == user.Username && a.Username == user.Username && a.Phone == user.Username && a.Realname == user.Username) || (a.Status == 0)).FirstOrDefault();
                    if (userinfo == null)
                    {
                        error = "无此用户或者已删除";
                    }
                    else if (userinfo!=null|| userinfo.Password != user.Password)
                    {
                        error = "密码错误";
                    }
                    else
                    {
                        MemoryStream ms = new MemoryStream();
                        IFormatter formatter = new BinaryFormatter();
                        formatter.Serialize(ms, userinfo); 
                        HttpContext.Session.Set("User", ms.GetBuffer());
                        return RedirectToAction("Index", "Home");
                    }
                };

            }
            ViewData["error"] = error;
              return View(user);
        }


        ///OnActionExecuting
    }
}
