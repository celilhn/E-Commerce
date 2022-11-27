using System.Collections.Generic;
using System.Linq;
using Domain.Constants;
using Domain.Interfaces;
using Domain.Models;
using Infrastructure.Context;
using Microsoft.EntityFrameworkCore;
using static Domain.Constants.Constants;

namespace Infrastructure.Repositories
{
    public class MaterialRepository : IMaterialRepository
    {
        private readonly ECommerceDbContext context;
        public MaterialRepository(ECommerceDbContext context)
        {
            this.context = context;
        }

        public Material AddMaterial(Material material)
        {
            context.Materials.Add(material);
            context.SaveChanges();
            return material;
        }

        public Material GetMaterial(int Id)
        {
            return context.Materials.SingleOrDefault(x => x.Id == Id);
        }

        public Material UpdateMaterial(Material material)
        {
            context.Entry(material).State = EntityState.Modified;
            context.SaveChanges();
            return material;
        }

        public List<Material> GetMaterials()
        {
            return context.Materials.Where(x => x.Status != StatusCodes.Deleted).ToList();
        }

        public List<Material> GetMaterials(Constants.StatusCodes status)
        {
            return context.Materials.Where(x => x.Status == status).ToList();
        }

        public bool IsMaterialExist(string name)
        {
            return context.Materials.Any(x => x.Name == name && x.Status != StatusCodes.Deleted);
        }

        public bool ControlMaterialIsExistWithParameters(int id, string name)
        {
            return context.Materials.Any(x => x.Id == id && x.Name == name && x.Status != StatusCodes.Deleted);
        }
    }
}
