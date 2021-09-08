using System.Collections.Generic;
using bois.PetShopApplication.Core.Models;
using bois.PetShopApplication.Domain.IRepositories;

namespace bois.PetShopApplication.DataAccess.Repositories
{
    public class TypeRepositoryMemory : IPetTypeRepository
    {
        private static readonly List<Type> TypesTable = new()
        {
            new Type {Id = 1, Name = "Monkey"},
            new Type {Id = 2, Name = "Dog"},
            new Type {Id = 3, Name = "Cat"}
        };

        private static int _id = 4;

        public Type Add(Type type)
        {
            type.Id = _id++;
            TypesTable.Add(type);
            return type;
        }

        public List<Type> FindAll()
        {
            return TypesTable;
        }
    }
}