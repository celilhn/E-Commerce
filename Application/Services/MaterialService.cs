using System;
using System.Collections.Generic;
using Application.Interfaces;
using Domain.Interfaces;
using Domain.Models;
using static Domain.Constants.Constants;

namespace Application.Services
{
    public class MaterialService : IMaterialService
    {
        private readonly IMaterialRepository materialRepository;

        public MaterialService(IMaterialRepository materialRepository)
        {
            this.materialRepository = materialRepository;
        }

        public Material AddMaterial(Material material)
        {
            return this.materialRepository.AddMaterial(material);
        }

        public Material GetMaterial(int Id)
        {
            return materialRepository.GetMaterial(Id);
        }

        public Material UpdateMaterial(Material material)
        {
            return materialRepository.UpdateMaterial(material);
        }

        public List<Material> GetMaterials()
        {
            return materialRepository.GetMaterials();
        }

        public List<Material> GetMaterials(StatusCodes status)
        {
            return materialRepository.GetMaterials(status);
        }

        public bool IsMaterialExist(string name)
        {
            return materialRepository.IsMaterialExist(name);
        }

        public bool ControlMaterialIsExistWithParameters(int id, string name)
        {
            return materialRepository.ControlMaterialIsExistWithParameters(id, name);
        }
    }
}
