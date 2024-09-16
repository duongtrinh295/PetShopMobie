using PetAdoption.Api.Data.Entities;
using PetAdoption.Shared.Dtos;
using System.Linq.Expressions;

namespace PetAdoption.Api.Extensions
{
    public static class Selectors
    {
        public static Expression<Func<Pet, PetListDto>> PetToPetListDto =>
            p => new PetListDto 
            { 
                Id = p.Id, 
                Name = p.Name,
                Breed = p.Breed,
                Image = p.Image,
                Price = p.Price
            };
    }
}
