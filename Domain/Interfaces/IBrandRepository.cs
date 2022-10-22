using System.Collections.Generic;
using Domain.Models;
using static Domain.Constants.Constants;

namespace Domain.Interfaces
{
    public interface IBrandRepository
    {
        Brand AddBrand(Brand brand);
        Brand GetBrand(int Id);
        Brand UpdateBrand(Brand brand);
        List<Brand> GetBrands();
        List<Brand> GetBrands(StatusCodes status);
    }
}
