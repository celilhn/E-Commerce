using System;
using System.Collections.Generic;
using Application.Filters;
using Application.Interfaces;
using Domain.Models;
using Microsoft.AspNetCore.Mvc;
using static Domain.Constants.Constants;

namespace Web.Controllers
{
    [Authorize(UserTypes.Admin)]
    public class LoginLogController : Controller
    {
        private readonly IUserLoginLogService userLoginLogService;
        public LoginLogController(IUserLoginLogService userLoginLogService)
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
