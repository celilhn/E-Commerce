using System;
using System.Collections.Generic;
using Application.Filters;
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
    [AdminAuthorize(AdminUserTypes.Admin)]
    public class AdminUserController : Controller
    {
        private readonly IAdminUserService adminUserService;
        private readonly IMapper mapper;

        public AdminUserController(IAdminUserService adminUserService, IMapper mapper)
        {
            this.adminUserService = adminUserService;
            this.mapper = mapper;
        }

        [HttpGet]
        public IActionResult CreateAdminUser()
        {
            return View();
        }

        [HttpPost]
        public IActionResult CreateAdminUser(AdminUserAddDto adminUserAddDto, IFormFile file)
        {
            bool isAddSuccessful = false;
            try
            {
                if (ModelState.IsValid)
                {
                    adminUserAddDto.ImageUrl = adminUserService.UploadFile(file);
                    adminUserAddDto.Password = AppUtilities.EncryptSHA256(adminUserAddDto.Password);
                    adminUserAddDto = mapper.Map<AdminUserAddDto>(adminUserService.AddAdminUser(mapper.Map<AdminUser>(adminUserAddDto)));
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
                return RedirectToAction("ListAdminUsers", "AdminUser");
            }
            else
            {
                return View(adminUserAddDto);
            }
        }

        public ActionResult DeleteAdminUser(int Id)
        {
            AdminUser adminUser = null;
            try
            {
                adminUser = adminUserService.GetAdminUser(Id);
                adminUser.Status = 0;
                adminUserService.UpdateAdminUser(adminUser);
                TempData["AlertType"] = SweetAlertTypes.Delete.ToString();
            }
            catch (Exception ex)
            {
                TempData["AlertType"] = SweetAlertTypes.Error.ToString();
                Console.WriteLine(ex);
            }
            return RedirectToAction("ListAdminUsers", "AdminUser");
        }

        [HttpGet]
        public IActionResult UpdateAdminUser(int Id)
        {
            AdminUserUpdateDto adminUser = null;
            try
            {
                adminUser = mapper.Map<AdminUserUpdateDto>(adminUserService.GetAdminUser(Id));
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex);
            }

            if (adminUser == null)
            {
                TempData["AlertType"] = ActionTypes.Error.ToString();
                return RedirectToAction("ListAdminUsers", "AdminUser");
            }
            else
            {
                return View(adminUser);
            }
        }

        [HttpPost]
        public IActionResult UpdateAdminUser(AdminUserUpdateDto adminUserUpdateDto, IFormFile file)
        {
            try
            {
                ViewBag.IsModelStateValid = false;
                if (ModelState.IsValid)
                {
                    if (file != null)
                    {
                        adminUserUpdateDto.ImageUrl = adminUserService.UploadFile(file);
                    }
                    adminUserUpdateDto = mapper.Map<AdminUserUpdateDto>(adminUserService.UpdateAdminUser(mapper.Map<AdminUser>(adminUserUpdateDto)));
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
                return RedirectToAction("ListAdminUsers", "AdminUser");
            }
            else
            {
                return View(adminUserUpdateDto);
            }
        }

        [HttpGet]
        public IActionResult ListAdminUsers()
        {
            List<AdminUser> adminUsers = null;
            try
            {
                adminUsers = adminUserService.GetAdminUsers();
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex);
                throw;
            }
            return View(adminUsers);
        }
    }
}
