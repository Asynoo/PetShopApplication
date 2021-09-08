using System.Collections.Generic;
using bois.PetShopApplication.Core.IServices;
using bois.PetShopApplication.Core.Models;
using bois.PetShopApplication.Domain.IRepositories;

namespace bois.PetShopApplication.Domain.Services
{
    public class TypeService : IPetTypeService
    {
        private readonly IPetTypeRepository _repo;

        public TypeService(IPetTypeRepository repo)
        {
            _repo = repo;
        }

        public List<Type> GetPetTypes()
        {
            return _repo.FindAll();
        }

        public Type Add(Type type)
        {
            return _repo.Add(type);
        }

        public Type FindByName(string name)
        {
            return GetPetTypes().Find(type => type.Name == name);
        }

        public Type FindById(int id)
        {
            return GetPetTypes().Find(type => type.Id == id);
        }
    }
}