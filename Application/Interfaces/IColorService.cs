using System.Collections.Generic;
using Domain.Models;
using static Domain.Constants.Constants;

namespace Application.Interfaces
{
    public interface IColorService
    {
        Color AddColor(Color color);
        Color GetColor(int id);
        Color UpdateColor(Color color);
        List<Color> GetColors();
        List<Color> GetColors(StatusCodes status);
        bool IsColorExist(string name);
        bool ControlColorIsExistWithParameters(int id, string name);
    }
}
