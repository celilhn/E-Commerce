using System.Collections.Generic;
using Domain.Models;
using static Domain.Constants.Constants;

namespace Domain.Interfaces
{
    public interface ISizeRepository
    {
        Size AddSize(Size size);
        Size GetSize(int Id);
        Size UpdateSize(Size size);
        List<Size> GetSizes();
        List<Size> GetSizes(StatusCodes status);
        bool IsSizeExist(string name);
        bool ControlSizeIsExistWithParameters(int id, string name);
    }
}
