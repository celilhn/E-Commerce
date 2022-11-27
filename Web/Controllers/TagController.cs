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
    public class TagController : Controller
    {
        private readonly ITagService tagService;

        public TagController(ITagService tagService)
        {
            this.tagService = tagService;
        }

        [HttpGet]
        public IActionResult CreateTag()
        {
            return View();
        }

        [HttpPost]
        public IActionResult CreateTag(Tag tag)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    tagService.AddTag(tag);
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

            if (tag.Id > 0)
            {
                return RedirectToAction("ListTags", "Tag");
            }
            else
            {
                return View(tag);
            }
        }

        public ActionResult DeleteTag(int id)
        {
            Tag tag = null;
            try
            {
                tag = tagService.GetTag(id);
                tag.Status = StatusCodes.Deleted;
                tagService.UpdateTag(tag);
                TempData["AlertType"] = ActionTypes.Delete.ToString();
            }
            catch (Exception ex)
            {
                TempData["AlertType"] = ActionTypes.Error.ToString();
                Console.WriteLine(ex);
            }
            return RedirectToAction("ListTags", "Tag");
        }

        [HttpGet]
        public IActionResult UpdateTag(int id)
        {
            Tag tag = null;
            try
            {
                tag = tagService.GetTag(id);
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex);
            }

            if (tag == null)
            {
                TempData["AlertType"] = ActionTypes.Error.ToString();
                return RedirectToAction("ListTags", "Tag");
            }
            else
            {
                return View(tag);
            }
        }

        [HttpPost]
        public IActionResult UpdateTag(Tag tag)
        {
            try
            {
                ViewBag.IsModelStateValid = false;
                if (ModelState.IsValid)
                {
                    tag = tagService.UpdateTag(tag);
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
                return RedirectToAction("ListTags", "Tag");
            }
            else
            {
                return View(tag);
            }
        }

        [HttpGet]
        public IActionResult ListTags()
        {
            List<Tag> tags = null;
            try
            {
                tags = tagService.GetTags();
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex);
            }
            return View(tags);
        }
    }
}
