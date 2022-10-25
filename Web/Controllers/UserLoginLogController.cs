using System;
using System.Collections.Generic;
using Application.Interfaces;
using Domain.Models;
using Microsoft.AspNetCore.Mvc;

namespace Web.Controllers
{
    public class UserLoginLogController : Controller
    {
        private readonly IUserLoginLogService userLoginLogService;
        public UserLoginLogController(IUserLoginLogService userLoginLogService)
        {
            this.userLoginLogService = userLoginLogService;
        }

        [HttpGet]
        public IActionResult ListUserLoginLog()
        {
            List<UserLoginLog> userLoginLogs = null;
            try
            {
                userLoginLogs = userLoginLogService.GetUserLoginLogs();
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex);
            }
            return View(userLoginLogs);
        }
    }
}
