using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Threading;
using System.Web;
using System.Web.Mvc;

namespace AyudarXAyudar.App_Code
{
    public class LocalizationAttribute : ActionFilterAttribute
    {
        public override void OnActionExecuting(
            ActionExecutingContext filterContext)
        {
            string language = 
                (string)filterContext.RouteData.Values["lang"] ?? "en";

            Thread.CurrentThread.CurrentCulture = 
                Thread.CurrentThread.CurrentUICulture = 
                    new CultureInfo(language);
        }
    }
}