﻿using System;
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
                if (ModelState.IsValid)
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

        [HttpGet]
        public IActionResult Login()
        {
            return View();
        }

        [HttpPost]
        public IActionResult Login(UserLoginDto userLoginDto)
        {
            User user = null;
            bool isAuthenticated = false;
            try
            {
                if (ModelState.IsValid)
                {
                    user = userService.GetUser(userLoginDto.Email, AppUtilities.EncryptSHA256(userLoginDto.Password));
                    if (user != null)
                    {
                        isAuthenticated = true;
                        HttpContext.Session.SetObjectAsJson("User", user);
                        TempData["AlertType"] = SweetAlertTypes.Login.ToString();
                    }
                    else
                    {
                        TempData["AlertType"] = SweetAlertTypes.UserEmailPassWordInCorrect.ToString();
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
                return RedirectToAction("Index", "Home");
            }
            else
            {
                return View();
            }
        }

        [HttpGet]
        public IActionResult Register()
        {
            return View();
        }

        [HttpPost]
        public IActionResult Register(UserRegisterDto userRegisterDto)
        {
            User user = null;
            try
            {
                if (ModelState.IsValid)
                {
                    userRegisterDto.Password = AppUtilities.EncryptSHA256(userRegisterDto.Password);
                    user = mapper.Map<User>(userRegisterDto);
                    user.UserType = UserTypes.User;
                    userService.AddUser(user);
                    TempData["AlertType"] = SweetAlertTypes.Register.ToString();
                }
                else
                {
                    TempData["AlertType"] = SweetAlertTypes.Error.ToString();
                }
            }
            catch (Exception ex)
            {
                TempData["AlertType"] = SweetAlertTypes.Error.ToString();
                Console.WriteLine(ex);
            }

            if (user.Id > 0)
            {
                return RedirectToAction("Login", "Login");
            }
            else
            {
                return View();
            }
        }

    }
}
