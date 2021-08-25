using System.Collections.Generic;
using bois.PetShopApplication.Core.Models;

namespace bois.PetShopApplication.Domain.IRepositories
{
    public interface IPetRepository
    {
        Pet Add(Pet pet);

        List<Pet> FindAll();
    }
}