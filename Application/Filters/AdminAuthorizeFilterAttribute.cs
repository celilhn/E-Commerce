using System.Linq;
using Application.Extensions;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Filters;
using Domain.Models;
using static Domain.Constants.Constants;

namespace Application.Filters
{
    public class AdminAuthorizeFilterAttribute : ActionFilterAttribute, IActionFilter
    {
        private readonly UserTypes[] userTypes;
        public AdminAuthorizeFilterAttribute(UserTypes[] userTypes)
        {
            this.userTypes = userTypes;
        }

        public override void OnActionExecuting(ActionExecutingContext context)
        {
            int authorizationResult = 0;
            User user = null;
            try
            {
                user = context.HttpContext.Session.GetObjectFromJson<User>("User");
                context.HttpContext.Items.Add("User", user);
            }
            catch
            {
                user = null;
            }

            if (user != null && user.Id > 0)
            {
                if (user.UserType != null && userTypes != null)
                {
                    if (userTypes.Contains(UserTypes.All) && user.UserType == UserTypes.Admin)
                    {
                        authorizationResult = 1;
                    }
                    else
                    {
                        foreach (UserTypes userType in userTypes)
                        {
                            if (user.UserType == userType)
                            {
                                authorizationResult = 1;
                                break;
                            }
                            else
                            {
                                authorizationResult = -1;
                            }
                        }
                    }
                }
                else
                {
                    authorizationResult = 0;
                }
            }
            else
            {
                authorizationResult = -1;
            }

            if (authorizationResult == -1)
            {
                context.Result = new RedirectToActionResult("PanelLogin", "Login", null);
            }
            else if (authorizationResult == 0)
            {
                context.Result = new RedirectToActionResult("Error", "Home", null);
            }
            else if (authorizationResult == 1)
            {
                base.OnActionExecuting(context);
            }
        }
    }
}
