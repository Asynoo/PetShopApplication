using System;
using System.Collections.Generic;
using bois.PetShopApplication.Core.Models;
using bois.PetShopApplication.Domain.IRepositories;

namespace bois.PetShopApplication.DataAccess.Repositories
{
    public class PetRepositoryInMemory : IPetRepository
    {
        private static readonly List<Pet> _petTable = new()
        {
            new Pet
            {
                Id = 1, Color = "Red", Birthdate = DateTime.Now, Name = "Charlie",
                Type = new PetType {Id = 1, Name = "Monkey"},
                Price = 19, SoldDate = DateTime.Now.AddDays(-15)
            },
            new Pet
            {
                Id = 2, Color = "Red", Birthdate = DateTime.Now, Name = "Brad",
                Type = new PetType {Id = 1, Name = "Monkey"},
                Price = 19, SoldDate = DateTime.Now.AddDays(-15)
            },
            new Pet
            {
                Id = 3, Color = "Red", Birthdate = DateTime.Now, Name = "Wukong",
                Type = new PetType {Id = 1, Name = "Monkey"},
                Price = 19, SoldDate = DateTime.Now.AddDays(-15)
            },
            new Pet
            {
                Id = 4, Color = "Blue", Birthdate = DateTime.Now, Name = "Snoopy",
                Type = new PetType {Id = 2, Name = "Dog"}, Price = 19,
                SoldDate = DateTime.Now.AddYears(-15)
            },
            new Pet
            {
                Id = 5, Color = "Blue", Birthdate = DateTime.Now, Name = "Chip",
                Type = new PetType {Id = 2, Name = "Dog"}, Price = 19,
                SoldDate = DateTime.Now.AddYears(-15)
            },
            new Pet
            {
                Id = 6, Color = "Blue", Birthdate = DateTime.Now, Name = "Chuck",
                Type = new PetType {Id = 2, Name = "Dog"}, Price = 19,
                SoldDate = DateTime.Now.AddYears(-15)
            },
            new Pet
            {
                Id = 7, Color = "Green", Birthdate = DateTime.Now, Name = "Jamie",
                Type = new PetType {Id = 3, Name = "Cat"},
                Price = 19, SoldDate = DateTime.Now.AddMilliseconds(-15)
            },
            new Pet
            {
                Id = 8, Color = "Green", Birthdate = DateTime.Now, Name = "Evelyn",
                Type = new PetType {Id = 3, Name = "Cat"},
                Price = 19, SoldDate = DateTime.Now.AddMilliseconds(-15)
            },
            new Pet
            {
                Id = 9, Color = "Green", Birthdate = DateTime.Now, Name = "Spirit",
                Type = new PetType {Id = 3, Name = "Cat"},
                Price = 19, SoldDate = DateTime.Now.AddMilliseconds(-15)
            }
        };


        private static int _id = 9;
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