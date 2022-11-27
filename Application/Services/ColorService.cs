using System;
using System.Collections.Generic;
using Application.Interfaces;
using Domain.Interfaces;
using Domain.Models;
using static Domain.Constants.Constants;

namespace Application.Services
{
    public class ColorService : IColorService
    {
        private readonly IColorService colorService;
        public ColorService(IColorService colorService)
        {
            this.colorService = colorService;
        }

        public Color AddColor(Color color)
        {
            return colorService.AddColor(color);
        }

        public Color GetColor(int id)
        {
            return colorService.GetColor(id);
        }

        public Color UpdateColor(Color color)
        {
            return colorService.UpdateColor(color);
        }

        public List<Color> GetColors()
        {
            return colorService.GetColors();
        }

        public List<Color> GetColors(StatusCodes status)
        {
            return colorService.GetColors(status);
        }

        public bool IsColorExist(string name)
        {
            return colorService.IsColorExist(name);
        }

        public bool ControlColorIsExistWithParameters(int id, string name)
        {
            return colorService.ControlColorIsExistWithParameters(id, name);
        }
    }
}
