using System.Collections.Generic;
using System.Linq;
using Domain.Interfaces;
using Domain.Models;
using Infrastructure.Context;
using Microsoft.EntityFrameworkCore;
using static Domain.Constants.Constants;

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
            return context.Sizes.Where(x=>x.Status != StatusCodes.Deleted).ToList();
        }

        public List<Size> GetSizes(StatusCodes status)
        {
            return context.Sizes.Where(x => x.Status == status).ToList();
        }
        public bool IsSizeExist(string name)
        {
            return context.Sizes.Any(x => x.Name == name && x.Status != StatusCodes.Deleted);
        }

        public bool ControlSizeIsExistWithParameters(int id, string name)
        {
            return context.Sizes.Any(x => x.Id == id && x.Name == name && x.Status != StatusCodes.Deleted);
        }
    }
}
