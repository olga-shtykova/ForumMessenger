using System.Web.Mvc;

namespace ForumMessenger.Security
{
    public class CustomAuthorize : AuthorizeAttribute
    {
        public override void OnAuthorization(AuthorizationContext filterContext)
        {
            // если у пользователя есть права доступа
            if (this.AuthorizeCore(filterContext.HttpContext))
            {
                base.OnAuthorization(filterContext);
            }
            else
            {
                // если у пользователя нет прав доступа
                filterContext.Result = new RedirectResult("~/Account/UnAuthorized");
            }
        }
    }
}