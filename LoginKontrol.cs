using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Filters;

namespace Area
{
    public class LoginKontrol : ActionFilterAttribute
    {
        public override void OnActionExecuting(ActionExecutingContext filterContext)
        {
            if (filterContext.HttpContext.Session.GetInt32("LoginMi") == null)
            {
                var controller = (Controller)filterContext.Controller;
                filterContext.Result = controller.Redirect("/Admin/Auth/Index");
            }
        }

        public override void OnActionExecuted(ActionExecutedContext filterContext)
        {
            
        }
    }
}
