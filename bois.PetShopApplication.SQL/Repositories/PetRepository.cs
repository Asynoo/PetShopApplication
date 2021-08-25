using System.Collections.Generic;
using bois.PetShopApplication.Core.Models;
using bois.PetShopApplication.Domain.IRepositories;
using bois.PetShopApplication.SQL.Converters;
using bois.PetShopApplication.SQL.Entities;

namespace bois.PetShopApplication.SQL.Repositories
{
    public class PetRepository : IPetRepository
    {
        private static List<PetEntity> _petTable = new List<PetEntity>();
        private static int _id = 1;
        private readonly PetConverter _petConverter;

        public PetRepository()
        {
            _petConverter = new PetConverter();
        }

        public Pet Add(Pet pet)
        {
            var petEntity = _petConverter.Convert(pet);
            petEntity.Id = _id++;
            _petTable.Add(petEntity);
            return _petConverter.Convert(petEntity);
        }

        public List<Pet> FindAll()
        {
            var listOfPets = new List<Pet>();
            foreach (var petEntity in _petTable)
            {
                listOfPets.Add(_petConverter.Convert(petEntity));
            }

            return listOfPets;
        }
    }
}