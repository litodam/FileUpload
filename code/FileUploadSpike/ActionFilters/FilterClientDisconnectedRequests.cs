using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace FileUploadSpike.ActionFilters
{
    public class FilterClientDisconnectedRequests : ActionFilterAttribute
    {
        public override void OnActionExecuting(ActionExecutingContext filterContext)
        {
            if (filterContext.HttpContext.Response.IsClientConnected)
            {
                base.OnActionExecuting(filterContext);
            }
            else
            {
                filterContext.Result = new EmptyResult();
            }
        }
    }
}