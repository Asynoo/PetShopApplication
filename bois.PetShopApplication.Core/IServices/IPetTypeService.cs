using System.Collections.Generic;
using bois.PetShopApplication.Core.Models;

namespace bois.PetShopApplication.Core.IServices
{
    public interface IPetTypeService
    {
        List<Type> GetPetTypes();
        Type FindByName(string name);
        Type FindById(int id);
        Type Add(Type type);
    }
}