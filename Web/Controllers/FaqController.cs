using System;
using System.Collections.Generic;
using Application.Interfaces;
using Domain.Models;
using Microsoft.AspNetCore.Mvc;

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
                faqs = faqService.GetFags();
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex);
            }
            return View(faqs);
        }
    }
}
