using bois.PetShopApplication.Core.Models;
using bois.PetShopApplication.SQL.Entities;

namespace bois.PetShopApplication.SQL.Converters
{
    public class PetConverter
    {
        public Pet Convert(PetEntity entity)
        {
            return new Pet
            {
                Id = entity.Id,
                Name = entity.Name,
                //Type = entity.Type,
                Birthdate = entity.Birthdate,
                SoldDate = entity.SoldDate,
                Color = entity.Color,
                Price = entity.Price
            };
        }
        public PetEntity Convert(Pet pet)
        {
            return new PetEntity
            {
                Id = pet.Id,
                Name = pet.Name,
                //Type = pet.Type,
                Birthdate = pet.Birthdate,
                SoldDate = pet.SoldDate,
                Color = pet.Color,
                Price = pet.Price
            };
        }
    }
}