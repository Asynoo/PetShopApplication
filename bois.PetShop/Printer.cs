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
        private static readonly List<Pet> Pets = new();
        private IPetService _petPetService;
        private readonly IPetTypeService _petTypeService;

        public Printer(IPetService petService, IPetTypeService petTypeService)
        {
            _petPetService = petService;
            _petTypeService = petTypeService;
        }

        public void Start()
        {
            PrinterMenu();
        }

        private void PrinterMenu()
        {
            var selection = ShowMenu();

            while (selection != 8)
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
                    case 7:
                        Console.Clear();
                        _petTypeService.Add(CreateNewPetType());
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
            var lowestPrice = Pets.Any() ? Pets.Min(Pet => new Pet().Price) : 0;
            foreach (var a in Pets.Where(a => a.Price <= lowestPrice))
            {
                lowestPrice = a.Price;
                Console.WriteLine(a.Price);
            }
        }

        private void AddPet()
        {
            Console.WriteLine(StringConstants.PetNameInput);
            var petName = Console.ReadLine();

            Console.WriteLine(StringConstants.PetTypeInput);
            var petTypeName = SelectPetType();

            /*Console.WriteLine(StringConstants.PetBirthDateInput);
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
                Type = petTypeName,
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

        private PetType CreateNewPetType()
        {
            var newPetType = new PetType();
            Console.WriteLine(StringConstants.AddPetTypeGreeting);
            Console.WriteLine(StringConstants.PetTypeNameLine);
            newPetType.Name = Console.ReadLine();
            Console.WriteLine($"{newPetType.Name} successfully added.");
            return newPetType;
        }

        private PetType SelectPetType()
        {
            int selection;
            do
            {
                var selectedOption = Console.ReadKey();
                _petTypeService.GetPetTypes().ForEach(type => Console.Write(type + "\n"));

                selection = selectedOption.KeyChar - '0';
                if (selection < 0 || selection > _petTypeService.GetPetTypes().Count)
                    Console.WriteLine($"Please select an option between 0 - {_petTypeService.GetPetTypes().Count}");
            } while (selection < 0 || selection > _petTypeService.GetPetTypes().Count);

            return _petTypeService.FindById(selection);
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
                StringConstants.FiveCheapestPets,
                StringConstants.AddNewPetType
            };
            Console.WriteLine("Select What you want to do:\n");

            for (var i = 0; i < menuItems.Length; i++) Console.WriteLine($"{i + 1}: {menuItems[i]}");

            int selection;
            while (!int.TryParse(Console.ReadLine(), out selection) || selection is < 1 or > 7)
                Console.WriteLine("Please select a number between 1-7");

            return selection;
        }


        private static void ListAllPets()
        {
            foreach (var pet in Pets)
                Console.WriteLine(
                    $"\n Id: {pet.Id} \n Name: {pet.Name} \n Type: {pet.Type.Name} \n Birthdate: {pet.Birthdate} \n SoldDate: {pet.SoldDate} \n Color: {pet.Color} \n Price: {pet.Price}$ \n");
        }
    }
}