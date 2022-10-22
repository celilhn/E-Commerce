using System;
using System.Collections.Generic;
using Application.Interfaces;
using Domain.Interfaces;
using Domain.Models;
using static Domain.Constants.Constants;

namespace Application.Services
{
    public class FaqService : IFaqService
    {
        private readonly IFaqRepository faqRepository;
        public FaqService(IFaqRepository faqRepository)
        {
            this.faqRepository = faqRepository;
        }
        public Faq AddFaq(Faq faq)
        {
            return faqRepository.AddFaq(faq);
        }

        public Faq UpdateFaq(Faq faq)
        {
            faq.UpdateDate = DateTime.Now;
            return faqRepository.UpdateFaq(faq);
        }

        public Faq GetFaq(int Id)
        {
            return faqRepository.GetFaq(Id);
        }

        public List<Faq> GetFags()
        {
            return faqRepository.GetFags();
        }

        public List<Faq> GetFags(StatusCodes status)
        {
            return faqRepository.GetFags(status);
        }
    }
}
