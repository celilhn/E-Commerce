using System.Collections.Generic;
using System.Linq;
using Domain.Interfaces;
using Domain.Models;
using Infrastructure.Context;
using Microsoft.EntityFrameworkCore;
using static Domain.Constants.Constants;

namespace Infrastructure.Repositories
{
    public class FaqRepository : IFaqRepository
    {
        private readonly ECommerceDbContext context;
        public FaqRepository(ECommerceDbContext context)
        {
            this.context = context;
        }

        public Faq AddFaq(Faq faq)
        {
            context.Faqs.Add(faq);
            context.SaveChanges();
            return faq;
        }

        public Faq UpdateFaq(Faq faq)
        {
            context.Entry(faq).State = EntityState.Modified;
            context.SaveChanges();
            return faq;
        }

        public Faq GetFaq(int Id)
        {
            return context.Faqs.SingleOrDefault(x => x.Id == Id);
        }

        public List<Faq> GetFags()
        {
            return context.Faqs.Where(x=>x.Status!= StatusCodes.Deleted).ToList();
        }

        public List<Faq> GetFags(StatusCodes status)
        {
            return context.Faqs.Where(x => x.Status == status).ToList();
        }
    }
}
