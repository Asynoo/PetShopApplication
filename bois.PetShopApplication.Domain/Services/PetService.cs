using System.Collections.Generic;
using bois.PetShopApplication.Core.IServices;
using bois.PetShopApplication.Core.Models;
using bois.PetShopApplication.Domain.IRepositories;

namespace bois.PetShopApplication.Domain.Services
{
    public class PetService : IPetService
    {
        public PetService(IPetRepository repo)
        {
            throw new System.NotImplementedException();
        }

        public List<Pet> GetPets()
        {   
            throw new System.NotImplementedException();
        }
    }
}