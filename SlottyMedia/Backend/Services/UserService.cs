using SlottyMedia.Backend.Interfaces;
using SlottyMedia.Backend.Models;
using Supabase;

namespace SlottyMedia.Backend.Services;

public class UserService : IUserService
{
    private readonly Client _supabaseClient;

    public UserService(Client supabaseClient)
    {
        _supabaseClient = supabaseClient;
    }

    public async Task<UserDto> CreateUser(string userId,string username, string? description = null, long? profilePicture = null)
    {
        var user = new UserDto
        {
            UserId = userId,
            UserName = username,
            Description = description ?? string.Empty,
            ProfilePic = profilePicture ?? 0
        };

       var insertedUser = await _supabaseClient.From<UserDto>().Insert(user);
       return insertedUser.Model;
    }

    public async Task<bool> DeleteUser(UserDto user)
    {
        await _supabaseClient.From<UserDto>().Delete(user);
        return true;
    }

    public async Task<UserDto> GetUserById(string userId)
    {
        var user = await _supabaseClient.From<UserDto>().Where(x => x.UserId == userId).Single();
        return user;
    }

    public async Task<UserDto> UpdateUser(UserDto user)
    {
        var updatedUser = await _supabaseClient.From<UserDto>().Update(user);
        return updatedUser.Model;
    }
}