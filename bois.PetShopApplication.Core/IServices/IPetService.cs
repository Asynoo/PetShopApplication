using System.Collections.Generic;
using bois.PetShopApplication.Core.Models;

namespace bois.PetShopApplication.Core.IServices
{
    public interface IPetService
    {
        List<Pet> GetPets();

        Pet Add(Pet pet);
    }
}