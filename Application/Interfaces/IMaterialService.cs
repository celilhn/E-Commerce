using System.Collections.Generic;
using Domain.Models;
using static Domain.Constants.Constants;

namespace Application.Interfaces
{
    public interface IMaterialService
    {
        Material AddMaterial(Material material);
        Material GetMaterial(int Id);
        Material UpdateMaterial(Material material);
        List<Material> GetMaterials();
        List<Material> GetMaterials(StatusCodes status);
        bool IsMaterialExist(string name);
        bool ControlMaterialIsExistWithParameters(int id, string name);
    }
}
