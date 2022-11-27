using System;
using System.Collections.Generic;
using Application.Filters;
using Application.Interfaces;
using Domain.Models;
using Microsoft.AspNetCore.Mvc;
using static Domain.Constants.Constants;

namespace Web.Controllers
{
    [AdminAuthorize(AdminUserTypes.Admin)]
    public class LoginLogController : Controller
    {
        private readonly ILoginLogService userLoginLogService;
        public LoginLogController(ILoginLogService userLoginLogService)
        {
            this.userLoginLogService = userLoginLogService;
        }

        [HttpGet]
        public IActionResult ListUserLoginLog()
        {
            List<LoginLog> userLoginLogs = null;
            try
            {
                userLoginLogs = userLoginLogService.GetUserLoginLogs(LoginTypes.Web);
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex);
            }
            return View(userLoginLogs);
        }

        [HttpGet]
        public IActionResult ListAdminUserLoginLog()
        {
            List<LoginLog> userLoginLogs = null;
            try
            {
                userLoginLogs = userLoginLogService.GetUserLoginLogs(LoginTypes.Panel);
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex);
            }
            return View(userLoginLogs);
        }
    }
}
