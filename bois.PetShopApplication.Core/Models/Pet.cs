using System;

namespace bois.PetShopApplication.Core.Models
{
    public class Pet
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public PetType Type { get; set; }
        public DateTime Birthdate { get; set; }
        public DateTime SoldDate { get; set; }
        public string Color { get; set; }
        public double Price { get; set; }

        public override string ToString()
        {
            return $"{Id},{Type.Name}, Name: {Name}, Color: {Color}, Born: {Birthdate}, Price: {Price} dolans";
        }
    }
}