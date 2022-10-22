using System.Collections.Generic;
using Application.Interfaces;
using Domain.Interfaces;
using Domain.Models;
using static Domain.Constants.Constants;

namespace Application.Services
{
    public class BrandService: IBrandService
    {
        private readonly IBrandRepository brandRepository;
        public BrandService(IBrandRepository brandRepository)
        {
            this.brandRepository = brandRepository;
        }

        public Brand AddBrand(Brand brand)
        {
            return brandRepository.AddBrand(brand);
        }

        public Brand GetBrand(int Id)
        {
            return brandRepository.GetBrand(Id);
        }

        public Brand UpdateBrand(Brand brand)
        {
            return brandRepository.UpdateBrand(brand);
        }

        public List<Brand> GetBrands()
        {
            return brandRepository.GetBrands();
        }

        public List<Brand> GetBrands(StatusCodes status)
        {
            return brandRepository.GetBrands(status);
        }
    }
}
