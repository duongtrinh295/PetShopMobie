using Microsoft.EntityFrameworkCore;
using PetAdoption.Api.Data;
using PetAdoption.Api.Extensions;
using PetAdoption.Shared.Dtos;

namespace PetAdoption.Api.Services
{
    public class PetService : IPetService
    {
        private readonly PetContext _context;

        public PetService(PetContext context)
        {
            _context = context;
        }

        public async Task<ApiRespone<PetListDto[]>> GetNewlyAddedPetsAsyns(int count)
        {
            var pets = await _context.Pets
                .Where(p => p.AdoptionStatus == 0) // Thêm điều kiện kiểm tra AdoptionStatus
                .Select(Selectors.PetToPetListDto)
                .OrderByDescending(p => p.Id)
                .Take(count)
                .ToArrayAsync();

            return ApiRespone<PetListDto[]>.Success(pets);
        }

        public async Task<ApiRespone<PetListDto[]>> GetPopularPetsAsyns(int count)
        {
            var pets = await _context.Pets
                .Where(p => p.AdoptionStatus == 0) // Thêm điều kiện kiểm tra AdoptionStatus
                .OrderByDescending(p => p.Views)
                .Take(count)
                .Select(Selectors.PetToPetListDto)
                .ToArrayAsync();

            return ApiRespone<PetListDto[]>.Success(pets);
        }

        public async Task<ApiRespone<PetListDto[]>> GetRandomPetsAsyns(int count)
        {
            var pets = await _context.Pets
                .Where(p => p.AdoptionStatus == 0) // Thêm điều kiện kiểm tra AdoptionStatus
                .OrderByDescending(_ => Guid.NewGuid())
                .Take(count)
                .Select(Selectors.PetToPetListDto)
                .ToArrayAsync();

            return ApiRespone<PetListDto[]>.Success(pets);
        }

        public async Task<ApiRespone<PetListDto[]>> GetAllPetsAsync()
        {
            var pets = await _context.Pets
                .Where(p => p.AdoptionStatus == 0)
                .OrderByDescending(p => p.Id)
                .Select(Selectors.PetToPetListDto)
                .ToArrayAsync();

            return ApiRespone<PetListDto[]>.Success(pets);
        }

        public async Task<ApiRespone<PetDetailDto>> GetPetDetailsAsync(int petId, int userId = 0)
        {
            var petDetails = await _context.Pets
                .AsTracking()
                .FirstOrDefaultAsync(p => p.Id == petId);

            if (petDetails is not null)
            {
                petDetails.Views++;
                _context.SaveChanges();
            }

            var petDto = petDetails!.MapToPetDetailsDto();

            if(userId > 0)
            {
                if (await _context.UserFavorites.AnyAsync(x => x.UserId == userId && x.PetId == petId))
                    petDto.IsFavorite = true;
            }
            return ApiRespone<PetDetailDto>.Success(petDto);
        }
    }
}
