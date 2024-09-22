﻿using PetAdoption.Api.Data.Entities;
using PetAdoption.Shared;
using PetAdoption.Shared.Dtos;

namespace PetAdoption.Api.Extensions
{
    public static class Mappers
    {
        public static PetDetailDto MapToPetDetailsDto(this Pet p) =>
            new PetDetailDto
            {
                AdoptionStatus = p.AdoptionStatus,
                Breed = p.Breed,
                DateOfBirth = p.DateOfBirth,
                Description = p.Description,
                Gender = p.Gender,
                Id = p.Id,
                Image = $"{AppConstants.BaseApiUrl}/images/pets/{p.Image}",
                Name = p.Name,
                Price = p.Price,
            };
    }
}
