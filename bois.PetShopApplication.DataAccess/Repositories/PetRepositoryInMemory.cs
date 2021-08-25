using System.Collections.Generic;
using bois.PetShopApplication.Core.Models;
using bois.PetShopApplication.Domain.IRepositories;

namespace bois.PetShopApplication.DataAccess.Repositories
{
    public class PetRepositoryInMemory : IPetRepository
    {
        private static List<Pet> _petTable = new List<Pet>();
        private static int _id = 0;
        public Pet Add(Pet pet)
        {
            pet.Id = _id++;
            _petTable.Add(pet);
            return pet;
        }

        public List<Pet> FindAll()
        {
            return _petTable;
        }
    }
}