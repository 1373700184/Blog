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
using Newtonsoft.Json;
using System.Security.Claims;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Authorization;

namespace Blog.Controllers
{
    public class UserInfoController : Controller
    {
        private static readonly Logger logger;
        public IActionResult Index()
        {
            return View();
        }
        public IActionResult Logout()
        {
            HttpContext.Session.Clear();
            return RedirectToAction("Index", "Home");
        }

        //[Authorize]
        public IActionResult Login(EFLogin user)
        {
            string error = null;
            if (user.Username!=null)
            {
               
                using (SQLContext DB = new SQLContext())
                {
                    var userinfo = DB.UserInfo.Where(a =>(a.Email == user.Username || a.Username == user.Username || a.Phone == user.Username || a.Realname == user.Username) && (a.Status == 0)).FirstOrDefault();
                    if (userinfo == null)
                    {
                        error = "无此用户或者已删除";
                    }
                    else if (userinfo!=null & userinfo.Password != user.Password)
                    {
                        error = "密码错误";
                    }
                    else
                    {
                        string token = DateTime.Now.ToString();  //登录成功后生成的token，用于验证登录有效性
                        var claims = new List<Claim>()
                        {
                         new Claim(ClaimTypes.Name,userinfo.Username)
                         };
                        var userPrincipal = new ClaimsPrincipal(new ClaimsIdentity(claims, token));
                         HttpContext.SignInAsync("Cookie", userPrincipal,
                          new Microsoft.AspNetCore.Authentication.AuthenticationProperties
                          {
                              ExpiresUtc = DateTime.UtcNow.AddHours(12),
                              IsPersistent = true,
                              AllowRefresh = false
                          });
                        string jsonStr = JsonConvert.SerializeObject(userinfo, Formatting.Indented);
                        
                        HttpContext.Session.SetInt32("Id", userinfo.Id);
                        HttpContext.Session.SetString("Name", userinfo.Username);
                        HttpContext.Session.SetString("User",jsonStr);
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
