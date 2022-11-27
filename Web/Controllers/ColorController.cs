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
    public class ColorController : Controller
    {
        private readonly IColorService colorService;

        public ColorController(IColorService colorService)
        {
            this.colorService = colorService;
        }

        [HttpGet]
        public IActionResult CreateColor()
        {
            return View();
        }

        [HttpPost]
        public IActionResult CreateColor(Color color)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    colorService.AddColor(color);
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

            if (color.Id > 0)
            {
                return RedirectToAction("ListColor", "Color");
            }
            else
            {
                return View(color);
            }
        }

        public ActionResult DeleteColor(int Id)
        {
            Color color = null;
            try
            {
                color = colorService.GetColor(Id);
                color.Status = StatusCodes.Deleted;
                colorService.UpdateColor(color);
                TempData["AlertType"] = ActionTypes.Delete.ToString();
            }
            catch (Exception ex)
            {
                TempData["AlertType"] = ActionTypes.Error.ToString();
                Console.WriteLine(ex);
            }
            return RedirectToAction("ListColor", "Color");
        }

        [HttpGet]
        public IActionResult UpdateColor(int Id)
        {
            Color color = null;
            try
            {
                color = colorService.GetColor(Id);
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex);
            }

            if (color == null)
            {
                TempData["AlertType"] = ActionTypes.Error.ToString();
                return RedirectToAction("ListColor", "Color");
            }
            else
            {
                return View(color);
            }
        }

        [HttpPost]
        public IActionResult UpdateColor(Color color)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    color = colorService.UpdateColor(color);
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

            if (ViewBag.IsModelStateValid == null)
            {
                return RedirectToAction("ListColor", "Color");
            }
            else
            {
                return View(color);
            }
        }

        [HttpGet]
        public IActionResult ListColor()
        {
            List<Color> colors = null;
            try
            {
                colors = colorService.GetColors();
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex);
                throw;
            }
            return View(colors);
        }
    }
}
