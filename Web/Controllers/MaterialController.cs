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
    public class MaterialController : Controller
    {
        private readonly IMaterialService materialService;

        public MaterialController(IMaterialService materialService)
        {
            this.materialService = materialService;
        }

        [HttpGet]
        public IActionResult CreateMaterial()
        {
            return View();
        }

        [HttpPost]
        public IActionResult CreateMaterial(Material material)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    materialService.AddMaterial(material);
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

            if (material.Id > 0)
            {
                return RedirectToAction("ListMaterial", "Material");
            }
            else
            {
                return View(material);
            }
        }

        public ActionResult DeleteMaterial(int Id)
        {
            Material material = null;
            try
            {
                material = materialService.GetMaterial(Id);
                material.Status = 0;
                materialService.UpdateMaterial(material);
                TempData["AlertType"] = ActionTypes.Delete.ToString();
            }
            catch (Exception ex)
            {
                TempData["AlertType"] = ActionTypes.Error.ToString();
                Console.WriteLine(ex);
            }
            return RedirectToAction("ListMaterial", "Material");
        }

        [HttpGet]
        public IActionResult UpdateMaterial(int Id)
        {
            Material material = null;
            try
            {
                material = materialService.GetMaterial(Id);
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex);
            }

            if (material == null)
            {
                TempData["AlertType"] = ActionTypes.Error.ToString();
                return RedirectToAction("ListMaterial", "Material");
            }
            else
            {
                return View(material);
            }
        }

        [HttpPost]
        public IActionResult UpdateMaterial(Material material)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    material = materialService.UpdateMaterial(material);
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
                return RedirectToAction("ListMaterial", "Material");
            }
            else
            {
                return View(material);
            }
        }

        [HttpGet]
        public IActionResult ListMaterial()
        {
            List<Material> materials = null;
            try
            {
                materials = materialService.GetMaterials();
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex);
                throw;
            }
            return View(materials);
        }
    }
}
