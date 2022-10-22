using System.Collections.Generic;
using Domain.Models;
using static Domain.Constants.Constants;

namespace Application.Interfaces
{
    public interface ISizeService
    {
        Size AddSize(Size size);
        Size GetSize(int Id);
        Size UpdateSize(Size size);
        List<Size> GetSizes();
        List<Size> GetSizes(StatusCodes status);
    }
}
