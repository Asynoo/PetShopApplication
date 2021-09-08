using System;
using System.Collections.Generic;
using System.Linq;
using bois.PetShopApplication.Core.IServices;
using bois.PetShopApplication.Core.Models;

namespace bois.PetShop
{
    public class Printer
    {
        private static int _id = 10;
        private static List<Pet> _pets;
        private static List<PetType> _petsTypes;
        private readonly IPetTypeService _petTypeService;

        public Printer(IPetTypeService petTypeService, IPetService petService)
        {
            _petTypeService = petTypeService;
            _petsTypes = _petTypeService.GetPetTypes();
            _pets = petService.GetPets();
        }

        public void Start()
        {
            Print("");
            Clear();
            PrinterMenu();
        }

        private void PrinterMenu()
        {
            Console.BackgroundColor = ConsoleColor.White;
            Console.ForegroundColor = ConsoleColor.Black;

            var selection = ShowMenu();
            while (selection != 10)
            {
                Clear();
                switch (selection)
                {
                    case 1:
                        Clear();
                        AddPet();
                        break;
                    case 2:
                        Clear();
                        _petTypeService.Add(CreateNewPetType());
                        break;
                    case 3:
                        Clear();
                        EditPet();
                        break;
                    case 4:
                        Clear();
                        DeletePet();
                        break;
                    case 5:
                        Clear();
                        ShowPetByTypeName();
                        break;
                    case 6:
                        Clear();
                        ShowPetByTypeId();
                        break;
                    case 7:
                        Clear();
                        SortAllPetsByPrice();
                        break;
                    case 8:
                        Clear();
                        FiveCheapestPets();
                        break;
                    case 9:
                        Clear();
                        ListAllPets();
                        break;
                }

                selection = ShowMenu();
            }

            Clear();
            Console.ReadLine();
        }

        private static void SortAllPetsByPrice()
        {
            var sortedStuff = _pets.OrderBy(x => x.Price);
            foreach (var pet in sortedStuff)
                Print(
                    $"\n Id: {pet.Id} \n " +
                    $"Name: {pet.Name} \n " +
                    $"TypeId: {pet.Type.Id} \n " +
                    $"TypeName: {pet.Type.Name} \n " +
                    $"Birthdate: {pet.Birthdate.Day + "/" + pet.Birthdate.Month + "/" + pet.Birthdate.Year} \n " +
                    $"SoldDate: {pet.SoldDate.Day + "/" + pet.SoldDate.Month + "/" + pet.SoldDate.Year} \n " +
                    $"Color: {pet.Color} \n " +
                    $"Price: {pet.Price}$ \n");
            Console.ReadLine();
            Clear();
        }

        private static void ShowPetByTypeId()
        {
            Print("Please Enter Id of Animal Type you Want: ");
            var id = int.Parse(Console.ReadLine() ?? throw new InvalidOperationException());
            foreach (var pet in _pets.Where(x => x.Type.Id == id))
                Print(
                    $"\n Id: {pet.Id} \n " +
                    $"Name: {pet.Name} \n " +
                    $"TypeId: {pet.Type.Id} \n " +
                    $"TypeName: {pet.Type.Name} \n " +
                    $"Birthdate: {pet.Birthdate.Day + "/" + pet.Birthdate.Month + "/" + pet.Birthdate.Year} \n " +
                    $"SoldDate: {pet.SoldDate.Day + "/" + pet.SoldDate.Month + "/" + pet.SoldDate.Year} \n " +
                    $"Color: {pet.Color} \n " +
                    $"Price: {pet.Price}$ \n");
            Console.ReadLine();
            Clear();
        }

        private static void ShowPetByTypeName()
        {
            Print("Please Enter Name of Animal Type you Want: ");
            var name = Console.ReadLine() ?? throw new InvalidOperationException();
            foreach (var pet in _pets.Where(x => x.Type.Name == name))
                Print(
                    $"\n Id: {pet.Id} \n " +
                    $"Name: {pet.Name} \n " +
                    $"TypeId: {pet.Type.Id} \n " +
                    $"TypeName: {pet.Type.Name} \n " +
                    $"Birthdate: {pet.Birthdate.Day + "/" + pet.Birthdate.Month + "/" + pet.Birthdate.Year} \n " +
                    $"SoldDate: {pet.SoldDate.Day + "/" + pet.SoldDate.Month + "/" + pet.SoldDate.Year} \n " +
                    $"Color: {pet.Color} \n " +
                    $"Price: {pet.Price}$ \n");
            Console.ReadLine();
            Clear();
        }

        private static void FiveCheapestPets()
        {
            var sortedStuff = _pets.OrderBy(x => x.Price).Take(5);
            foreach (var pet in sortedStuff)
                Print(
                    $"\n Id: {pet.Id} \n " +
                    $"Name: {pet.Name} \n " +
                    $"TypeId: {pet.Type.Id} \n " +
                    $"TypeName: {pet.Type.Name} \n " +
                    $"Birthdate: {pet.Birthdate.Day + "/" + pet.Birthdate.Month + "/" + pet.Birthdate.Year} \n " +
                    $"SoldDate: {pet.SoldDate.Day + "/" + pet.SoldDate.Month + "/" + pet.SoldDate.Year} \n " +
                    $"Color: {pet.Color} \n " +
                    $"Price: {pet.Price}$ \n");
            Console.ReadLine();
            Clear();
        }

