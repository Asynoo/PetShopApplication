using System.Collections.Generic;
using bois.PetShopApplication.Core.Models;

namespace bois.PetShopApplication.Core.IServices
{
    public interface IPetService
    {
        Pet Create(Pet pet);

        List<Pet> ReadAll();
    }
}