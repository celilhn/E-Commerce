using System;
using System.Collections.Generic;
using System.Linq;
using Domain.Constants;
using Domain.Interfaces;
using Domain.Models;
using Infrastructure.Context;
using Microsoft.EntityFrameworkCore;

namespace Infrastructure.Repositories
{
    public class BrandRepository : IBrandRepository
    {
        private readonly ECommerceDbContext context;
        public BrandRepository(ECommerceDbContext context)
        {
            this.context = context;
        }

        public Brand AddBrand(Brand brand)
        {
            context.Brands.Add(brand);
            context.SaveChanges();
            return brand;
        }

        public Brand GetBrand(int Id)
        {
            return context.Brands.SingleOrDefault(x => x.Id == Id);
        }

        public Brand UpdateBrand(Brand brand)
        {
            context.Entry(brand).State = EntityState.Modified;
            context.SaveChanges();
            return brand;
        }

        public List<Brand> GetBrands()
        {
            return context.Brands.ToList();
        }

        public List<Brand> GetBrands(Constants.StatusCodes status)
        {
            return context.Brands.Where(x => x.Status == status).ToList();
        }
    }
}
