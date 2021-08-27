using System.Collections.Generic;
using bois.PetShopApplication.Core.Models;

namespace bois.PetShopApplication.Core.IServices
{
    public interface IPetTypeService
    {
        List<PetType> GetPetTypes();
        PetType FindByName(string name);
        PetType FindById(int id);
        PetType Add(PetType petType);
    }
}