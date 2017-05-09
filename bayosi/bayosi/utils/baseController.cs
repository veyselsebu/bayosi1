using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace bayosi.utils
{
    public class baseController:System.Web.Mvc.Controller
    {
        protected override void OnActionExecuting(System.Web.Mvc.ActionExecutingContext filterContext)
        {
            if (Session["kullaniciadi"] == null)
            {
                filterContext.Result = new RedirectResult("~/kullanici/giris");
            
            }
            
            base.OnActionExecuting(filterContext);
        }

    }
}