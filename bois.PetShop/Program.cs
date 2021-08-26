using System;
using bois.PetShopApplication.Core.IServices;
using bois.PetShopApplication.Domain.IRepositories;
using bois.PetShopApplication.Domain.Services;
using bois.PetShopApplication.SQL.Repositories;

namespace bois.PetShop
{
    class Program
    {
        static void Main(string[] args)
        {
            IPetRepository repo = new PetRepository();
            IPetService service = new PetService(repo);
            
            Printer printer = new Printer(service); 
            printer.Start();
            Console.ReadLine();
        }
    }
}