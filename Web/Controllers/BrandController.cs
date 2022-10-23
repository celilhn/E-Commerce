using System;
using System.Collections.Generic;
using Application.Interfaces;
using Domain.Constants;
using Domain.Models;
using Microsoft.AspNetCore.Mvc;
using static Domain.Constants.Constants;

namespace Web.Controllers
{
    public class BrandController : Controller
    {
        private readonly IBrandService brandService;

        public BrandController(IBrandService brandService)
        {
            this.brandService = brandService;
        }
        
        [HttpGet]
        public IActionResult CreateBrand()
        {
            return View();
        }

        [HttpPost]
        public IActionResult CreateBrand(Brand brand)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    brandService.AddBrand(brand);
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

            if (brand.Id > 0)
            {
                return RedirectToAction("ListBrand", "Brand");
            }
            else
            {
                return View(brand);
            }
        }

        public ActionResult DeleteBrand(int Id)
        {
            Brand brand = null;
            try
            {
                brand = brandService.GetBrand(Id);
                brand.Status = 0;
                brandService.UpdateBrand(brand);
                TempData["AlertType"] = ActionTypes.Delete.ToString();
            }
            catch (Exception ex)
            {
                TempData["AlertType"] = ActionTypes.Error.ToString();
                Console.WriteLine(ex);
            }
            return RedirectToAction("ListBrand", "Brand");
        }

        [HttpGet]
        public IActionResult UpdateBrand(int Id)
        {
            Brand brand = null;
            try
            {
                brand = brandService.GetBrand(Id);
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex);
            }

            if (brand == null)
            {
                TempData["AlertType"] = ActionTypes.Error.ToString();
                return RedirectToAction("ListBrand", "Brand");
            }
            else
            {
                return View(brand);
            }
        }

        [HttpPost]
        public IActionResult UpdateBrand(Brand brand)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    brand = brandService.UpdateBrand(brand);
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
                return RedirectToAction("ListBrand", "Brand");
            }
            else
            {
                return View(brand);
            }
        }

        [HttpGet]
        public IActionResult ListBrand()
        {
            List<Brand> brands = null;
            try
            {
                brands = brandService.GetBrands();
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex);
                throw;
            }
            return View(brands);
        }
    }
}
