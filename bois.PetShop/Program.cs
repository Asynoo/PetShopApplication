using System;
using bois.PetShopApplication.DataAccess.Repositories;
using bois.PetShopApplication.Domain.Services;

namespace bois.PetShop
{
    internal class Program
    {
        private static void Main(string[] args)
        {
            Console.BackgroundColor = ConsoleColor.White;
            Console.ForegroundColor = ConsoleColor.Black;


            var petRepo = new RepositoryInMemory();
            var petService = new Service(petRepo);

            var petTypeRepo = new TypeRepositoryMemory();
            var petTypeService = new TypeService(petTypeRepo);
            var petPrinter = new Printer(petTypeService, petService);
            petPrinter.Start();
        }
    }
}