using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace bayosi.utils
{
    public class yoneticibase : System.Web.Mvc.Controller
    {
        protected override void OnActionExecuting(System.Web.Mvc.ActionExecutingContext filterContext)
        {
            if (Session["yonetici"] == null)
            {
                filterContext.Result = new RedirectResult("~/yonetici/giris");

            }

            base.OnActionExecuting(filterContext);
        }

    }
}