using System;
using System.Collections.Generic;
using bois.PetShopApplication.Core.Models;
using bois.PetShopApplication.Domain.IRepositories;

namespace bois.PetShopApplication.DataAccess.Repositories
{
    public class PetRepositoryInMemory : IPetRepository
    {
        private static readonly List<Pet> PetTable = new()
        {
            new Pet
            {
                Id = 1, Color = "Red", Birthdate = DateTime.Now, Name = "Charlie",
                Type = new PetType {Id = 1, Name = "Monkey"},
                Price = 3, SoldDate = DateTime.Now.AddDays(-15)
            },
            new Pet
            {
                Id = 2, Color = "Green", Birthdate = DateTime.Now, Name = "Brad",
                Type = new PetType {Id = 1, Name = "Monkey"},
                Price = 25, SoldDate = DateTime.Now.AddDays(-15)
            },
            new Pet
            {
                Id = 3, Color = "Blue", Birthdate = DateTime.Now, Name = "Wukong",
                Type = new PetType {Id = 1, Name = "Monkey"},
                Price = 96, SoldDate = DateTime.Now.AddDays(-15)
            },
            new Pet
            {
                Id = 4, Color = "Yellow", Birthdate = DateTime.Now, Name = "Snoopy",
                Type = new PetType {Id = 2, Name = "Dog"}, Price = 3220,
                SoldDate = DateTime.Now.AddYears(-15)
            },
            new Pet
            {
                Id = 5, Color = "Black", Birthdate = DateTime.Now, Name = "Chip",
                Type = new PetType {Id = 2, Name = "Dog"}, Price = 230,
                SoldDate = DateTime.Now.AddYears(-15)
            },
            new Pet
            {
                Id = 6, Color = "Orange", Birthdate = DateTime.Now, Name = "Chuck",
                Type = new PetType {Id = 2, Name = "Dog"}, Price = 199,
                SoldDate = DateTime.Now.AddYears(-15)
            },
            new Pet
            {
                Id = 7, Color = "Purple", Birthdate = DateTime.Now, Name = "Jamie",
                Type = new PetType {Id = 3, Name = "Cat"},
                Price = 169, SoldDate = DateTime.Now.AddMilliseconds(-15)
            },
            new Pet
            {
                Id = 8, Color = "Pink", Birthdate = DateTime.Now, Name = "Evelyn",
                Type = new PetType {Id = 3, Name = "Cat"},
                Price = 25, SoldDate = DateTime.Now.AddMilliseconds(-15)
            },
            new Pet
            {
                Id = 9, Color = "Brown", Birthdate = DateTime.Now, Name = "Spirit",
                Type = new PetType {Id = 3, Name = "Cat"},
                Price = 350, SoldDate = DateTime.Now.AddMilliseconds(-15)
            }
        };


        private static int _id = 9;
        public Pet Add(Pet pet)
        {
            pet.Id = _id++;
            PetTable.Add(pet);
            return pet;
        }

        public List<Pet> FindAll()
        {
            return PetTable;
        }
    }
}