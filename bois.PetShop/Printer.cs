using System;
using System.Collections.Generic;
using bois.PetShopApplication.Core.IServices;
using bois.PetShopApplication.Core.Models;

namespace bois.PetShop
{
    public class Printer
    {
        private static int _id = 1;
        private static readonly List<Pet> Pets = new();
        private IPetService _service;

        public Printer(IPetService service)
        {
            _service = service;
        }

        public void Start()
        {
            PrinterMenu();
        }

        private void PrinterMenu()
        {
            var selection = ShowMenu();

            while (selection != 7)
            {
                switch (selection)
                {
                    case 1:
                        Console.Clear();
                        AddPet();
                        break;
                    case 2:
                        Console.Clear();
                        EditPet();
                        break;
                    case 3:
                        Console.Clear();
                        DeletePet();
                        break;
                    case 4:
                        Console.Clear();
                        ListAllPets();
                        break;
                    case 5:
                        Console.Clear();
                        ShowPetByType();
                        break;
                    case 6:
                        Console.Clear();
                        FiveCheapestPets();
                        break;
                }

                selection = ShowMenu();
            }

            Console.Clear();
            Console.ReadLine();
        }

        private void ShowPetByType()
        {
            throw new NotImplementedException();
        }

        private void FiveCheapestPets()
        {
            throw new NotImplementedException();
        }

        private void AddPet()
        {
            Console.WriteLine(StringConstants.PetNameInput);
            var petName = Console.ReadLine();
            /*Console.WriteLine(StringConstants.PetTypeInput);
            var petTypeName = (Console.ReadLine());
            Console.WriteLine(StringConstants.PetBirthDateInput);
            var petBirthdate = Int32.Parse(Console.ReadLine());
            Console.WriteLine(StringConstants.PetSoldDateInput);
            var petSoldDate = Console.ReadLine();*/
            Console.WriteLine(StringConstants.PetColorInput);
            var petColor = Console.ReadLine();
            Console.WriteLine(StringConstants.PetPriceInput);
            var petPrice = Console.ReadLine();

            Pets.Add(new Pet
            {
                Id = _id++,
                Name = petName,
                Birthdate = DateTime.Now,
                SoldDate = DateTime.Today,
                Color = petColor,
                Price = Convert.ToDouble(petPrice)
            });
        }

        private void EditPet()
        {
            throw new NotImplementedException();
        }

        private void DeletePet()
        {
            throw new NotImplementedException();
        }


        private static int ShowMenu()
        {
            string[] menuItems =
            {
                StringConstants.AddNewPet,
                StringConstants.EditPet,
                StringConstants.DeletePet,
                StringConstants.ShowAllPets,
                StringConstants.SearchPetByType,
                StringConstants.FiveCheapestPets
            };
            Console.WriteLine("Select What you want to do:\n");

            for (var i = 0; i < menuItems.Length; i++) Console.WriteLine($"{i + 1}: {menuItems[i]}");

            int selection;
            while (!int.TryParse(Console.ReadLine(), out selection) || selection is < 1 or > 6)
                Console.WriteLine("Please select a number between 1-6");

            return selection;
        }


        private static void ListAllPets()
        {
            foreach (var pet in Pets)
                Console.WriteLine(
                    $"\n Id: {pet.Id} \n Name: {pet.Name} \n Type: {pet.Type} \n Birthdate: {pet.Birthdate} \n SoldDate: {pet.SoldDate} \n Color: {pet.Color} \n Price: {pet.Price} \n");
        }
    }
}