using System;
using Application.Extensions;
using Application.Interfaces;
using Application.Utilities;
using Application.ViewModels;
using AutoMapper;
using Domain.Models;
using Microsoft.AspNetCore.Mvc;
using static Domain.Constants.Constants;


namespace Web.Controllers
{
    public class PanelLoginController : Controller
    {
        private readonly IAdminUserService adminUserService;
        private readonly IMapper mapper;
        public PanelLoginController(IAdminUserService adminUserService, IMapper mapper)
        {
            this.adminUserService = adminUserService;
            this.mapper = mapper;
        }

        [HttpGet]
        public IActionResult Login()
        {
            return View();
        }

        [HttpPost]
        public IActionResult Login(UserLoginDto userLoginDto)
        {
            AdminUser adminUser = null;
            bool isAuthenticated = false;
            try
            {
                if (ModelState.IsValid)
                {
                    adminUser = adminUserService.GetAdminUser(userLoginDto.Email, AppUtilities.EncryptSHA256(userLoginDto.Password));
                    if (adminUser != null)
                    {
                        isAuthenticated = true;
                        HttpContext.Session.SetObjectAsJson("AdminUser", adminUser);
                        adminUserService.SaveAdminUserLoginLog(adminUser.Email, adminUser.Password, LoginStatus.Success);
                    }
                    else
                    {
                        TempData["AlertType"] = SweetAlertTypes.UserEmailPassWordInCorrect.ToString();
                        adminUserService.SaveAdminUserLoginLog(userLoginDto.Email, AppUtilities.EncryptSHA256(userLoginDto.Password), LoginStatus.Wrong);
                    }
                }
            }
            catch (Exception ex)
            {
                TempData["AlertType"] = SweetAlertTypes.Error.ToString();
                Console.WriteLine(ex);
            }

            if (isAuthenticated)
            {
                return RedirectToAction("Index", "Panel");
            }
            else
            {
                return View();
            }
        }
    }
}
