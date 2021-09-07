using System;
using System.Collections.Generic;
using bois.PetShopApplication.Core.Models;
using bois.PetShopApplication.Domain.IRepositories;

namespace bois.PetShopApplication.DataAccess.Repositories
{
    public class PetRepositoryInMemory : IPetRepository
    {
        private static List<Pet> _petTable = new()
        {
            new Pet
            {
                Id = 1, Color = "Red", Birthdate = DateTime.Now, Name = "Bente", Type = new PetType{Id = 1, Name = "Monkey"},
                Price = 19, SoldDate = DateTime.Now.AddDays(-15)
            },
            new Pet
            {
                Id = 4, Color = "Red", Birthdate = DateTime.Now, Name = "Bente1", Type = new PetType{Id = 1, Name = "Monkey"},
                Price = 19, SoldDate = DateTime.Now.AddDays(-15)
            },
            new Pet
            {
                Id = 5, Color = "Red", Birthdate = DateTime.Now, Name = "Bente2", Type = new PetType{Id = 1, Name = "Monkey"},
                Price = 19, SoldDate = DateTime.Now.AddDays(-15)
            },
            new Pet
            {
                Id = 2, Color = "Blue", Birthdate = DateTime.Now, Name = "Bent", Type = new PetType{Id = 2, Name = "Dog"}, Price = 19,
                SoldDate = DateTime.Now.AddYears(-15)
            },
            new Pet
            {
                Id = 6, Color = "Blue", Birthdate = DateTime.Now, Name = "Bent1", Type = new PetType{Id = 2, Name = "Dog"}, Price = 19,
                SoldDate = DateTime.Now.AddYears(-15)
            },
            new Pet
            {
                Id = 7, Color = "Blue", Birthdate = DateTime.Now, Name = "Bent2", Type = new PetType{Id = 2, Name = "Dog"}, Price = 19,
                SoldDate = DateTime.Now.AddYears(-15)
            },
            new Pet
            {
                Id = 3, Color = "Green", Birthdate = DateTime.Now, Name = "Ben", Type = new PetType{Id = 3 ,Name = "Cat"},
                Price = 19, SoldDate = DateTime.Now.AddMilliseconds(-15)
            },
            new Pet
            {
                Id = 8, Color = "Green", Birthdate = DateTime.Now, Name = "Ben1", Type = new PetType{Id = 3 , Name = "Cat"},
                Price = 19, SoldDate = DateTime.Now.AddMilliseconds(-15)
            },
            new Pet
            {
                Id = 9, Color = "Green", Birthdate = DateTime.Now, Name = "Ben2", Type = new PetType{Id = 3 , Name = "Cat"},
                Price = 19, SoldDate = DateTime.Now.AddMilliseconds(-15)
            },
        };
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