using Microsoft.EntityFrameworkCore;
using PetAdoption.Api.Data;
using PetAdoption.Api.Data.Entities;
using PetAdoption.Api.Extensions;
using PetAdoption.Shared.Dtos;

namespace PetAdoption.Api.Services
{
    public class UserPetService : IUserPetService

    {
        private static readonly SemaphoreSlim _semaphore = new(1, 1);
        private readonly PetContext _context;

        public UserPetService(PetContext context)
        {
            _context = context;
        }

        public async Task<ApiRespone> ToggleFavoritesAsync(int userId, int petId)
        {
            var userFavorite = await _context.UserFavorites
                .FirstOrDefaultAsync(p => p.UserId == userId && p.PetId == petId);

            if (userFavorite is not null)
                _context.UserFavorites.Remove(userFavorite);
            else
            {
                userFavorite = new Data.Entities.UserFavorites
                {
                    UserId = userId,
                    PetId = petId
                };
            }
            await _context.SaveChangesAsync();
            return ApiRespone.Success();
        }


        public async Task<ApiRespone<PetListDto[]>> GetUserFavoritesAsyns(int userId)
        {
            var pets = await _context.UserFavorites
                .Where(p => p.UserId == userId)
                .Select(p => p.Pet)
                .Select(Selectors.PetToPetListDto)
                .OrderByDescending(p => p.Id)
                .ToArrayAsync();

            return ApiRespone<PetListDto[]>.Success(pets);
        }


        public async Task<ApiRespone<PetListDto[]>> GetUserAdoptionAsyns(int userId)
        {
            var pets = await _context.UserAdoptions
                .Where(p => p.UserId == userId)
                .Select(p => p.Pet)
                .Select(Selectors.PetToPetListDto)
                .OrderByDescending(p => p.Id)
                .ToArrayAsync();

            return ApiRespone<PetListDto[]>.Success(pets);
        }


        public async Task<ApiRespone> AdotPetAsyns(int userId, int petId)
        {
            try
            {
                await _semaphore.WaitAsync();
                var pet = await _context.Pets
                     .AsTracking()
                     .FirstOrDefaultAsync(p => p.Id == petId);

                if (pet is null)
                    return ApiRespone.Fail($"{pet.Name} is already adoted.");

                pet.AdoptionStatus = AdoptionStatus.Adopted;

                var userAdoption = new UserAdoption
                {
                    UserId = userId,
                    PetId = petId
                };

                await _context.UserAdoptions.AddAsync(userAdoption);
                await _context.SaveChangesAsync();
                return ApiRespone.Success();
            }
            catch (Exception ex)
            {
                return ApiRespone.Fail($"Error while adopting.{ex.Message}");
                //throw;
            }
            finally
            {
                _semaphore.Release();
            }
        }

    }
}
