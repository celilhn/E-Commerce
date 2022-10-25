using Microsoft.AspNetCore.Mvc;
using static Domain.Constants.Constants;

namespace Application.Filters
{
    public class AdminAuthorizeAttribute : TypeFilterAttribute
    {
        public AdminAuthorizeAttribute(params UserTypes[] userTypes) : base(typeof(AdminAuthorizeFilterAttribute))
        {
            Arguments = new[] { userTypes };
        }
    }
}
