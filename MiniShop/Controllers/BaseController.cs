﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Filters;

namespace MiniShop.Controllers
{
    public class BaseController : Controller
    {
        public override void OnActionExecuting(ActionExecutingContext context)
        {
            var Curruser = HttpContext.Session.GetString("U");
            var Currrole = HttpContext.Session.GetString("R");
            if (Curruser == null)
            {
                context.Result = new RedirectToActionResult("login", "Identity",new {area= "" });
            }    
            if (Currrole!=null && Currrole != "Admin")
                context.Result = new RedirectToActionResult("deny", "Identity", new { area = "" });
            
            base.OnActionExecuting(context);
        }
    }
}
