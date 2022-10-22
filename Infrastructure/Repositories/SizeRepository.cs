using System.Collections.Generic;
using System.Linq;
using Domain.Constants;
using Domain.Interfaces;
using Domain.Models;
using Infrastructure.Context;
using Microsoft.EntityFrameworkCore;

namespace Infrastructure.Repositories
{
    public class SizeRepository: ISizeRepository
    {
        private readonly ECommerceDbContext context;
        public SizeRepository(ECommerceDbContext context)
        {
            this.context = context;
        }

        public Size AddSize(Size size)
        {
            context.Sizes.Add(size);
            context.SaveChanges();
            return size;
        }

        public Size GetSize(int Id)
        {
            return context.Sizes.SingleOrDefault(x => x.Id == Id);
        }

        public Size UpdateSize(Size size)
        {
            context.Entry(size).State = EntityState.Modified;
            context.SaveChanges();
            return size;
        }

        public List<Size> GetSizes()
        {
            return context.Sizes.ToList();
        }

        public List<Size> GetSizes(Constants.StatusCodes status)
        {
            return context.Sizes.Where(x => x.Status == status).ToList();
        }
    }
}
