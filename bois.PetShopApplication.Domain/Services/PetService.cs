using System.Collections.Generic;
using bois.PetShopApplication.Core.IServices;
using bois.PetShopApplication.Core.Models;
using bois.PetShopApplication.Domain.IRepositories;

namespace bois.PetShopApplication.Domain.Services
{
    public class Service : IPetService
    {
        private readonly IPetRepository _repo;

        public Service(IPetRepository repo)
        {
            _repo = repo;
        }

        public List<Pet> GetPets()
        {
            return _repo.FindAll();
        }

        public Pet Add(Pet pet)
        {
            _repo.Add(pet);
            return pet;
        }
    }
}