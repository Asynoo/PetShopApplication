using System.Collections.Generic;
using bois.PetShopApplication.Core.Models;
using bois.PetShopApplication.Domain.IRepositories;

namespace bois.PetShopApplication.DataAccess.Repositories
{

    public class PetTypeRepositoryMemory : IPetTypeRepository
    {
        private static List<PetType> _petTypesTable = new List<PetType>();
        private static int _id = 1;
        public PetType Add(PetType petType)
        {
            petType.Id = _id++;
            _petTypesTable.Add(petType);
            return petType;
        }

        public List<PetType> FindAll()
        {
            return _petTypesTable;
        }
    }
}