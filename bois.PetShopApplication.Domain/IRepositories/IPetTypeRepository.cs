using System.Collections.Generic;
using bois.PetShopApplication.Core.Models;

namespace bois.PetShopApplication.Domain.IRepositories
{
    public interface IPetTypeRepository
    {
        List<PetType> FindAll();
    }
}