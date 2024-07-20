using SlottyMedia.Backend.Models;
using Supabase.Gotrue;

namespace SlottyMedia.Backend.Interfaces;

public interface IUserService
{
    Task<UserDto> GetUserById(string userId);
    Task<UserDto> CreateUser(string userId ,string username, string? description = null, long? profilePicture = null );
    Task<UserDto> UpdateUser(UserDto user);
    Task<bool> DeleteUser(UserDto user);
}