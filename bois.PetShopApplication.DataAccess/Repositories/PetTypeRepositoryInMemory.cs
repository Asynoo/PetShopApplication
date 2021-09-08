using System.Collections.Generic;
using bois.PetShopApplication.Core.Models;
using bois.PetShopApplication.Domain.IRepositories;

namespace bois.PetShopApplication.DataAccess.Repositories
{
    public class PetTypeRepositoryMemory : IPetTypeRepository
    {
        private static readonly List<PetType> PetTypesTable = new()
        {
            new PetType {Id = 1, Name = "Monkey"},
            new PetType {Id = 2, Name = "Dog"},
            new PetType {Id = 3, Name = "Cat"}
        };

        private static int _id = 4;

        public PetType Add(PetType petType)
        {
            petType.Id = _id++;
            PetTypesTable.Add(petType);
            return petType;
        }

        public List<PetType> FindAll()
        {
            return PetTypesTable;
        }
    }
}