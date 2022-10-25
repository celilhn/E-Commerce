using System;
using System.Collections.Generic;
using Application.Filters;
using Application.Interfaces;
using Domain.Models;
using Microsoft.AspNetCore.Mvc;
using static Domain.Constants.Constants;

namespace Web.Controllers
{
    public class FaqController : Controller
    {
        private readonly IFaqService faqService;

        public FaqController(IFaqService faqService)
        {
            this.faqService = faqService;
        }

        public IActionResult Faq()
        {
            List<Faq> faqs = null;
            try
            {
                faqs = faqService.GetFags(StatusCodes.Active);
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex);
            }
            return View(faqs);
        }

        [HttpGet]
        [Authorize(UserTypes.Admin)]
        public IActionResult CreateFaq()
        {
            return View();
        }

        [HttpPost]
        [Authorize(UserTypes.Admin)]
        public IActionResult CreateFaq(Faq faq)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    faqService.AddFaq(faq);
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

            if (faq.Id > 0)
            {
                return RedirectToAction("ListFaqs", "Faq");
            }
            else
            {
                return View(faq);
            }
        }
        
        [Authorize(UserTypes.Admin)]
        public ActionResult DeleteFaq(int Id)
        {
            Faq faq = null;
            try
            {
                faq = faqService.GetFaq(Id);
                faq.Status = 0;
                faqService.UpdateFaq(faq);
                TempData["AlertType"] = ActionTypes.Delete.ToString();
            }
            catch (Exception ex)
            {
                TempData["AlertType"] = ActionTypes.Error.ToString();
                Console.WriteLine(ex);
            }
            return RedirectToAction("ListFaqs", "Faq");
        }

        [HttpGet]
        [Authorize(UserTypes.Admin)]
        public IActionResult UpdateFaq(int Id)
        {
            Faq faq = null;
            try
            {
                faq = faqService.GetFaq(Id);
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex);
            }

            if (faq == null)
            {
                TempData["AlertType"] = ActionTypes.Error.ToString();
                return RedirectToAction("ListFaqs", "Faq");
            }
            else
            {
                return View(faq);
            }
        }

        [HttpPost]
        [Authorize(UserTypes.Admin)]
        public IActionResult UpdateFaq(Faq faq)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    faq = faqService.UpdateFaq(faq);
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
                return RedirectToAction("ListFaqs", "Faq");
            }
            else
            {
                return View(faq);
            }
        }
        
        [HttpGet]
        [Authorize(UserTypes.Admin)]
        public IActionResult ListFaqs()
        {
            List<Faq> faqs = null;
            try
            {
                faqs = faqService.GetFags();
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex);
                throw;
            }
            return View(faqs);
        }
    }
}
