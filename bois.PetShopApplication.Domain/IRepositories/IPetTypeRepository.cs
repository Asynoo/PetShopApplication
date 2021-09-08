using System.Collections.Generic;
using bois.PetShopApplication.Core.Models;

namespace bois.PetShopApplication.Domain.IRepositories
{
    public interface IPetTypeRepository
    {
        List<Type> FindAll();
        Type Add(Type type);
    }
}