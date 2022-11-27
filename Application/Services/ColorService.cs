using System.Collections.Generic;
using Application.Interfaces;
using Domain.Interfaces;
using Domain.Models;
using static Domain.Constants.Constants;

namespace Application.Services
{
    public class ColorService : IColorService
    {
        private readonly IColorRepository colorRepository;
        public ColorService(IColorRepository colorRepository)
        {
            this.colorRepository = colorRepository;
        }

        public Color AddColor(Color color)
        {
            return colorRepository.AddColor(color);
        }

        public Color GetColor(int id)
        {
            return colorRepository.GetColor(id);
        }

        public Color UpdateColor(Color color)
        {
            return colorRepository.UpdateColor(color);
        }

        public List<Color> GetColors()
        {
            return colorRepository.GetColors();
        }

        public List<Color> GetColors(StatusCodes status)
        {
            return colorRepository.GetColors(status);
        }

        public bool IsColorExist(string name)
        {
            return colorRepository.IsColorExist(name);
        }

        public bool ControlColorIsExistWithParameters(int id, string name)
        {
            return colorRepository.ControlColorIsExistWithParameters(id, name);
        }
    }
}
