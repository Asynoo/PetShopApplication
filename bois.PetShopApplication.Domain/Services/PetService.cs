using System.Collections.Generic;
using bois.PetShopApplication.Core.IServices;
using bois.PetShopApplication.Core.Models;
using bois.PetShopApplication.Domain.IRepositories;

namespace bois.PetShopApplication.Domain.Services
{
    public class PetService : IPetService
    {
        private readonly IPetRepository _repo;

        public PetService(IPetRepository repo)
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