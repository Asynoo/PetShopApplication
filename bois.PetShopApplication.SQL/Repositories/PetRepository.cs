using System.Collections.Generic;
using System.Linq;
using bois.PetShopApplication.Core.Models;
using bois.PetShopApplication.Domain.IRepositories;
using bois.PetShopApplication.SQL.Converters;
using bois.PetShopApplication.SQL.Entities;

namespace bois.PetShopApplication.SQL.Repositories
{
    public class Repository : IPetRepository
    {
        private static readonly List<PetEntity> Table = new();
        private static int _id = 1;
        private readonly Converter _petConverter;

        public Repository()
        {
            _petConverter = new Converter();
        }

        public Pet Add(Pet pet)
        {
            var petEntity = Converter.Convert(pet);
            petEntity.Id = _id++;
            Table.Add(petEntity);
            return Converter.Convert(petEntity);
        }

        public List<Pet> FindAll()
        {
            return Table.Select(Converter.Convert).ToList();
        }
    }
}