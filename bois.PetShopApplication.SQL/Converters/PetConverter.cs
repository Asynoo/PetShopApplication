using bois.PetShopApplication.Core.Models;
using bois.PetShopApplication.SQL.Entities;

namespace bois.PetShopApplication.SQL.Converters
{
    public class Converter
    {
        public static Pet Convert(PetEntity entity)
        {
            return new Pet
            {
                Id = entity.Id,
                Name = entity.Name,
                Birthdate = entity.Birthdate,
                SoldDate = entity.SoldDate,
                Color = entity.Color,
                Price = entity.Price
            };
        }

        public static PetEntity Convert(Pet pet)
        {
            return new PetEntity
            {
                Id = pet.Id,
                Name = pet.Name,
                Birthdate = pet.Birthdate,
                SoldDate = pet.SoldDate,
                Color = pet.Color,
                Price = pet.Price
            };
        }
    }
}