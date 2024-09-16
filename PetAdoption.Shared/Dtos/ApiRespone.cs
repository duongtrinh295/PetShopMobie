
namespace PetAdoption.Shared.Dtos
{
    public record ApiRespone(bool IsSuccess, string? Message = null)
    {
        public static ApiRespone Success() => new(true, null);

        public static ApiRespone Fail(string? message) => new(false, message);
    }
    public record ApiRespone<TData>(bool IsSuccess, TData data, string? Message)
    {
        public static ApiRespone<TData> Success(TData data) => new(true, data, null);

        public static ApiRespone<TData> Fail(string? message) => new(false, default!, message);
    }
}
