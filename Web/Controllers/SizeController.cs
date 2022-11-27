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
    public class SizeController : Controller
    {
        private readonly ISizeService sizeService;

        public SizeController(ISizeService sizeService)
        {
            this.sizeService = sizeService;
        }

        [HttpGet]
        public IActionResult CreateSize()
        {
            return View();
        }

        [HttpPost]
        public IActionResult CreateSize(Size size)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    sizeService.AddSize(size);
                    TempData["AlertType"] = ActionTypes.Create.ToString();
                }
                else
                {
                    ViewBag.IsModelStateValid = false;
                    TempData["AlertType"] = ActionTypes.Error.ToString();
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex);
            }

            if (size.Id > 0)
            {
                return RedirectToAction("ListSize", "Size");
            }
            else
            {
                return View(size);
            }
        }

        public ActionResult DeleteSize(int Id)
        {
            Size size = null;
            try
            {
                size = sizeService.GetSize(Id);
                size.Status = StatusCodes.Deleted;
                sizeService.UpdateSize(size);
                TempData["AlertType"] = ActionTypes.Delete.ToString();
            }
            catch (Exception ex)
            {
                TempData["AlertType"] = ActionTypes.Error.ToString();
                Console.WriteLine(ex);
            }
            return RedirectToAction("ListSize", "Size");
        }

        [HttpGet]
        public IActionResult UpdateSize(int Id)
        {
            Size size = null;
            try
            {
                size = sizeService.GetSize(Id);
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex);
            }

            if (size == null)
            {
                TempData["AlertType"] = ActionTypes.Error.ToString();
                return RedirectToAction("ListSize", "Size");
            }
            else
            {
                return View(size);
            }
        }

        [HttpPost]
        public IActionResult UpdateSize(Size size)
        {
            try
            {
                ViewBag.IsModelStateValid = false;
                if (ModelState.IsValid)
                {
                    size = sizeService.UpdateSize(size);
                    ViewBag.IsModelStateValid = true;
                    TempData["AlertType"] = ActionTypes.Update.ToString();
                }
                else
                {
                    ViewBag.IsModelStateValid = false;
                    TempData["AlertType"] = ActionTypes.Error.ToString();
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex);
            }

            if (ViewBag.IsModelStateValid == true)
            {
                return RedirectToAction("ListSize", "Size");
            }
            else
            {
                return View(size);
            }
        }

        [HttpGet]
        public IActionResult ListSize()
        {
            List<Size> size = null;
            try
            {
                size = sizeService.GetSizes();
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex);
            }
            return View(size);
        }
    }
}
