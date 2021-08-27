using System;
using bois.PetShopApplication.Core.IServices;
using bois.PetShopApplication.DataAccess.Repositories;
using bois.PetShopApplication.Domain.IRepositories;
using bois.PetShopApplication.Domain.Services;
using bois.PetShopApplication.SQL.Repositories;

namespace bois.PetShop
{
    class Program
    {
        static void Main(string[] args)
        {
            var petRepo = new PetRepositoryInMemory();
            var petService = new PetService(petRepo);
            
            var petTypeRepo = new PetTypeRepositoryMemory();
            var petTypeService = new PetTypeService(petTypeRepo);
            var printer = new Printer(petService, petTypeService);
            printer.Start();
        }
    }
}