        private void AddPet()
        {
            Print(StringConstants.PetNameInput);
            var petName = Console.ReadLine();
            Clear();

            Print(StringConstants.PetTypeInput);
            var petTypeName = SelectPetType();
            Clear();

            Print(StringConstants.PetBirthDateInput);
            Print("Please enter Day:");
            int petBirthdateDay;
            while (!int.TryParse(Console.ReadLine(), out petBirthdateDay)) EnterIntegerPlease();
            Clear();

            Print("Please enter Month:");
            int petBirthdateMonth;
            while (!int.TryParse(Console.ReadLine(), out petBirthdateMonth)) EnterIntegerPlease();
            Clear();

            Print("Please enter Year:");
            int petBirthdateYear;
            while (!int.TryParse(Console.ReadLine(), out petBirthdateYear)) EnterIntegerPlease();
            Clear();

            Print(StringConstants.PetSoldDateInput);
            Print("Please enter Day:");
            int petSoldDateDay;
            while (!int.TryParse(Console.ReadLine(), out petSoldDateDay)) EnterIntegerPlease();
            Clear();

            Print("Please enter Month:");
            int petSoldDateMonth;
            while (!int.TryParse(Console.ReadLine(), out petSoldDateMonth)) EnterIntegerPlease();
            Clear();

            Print("Please enter Year:");
            int petSoldDateYear;
            while (!int.TryParse(Console.ReadLine(), out petSoldDateYear)) EnterIntegerPlease();
            Clear();

            Print(StringConstants.PetColorInput);
            var petColor = Console.ReadLine();
            Clear();

            Print(StringConstants.PetPriceInput);
            int petPrice;
            while (!int.TryParse(Console.ReadLine(), out petPrice)) EnterIntegerPlease();
            Clear();

            _pets.Add(new Pet
            {
                Id = _id++,
                Name = petName,
                Type = petTypeName,
                Birthdate = new DateTime(petBirthdateYear, petBirthdateMonth, petBirthdateDay),
                SoldDate = new DateTime(petSoldDateYear, petSoldDateMonth, petSoldDateDay),
                Color = petColor,
                Price = Convert.ToDouble(petPrice)
            });
            Clear();
        }

        private void EditPet()
        {
            Print("Please Enter Id of the Pet you want to Edit: ");
            var pet = FindPetById();
            Clear();
            Print(StringConstants.PetNameInput);
            pet.Name = Console.ReadLine();
            Clear();
            Print(StringConstants.PetTypeInput);
            pet.Type = SelectPetType();
            Clear();
            Print(StringConstants.PetBirthDateInput);
            pet.Birthdate = Convert.ToDateTime(Console.ReadLine());
            Clear();
            Print(StringConstants.PetSoldDateInput);
            pet.SoldDate = Convert.ToDateTime(Console.ReadLine());
            Clear();
            Print(StringConstants.PetColorInput);
            pet.Color = Console.ReadLine();
            Clear();
            Print(StringConstants.PetPriceInput);
            pet.Price = Convert.ToDouble(Console.ReadLine());
            Clear();
        }

        private static Pet FindPetById()
        {
            int id;
            while (!int.TryParse(Console.ReadLine(), out id))
                Print("Please Enter Id of Pet You Want Removed: ");

            return _pets.FirstOrDefault(pet => pet.Id == id);
        }

        private static void DeletePet()
        {
            var petFound = FindPetById();
            if (petFound != null) _pets.Remove(petFound);
            Clear();
        }

        private static PetType CreateNewPetType()
        {
            var newPetType = new PetType();
            Print(StringConstants.AddPetTypeGreeting);
            Print(StringConstants.PetTypeNameLine);
            newPetType.Name = Console.ReadLine();
            Print($"{newPetType.Name} successfully added.");
            Clear();
            return newPetType;
        }

        private PetType SelectPetType()
        {
            int selection;
            do
            {
                var selectedOption = Console.ReadKey();
                _petsTypes.ForEach(type => Print(type + "\n"));

                selection = selectedOption.KeyChar - '0';
                if (selection < 0 || selection > _petsTypes.Count)
                    Print($"Please select an option between 0 - {_petsTypes.Count}");
            } while (selection < 0 || selection > _petsTypes.Count);

            Clear();
            return _petTypeService.FindById(selection);
        }

        private static int ShowMenu()
        {
            string[] menuItems =
            {
                StringConstants.AddNewPet,
                StringConstants.AddNewPetType,
                StringConstants.EditPet,
                StringConstants.DeletePet,
                StringConstants.SearchPetTypeName,
                StringConstants.SearchPetTypeId,
                StringConstants.SortPetByPrice,
                StringConstants.FiveCheapestPets,
                StringConstants.ShowAllPets
            };
            Print("Welcome To The Pet Shop!\n");
            Print("Select What you want to do:\n");

            for (var i = 0; i < menuItems.Length; i++) Print($"{i + 1}: {menuItems[i]}");

            int selection;
            while (!int.TryParse(Console.ReadLine(), out selection) || selection is < 1 or > 9)
                Print("Please select a number between 1-9");
            Clear();
            return selection;
        }


        private static void ListAllPets()
        {
            foreach (var pet in _pets)
                Print(
                    $"\n Id: {pet.Id} \n " +
                    $"Name: {pet.Name} \n " +
                    $"Type: {pet.Type.Name} \n " +
                    $"Birthdate: {pet.Birthdate.Day + "/" + pet.Birthdate.Month + "/" + pet.Birthdate.Year} \n " +
                    $"SoldDate: {pet.SoldDate.Day + "/" + pet.SoldDate.Month + "/" + pet.SoldDate.Year} \n " +
                    $"Color: {pet.Color} \n " +
                    $"Price: {pet.Price}$ \n");
            Console.ReadLine();
            Clear();
        }

        private static void EnterIntegerPlease()
        {
            Console.Write("Please Enter a Number: ");
        }

        private static void Print(string value)
        {
            Console.WriteLine(value);
        }

        private static void Clear()
        {
            Console.Clear();
        }
    }
}