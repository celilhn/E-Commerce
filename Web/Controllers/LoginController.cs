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
    public class LoginController : Controller
    {
        private readonly IUserService userService;
        private readonly IMapper mapper;
        public LoginController(IUserService userService, IMapper mapper)
        {
            this.userService = userService;
            this.mapper = mapper;
        }

        [HttpGet]
        public IActionResult PanelLogin()
        {
            return View();
        }

        [HttpPost]
        public IActionResult PanelLogin(UserLoginDto userLoginDto)
        {
            User user = null;
            bool isAuthenticated = false;
            try
            {
                user = userService.GetUser(userLoginDto.Email, AppUtilities.EncryptSHA256(userLoginDto.Password)); 
                if (user != null)
                {
                    isAuthenticated = true;
                    HttpContext.Session.SetObjectAsJson("User", user);
                }
                else
                {
                    TempData["AlertType"] = SweetAlertTypes.UserEmailPassWordInCorrect.ToString();
                }
            }
            catch (Exception ex)
            {
                TempData["AlertType"] = SweetAlertTypes.Error.ToString();
                Console.WriteLine(ex);
            }

            if (isAuthenticated)
            {
                return RedirectToAction("ListFaqs", "Faq");
            }
            else
            {
                return View();
            }
        }

    }
}
