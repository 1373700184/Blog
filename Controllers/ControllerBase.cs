using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Blog.Models;
using Blog.Other;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Filters;

namespace Blog.Controllers
{
    public class ControllerBase : Controller
    {

        //private UserInfo _session;
        //public UserInfo SessionUser
        //{

        //    get
        //    {
        //        try
        //        {
        //            if (_session != null) //避免多次call
        //                return _session;

        //            if (!User.Identity.IsAuthenticated)
        //                return null;
        //            using (SQLContext DB = new SQLContext())
        //            {
        //                _session = DB.UserInfo.Where(a=>a.Username==User.Identity.Name).FirstOrDefault();
        //            }
        //            return _session;
        //        }
        //        catch (Exception ex)
        //        {
        //            Logger.Error("登录异常", ex);
        //            throw;
        //        }
        //    }
        //}

        //public override void OnActionExecuting(ActionExecutingContext filterContext)
        //{
        //    if (filterContext.HttpContext.Session == null)
        //    {
        //        ViewBag.RealName = SessionUser.Realname;
        //        ViewBag.U = SessionUser.Username;
        //        ViewBag.P = SessionUser.Password;
        //        ViewBag.RealName = _session != null ? string.Format("{0}({1})", _session.Realname, _session.Realname) : "匿名用户";
        //    }
        //    base.OnActionExecuting(filterContext);
        //}


    }
}
