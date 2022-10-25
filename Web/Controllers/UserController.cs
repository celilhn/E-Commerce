using System;
using System.Collections.Generic;
using System.IO;
using Application.Interfaces;
using Application.Utilities;
using Application.ViewModels;
using AutoMapper;
using Domain.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using static Domain.Constants.Constants;

namespace Web.Controllers
{
    public class UserController : Controller
    {
        private readonly IUserService userService;
        private readonly IMapper mapper;

        public UserController(IUserService userService, IMapper mapper)
        {
            this.userService = userService;
            this.mapper = mapper;
        }

        [HttpGet]
        public IActionResult CreateUser()
        {
            return View();
        }

        [HttpPost]
        public IActionResult CreateUser(UserAddDto userAddDto, IFormFile file)
        {
            bool isAddSuccessful = false;
            try
            {
                if (ModelState.IsValid)
                {
                    userAddDto.ImageUrl = userService.UploadFile(file);
                    userAddDto.Password = AppUtilities.EncryptSHA256(userAddDto.Password);
                    userAddDto = mapper.Map<UserAddDto>(userService.AddUser(mapper.Map<User>(userAddDto)));
                    TempData["AlertType"] = SweetAlertTypes.Create.ToString();
                    isAddSuccessful = true;
                }
                else
                {
                    ViewBag.IsModelStateValid = false;
                    TempData["AlertType"] = SweetAlertTypes.Error.ToString();
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex);
            }

            if (isAddSuccessful)
            {
                return RedirectToAction("ListUsers", "User");
            }
            else
            {
                return View(userAddDto);
            }
        }

        public ActionResult DeleteUser(int Id)
        {
            User user = null;
            try
            {
                user = userService.GetUser(Id);
                user.Status = 0;
                userService.UpdateUser(user);
                TempData["AlertType"] = SweetAlertTypes.Delete.ToString();
            }
            catch (Exception ex)
            {
                TempData["AlertType"] = SweetAlertTypes.Error.ToString();
                Console.WriteLine(ex);
            }
            return RedirectToAction("ListUsers", "User");
        }

        [HttpGet]
        public IActionResult UpdateUser(int Id)
        {
            UserUpdateDto user = null;
            try
            {
                user = mapper.Map<UserUpdateDto>(userService.GetUser(Id));
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex);
            }

            if (user == null)
            {
                TempData["AlertType"] = ActionTypes.Error.ToString();
                return RedirectToAction("ListUsers", "User");
            }
            else
            {
                return View(user);
            }
        }

        [HttpPost]
        public IActionResult UpdateUser(UserUpdateDto userUpdateDto, IFormFile file)
        {
            try
            {
                ViewBag.IsModelStateValid = false;
                if (ModelState.IsValid)
                {
                    if (file != null)
                    {
                        userUpdateDto.ImageUrl = userService.UploadFile(file);
                    }
                    userUpdateDto = mapper.Map<UserUpdateDto>(userService.UpdateUser(mapper.Map<User>(userUpdateDto)));
                    ViewBag.IsModelStateValid = true;
                    TempData["AlertType"] = SweetAlertTypes.Update.ToString();
                }
                else
                {
                    TempData["AlertType"] = SweetAlertTypes.Error.ToString();
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex);
            }

            if (ViewBag.IsModelStateValid == true)
            {
                return RedirectToAction("ListUsers", "User");
            }
            else
            {
                return View(userUpdateDto);
            }
        }

        [HttpGet]
        public IActionResult ListUsers()
        {
            List<User> users = null;
            try
            {
                users = userService.GetUsers();
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex);
                throw;
            }
            return View(users);
        }
    }
}
