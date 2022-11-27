using System.Collections.Generic;
using System.Linq;
using Domain.Interfaces;
using Domain.Models;
using Infrastructure.Context;
using Microsoft.EntityFrameworkCore;
using static Domain.Constants.Constants;

namespace Infrastructure.Repositories
{
    public class ColorRepository : IColorRepository
    {
        private readonly ECommerceDbContext context;
        public ColorRepository(ECommerceDbContext context)
        {
            this.context = context;
        }

        public Color AddColor(Color color)
        {
            context.Colors.Add(color);
            context.SaveChanges();
            return color;
        }

        public Color GetColor(int id)
        {
            return context.Colors.SingleOrDefault(x => x.Id == id);
        }

        public Color UpdateColor(Color color)
        {
            context.Entry(color).State = EntityState.Modified;
            context.SaveChanges();
            return color;
        }

        public List<Color> GetColors()
        {
            return context.Colors.Where(x => x.Status != StatusCodes.Deleted).ToList();
        }

        public List<Color> GetColors(StatusCodes status)
        {
            return context.Colors.Where(x => x.Status == status).ToList();
        }

        public bool IsColorExist(string name)
        {
            return context.Colors.Any(x => x.Name == name && x.Status != StatusCodes.Deleted);
        }

        public bool ControlColorIsExistWithParameters(int id, string name)
        {
            return context.Colors.Any(x => x.Id == id && x.Name == name && x.Status != StatusCodes.Deleted);
        }
    }
}
