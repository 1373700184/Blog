using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Blog.Models;
using Blog.Other;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Filters;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Authentication;

namespace Blog.Controllers
{
    public class ControllerBase : Controller
    {

        private UserInfo _session;
        public UserInfo SessionUser
        {

            get
            {
                try
                {
                    if (_session != null) //避免多次call
                        return _session;
                    var auth = HttpContext.AuthenticateAsync("Cookie");
                    if (!auth.Result.Succeeded) {
                        return null;
                    }
                    using (SQLContext DB = new SQLContext())
                    {
                        _session = DB.UserInfo.Where(a => a.Id ==HttpContext.Session.GetInt32("Id")).FirstOrDefault();
                    }
                    return _session;
                }
                catch (Exception ex)
                {
                    Logger.Error("登录异常", ex);
                    throw;
                }
            }
        }

        public override void OnActionExecuting(ActionExecutingContext filterContext)
        {
            //var auth =  HttpContext.AuthenticateAsync("Cookie");
            //if (auth.Result.Succeeded)
            //{
            //    ViewBag.RealName = SessionUser.Realname;
            //    ViewBag.U = SessionUser.Username;
            //    ViewBag.P = SessionUser.Password;
            //    ViewBag.RealName = _session != null ? string.Format("{0}({1})", _session.Realname, _session.Realname): "匿名用户";
            //}
            var Name = HttpContext.Session.GetString("Name");
            ViewBag.RealName =(string.IsNullOrWhiteSpace(Name))? null:string.Format("{0}({1})",Name,Name) ;
            base.OnActionExecuting(filterContext);
        }


    }
}
