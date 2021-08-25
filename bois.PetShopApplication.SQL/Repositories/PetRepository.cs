using System.Collections.Generic;
using bois.PetShopApplication.Core.Models;
using bois.PetShopApplication.Domain.IRepositories;

namespace bois.PetShopApplication.SQL.Repositories
{
    public class PetRepository : IPetRepository
    {
        public IEnumerable<Pet> ReadPets()
        {
            throw new System.NotImplementedException();
        }
    }
}