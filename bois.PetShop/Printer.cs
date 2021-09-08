using System;
using System.Collections.Generic;
using System.Linq;
using bois.PetShopApplication.Core.IServices;
using bois.PetShopApplication.Core.Models;
using Type = bois.PetShopApplication.Core.Models.Type;

namespace bois.PetShop
{
    public class Printer
    {
        private static int _id = 10;
        private static List<Pet> _pets;
        private static List<Type> _petsTypes;
        private readonly IPetTypeService _petTypeService;

        public Printer(IPetTypeService typeService, IPetService service)
        {
            _petTypeService = typeService;
            _petsTypes = _petTypeService.GetPetTypes();
            _pets = service.GetPets();
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

            var petSelection = ShowMenu();
            while (petSelection != 10)
            {
                Clear();
                switch (petSelection)
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

                petSelection = ShowMenu();
            }

            Clear();
            Console.ReadLine();
        }

        private static void SortAllPetsByPrice()
        {
            var petSortedStuff = _pets.OrderBy(x => x.Price);
            foreach (var pet in petSortedStuff)
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
            var petId = int.Parse(Console.ReadLine() ?? throw new InvalidOperationException());
            foreach (var pet in _pets.Where(x => x.Type.Id == petId))
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
            var petName = Console.ReadLine() ?? throw new InvalidOperationException();
            foreach (var pet in _pets.Where(x => x.Type.Name == petName))
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
            var petSortedStuff = _pets.OrderBy(x => x.Price).Take(5);
            foreach (var pet in petSortedStuff)
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
            Print(StringConstants.NameInput);
            var petName = Console.ReadLine();
            Clear();

            Print(StringConstants.TypeInput);
            var petTypeName = SelectPetType();
            Clear();

            Print(StringConstants.BirthDateInput);
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

            Print(StringConstants.SoldDateInput);
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

            Print(StringConstants.ColorInput);
            var petColor = Console.ReadLine();
            Clear();

            Print(StringConstants.PriceInput);
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
            Print(StringConstants.NameInput);
            pet.Name = Console.ReadLine();
            Clear();
            Print(StringConstants.TypeInput);
            pet.Type = SelectPetType();
            Clear();
            Print("Please enter Day:");
            var petBirthdateDay = int.Parse(Console.ReadLine() ?? throw new InvalidOperationException());
            Clear();
            Print("Please enter Month:");
            var petBirthdateMonth = int.Parse(Console.ReadLine() ?? throw new InvalidOperationException());
            Clear();
            Print("Please enter Year:");
            var petBirthdateYear = int.Parse(Console.ReadLine() ?? throw new InvalidOperationException());
            Clear();
            var petBirthdate = new DateTime(petBirthdateYear, petBirthdateMonth, petBirthdateDay);
            pet.Birthdate = petBirthdate;
            Print("Please enter Day:");
            var petSoldDateDay = int.Parse(Console.ReadLine() ?? throw new InvalidOperationException());
            Clear();
            Print("Please enter Month:");
            var petSoldDateMonth = int.Parse(Console.ReadLine() ?? throw new InvalidOperationException());
            Clear();
            Print("Please enter Year:");
            var petSoldDateYear = int.Parse(Console.ReadLine() ?? throw new InvalidOperationException());
            Clear();
            var petSoldDate = new DateTime(petSoldDateYear, petSoldDateMonth, petSoldDateDay);
            pet.SoldDate = petSoldDate;
            Print(StringConstants.ColorInput);
            pet.Color = Console.ReadLine();
            Clear();
            Print(StringConstants.PriceInput);
            pet.Price = Convert.ToDouble(Console.ReadLine());
            Clear();
        }

        private static Pet FindPetById()
        {
            int petId;
            while (!int.TryParse(Console.ReadLine(), out petId))
                Print("Please Enter Id of Pet You Want Removed: ");

            return _pets.FirstOrDefault(pet => pet.Id == petId);
        }

        private static void DeletePet()
        {
            var petFound = FindPetById();
            if (petFound != null) _pets.Remove(petFound);
            Clear();
        }

        private static Type CreateNewPetType()
        {
            var petNewPetType = new Type();
            Print(StringConstants.AddPetTypeGreeting);
            Print(StringConstants.TypeNameLine);
            petNewPetType.Name = Console.ReadLine();
            Print($"{petNewPetType.Name} successfully added.");
            Clear();
            return petNewPetType;
        }

        private Type SelectPetType()
        {
            int petSelection;
            do
            {
                var petSelectedOption = Console.ReadKey();
                _petsTypes.ForEach(type => Print(type + "\n"));

                petSelection = petSelectedOption.KeyChar - '0';
                if (petSelection < 0 || petSelection > _petsTypes.Count)
                    Print($"Please select an option between 0 - {_petsTypes.Count}");
            } while (petSelection < 0 || petSelection > _petsTypes.Count);

            Clear();
            return _petTypeService.FindById(petSelection);
        }

        private static int ShowMenu()
        {
            string[] petMenuItems =
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

            for (var petI = 0; petI < petMenuItems.Length; petI++) Print($"{petI + 1}: {petMenuItems[petI]}");

            int petSelection;
            while (!int.TryParse(Console.ReadLine(), out petSelection) || petSelection is < 1 or > 9)
                Print("Please select a number between 1-9");
            Clear();
            return petSelection;
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