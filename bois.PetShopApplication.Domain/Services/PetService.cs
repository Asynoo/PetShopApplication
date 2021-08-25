using System.Collections.Generic;
using bois.PetShopApplication.Core.IServices;
using bois.PetShopApplication.Core.Models;
using bois.PetShopApplication.Domain.IRepositories;

namespace bois.PetShopApplication.Domain.Services
{
    public class PetService : IPetService
    {
        private IPetRepository _repo;
        
        public PetService(IPetRepository repo)
        {
            _repo = repo;
        }

        public Pet Create(Pet pet)
        {
            return _repo.Add(pet);
        }

        public List<Pet> ReadAll()
        {
            return _repo.FindAll();
        }
    }
}