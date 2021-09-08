using System;

namespace bois.PetShopApplication.SQL.Entities
{
    public class PetEntity
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public Type Type { get; set; }
        public DateTime Birthdate { get; set; }
        public DateTime SoldDate { get; set; }
        public string Color { get; set; }
        public double Price { get; set; }
    }
}