using System;
using System.Collections.Generic;
using System.Linq;
using bois.PetShopApplication.Core.IServices;
using bois.PetShopApplication.Core.Models;

namespace bois.PetShop
{
    public class Printer
    {
        private static int _id = 1;
                
        private readonly IPetTypeService _petTypeService;

        private static List<Pet> _pets;
        private static List<PetType> _petsTypes;

        public Printer(IPetTypeService petTypeService, IPetService petService)
        {
            _petTypeService = petTypeService;
            _petsTypes = _petTypeService.GetPetTypes();
            _pets = petService.GetPets();
        }

        public void Start()
        {
            PrinterMenu();
        }

        private void PrinterMenu()
        {
            var selection = ShowMenu();
            while (selection != 9)
            {
                Console.Clear();
                switch (selection)
                {
                    case 1:
                        Console.Clear();
                        AddPet();
                        break;
                    case 2:
                        Console.Clear();
                        _petTypeService.Add(CreateNewPetType());
                        break;
                    case 3:
                        Console.Clear();
                        EditPet();
                        break;
                    case 4:
                        Console.Clear();
                        DeletePet();
                        break;
                    case 5:
                        Console.Clear();
                        ListAllPets();
                        break;
                    case 6:
                        Console.Clear();
                        ShowPetByType();
                        break;
                    case 7:
                        Console.Clear();
                        FiveCheapestPets();
                        break;
                    case 8:
                        Console.Clear();
                        SortAllPetsByPrice();
                        break;
                }

                selection = ShowMenu();
            }

            Console.Clear();
            Console.ReadLine();
            
            
        }

        private void SortAllPetsByPrice()
        {
            var sortedStuff = _pets.OrderByDescending(x => x.Price);
            foreach (var pet in sortedStuff)
            {
                Console.WriteLine(pet);
            }

            Console.ReadLine();
            Console.Clear();
        }

        private void ShowPetByType()
        {
            Console.WriteLine("Please Enter Id of Animal Type you Want: ");
            var id = Int32.Parse(Console.ReadLine() ?? throw new InvalidOperationException());
            foreach (var pet in _pets.Where(x => x.Type.Id == id))
            {
                Console.WriteLine(pet);
            }


            Console.ReadLine();
        }

        private void FiveCheapestPets()
        {
            var sortedStuff = _pets.OrderByDescending(x => x.Price).Take(5);
            foreach (var pet in sortedStuff)
            {
                Console.WriteLine(pet);
            }

            Console.ReadLine();
        }

        private void AddPet()
        {
            Console.WriteLine(StringConstants.PetNameInput);
            var petName = Console.ReadLine();

            Console.WriteLine(StringConstants.PetTypeInput);
            var petTypeName = SelectPetType();

            Console.WriteLine(StringConstants.PetBirthDateInput);
            Console.WriteLine("Please enter Day:");
            var petBirthdateDay = int.Parse(Console.ReadLine() ?? throw new InvalidOperationException());

            Console.WriteLine("Please enter Month:");
            var petBirthdateMonth = int.Parse(Console.ReadLine() ?? throw new InvalidOperationException());

            Console.WriteLine("Please enter Year:");
            var petBirthdateYear = int.Parse(Console.ReadLine() ?? throw new InvalidOperationException());

            Console.WriteLine(StringConstants.PetSoldDateInput);
            Console.WriteLine("Please enter Day:");
            var petSoldDateDay = int.Parse(Console.ReadLine() ?? throw new InvalidOperationException());

            Console.WriteLine("Please enter Month:");
            var petSoldDateMonth = int.Parse(Console.ReadLine() ?? throw new InvalidOperationException());

            Console.WriteLine("Please enter Year:");
            var petSoldDateYear = int.Parse(Console.ReadLine() ?? throw new InvalidOperationException());

            Console.WriteLine(StringConstants.PetColorInput);
            var petColor = Console.ReadLine();

            Console.WriteLine(StringConstants.PetPriceInput);
            var petPrice = Console.ReadLine();

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
            Console.Clear();
        }

        private void EditPet()
        {
            Console.WriteLine("Please Enter Id of the Pet you want to Edit: ");
            var pet = FindPetById();

            Console.WriteLine(StringConstants.PetNameInput);
            pet.Name = Console.ReadLine();

            Console.WriteLine(StringConstants.PetTypeInput);
            pet.Type = SelectPetType();

            Console.WriteLine(StringConstants.PetBirthDateInput);
            pet.Birthdate = Convert.ToDateTime(Console.ReadLine());

            Console.WriteLine(StringConstants.PetSoldDateInput);
            pet.SoldDate = Convert.ToDateTime(Console.ReadLine());

            Console.WriteLine(StringConstants.PetColorInput);
            pet.Color = Console.ReadLine();

            Console.WriteLine(StringConstants.PetPriceInput);
            pet.Price = Convert.ToDouble(Console.ReadLine());
            Console.Clear();
        }

        private static Pet FindPetById()
        {
            int id;
            while (!int.TryParse(Console.ReadLine(), out id))
            {
                Console.WriteLine("Please Enter Id of Pet You Want Removed: ");
            }

            foreach (var pet in _pets)
            {
                if (pet.Id == id)
                {
                    return pet;
                }
            }

            return null;
        }

        private void DeletePet()
        {
            var petFound = FindPetById();
            if (petFound != null)
            {
                _pets.Remove(petFound);
            }

            Console.Clear();
        }

        private PetType CreateNewPetType()
        {
            var newPetType = new PetType();
            Console.WriteLine(StringConstants.AddPetTypeGreeting);
            Console.WriteLine(StringConstants.PetTypeNameLine);
            newPetType.Name = Console.ReadLine();
            Console.WriteLine($"{newPetType.Name} successfully added.");
            Console.Clear();
            return newPetType;
        }

        private PetType SelectPetType()
        {
            int selection;
            do
            {
                var selectedOption = Console.ReadKey();
                _petsTypes.ForEach(type => Console.Write(type + "\n"));

                selection = selectedOption.KeyChar - '0';
                if (selection < 0 || selection > _petsTypes.Count)
                    Console.WriteLine($"Please select an option between 0 - {_petsTypes.Count}");
            } while (selection < 0 || selection > _petsTypes.Count);

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
                StringConstants.ShowAllPets,
                StringConstants.searchPetType,
                StringConstants.FiveCheapestPets,
                StringConstants.SearchPetByPrice
            };
            Console.WriteLine("Select What you want to do:\n");

            for (var i = 0; i < menuItems.Length; i++) Console.WriteLine($"{i + 1}: {menuItems[i]}");

            int selection;
            while (!int.TryParse(Console.ReadLine(), out selection) || selection is < 1 or > 8)
                Console.WriteLine("Please select a number between 1-8");

            return selection;
        }


        private static void ListAllPets()
        {
            foreach (var pet in _pets)
                Console.WriteLine(
                    $"\n Id: {pet.Id} \n Name: {pet.Name} \n Type: {pet.Type.Name} \n Birthdate: {pet.Birthdate} \n SoldDate: {pet.SoldDate} \n Color: {pet.Color} \n Price: {pet.Price}$ \n");
            Console.ReadLine();
        }
    }
}