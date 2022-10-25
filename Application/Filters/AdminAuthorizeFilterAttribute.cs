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
        private readonly AdminUserTypes[] adminUserTypes;
        public AdminAuthorizeFilterAttribute(AdminUserTypes[] adminUserTypes)
        {
            this.adminUserTypes = adminUserTypes;
        }

        public override void OnActionExecuting(ActionExecutingContext context)
        {
            int authorizationResult = 0;
            AdminUser adminUser = null;
            try
            {
                adminUser = context.HttpContext.Session.GetObjectFromJson<AdminUser>("AdminUser");
                context.HttpContext.Items.Add("AdminUser", adminUser);
            }
            catch
            {
                adminUser = null;
            }

            if (adminUser != null && adminUser.Id > 0)
            {
                if (adminUser.UserType != null && adminUserTypes != null)
                {
                    if (adminUserTypes.Contains(AdminUserTypes.All) && adminUser.UserType == AdminUserTypes.Admin)
                    {
                        authorizationResult = 1;
                    }
                    else
                    {
                        foreach (AdminUserTypes userType in adminUserTypes)
                        {
                            if (adminUser.UserType == userType)
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
                context.Result = new RedirectToActionResult("Login", "PanelLogin", null);
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
