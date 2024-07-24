using SlottyMedia.Backend.Models;
using SlottyMedia.Backend.Services.Interfaces;
using Supabase.Gotrue;
using Client = Supabase.Client;

namespace SlottyMedia.Backend.Services;

public class UserService : IUserService
{
    private readonly Client _supabaseClient;

    /// <summary>
    /// This constructor creates a new UserService object..
    /// </summary>
    /// <param name="supabaseClient">Supabase Client to interact with the database</param>
    public UserService(Client supabaseClient)
    {
        _supabaseClient = supabaseClient;
    }

    /// <summary>
    /// This method creates a new User object in the database and returns the created object.
    /// </summary>
    /// <param name="userId">The ID we get from the Supabase Authentication Service</param>
    /// <param name="username">The Username of the User</param>
    /// <param name="description">The Description of the User</param>
    /// <param name="profilePicture">The Profile Picture of the User</param>
    /// <returns>Returns the Created UserDto. If it was unable to create a User, it will return null</returns>
    public async Task<UserDto?> CreateUser(string userId, string username, string? description = null,
        long? profilePicture = null)
    {
        var user = new UserDto
        {
            UserId = userId,
            UserName = username,
            Description = description ?? string.Empty,
            ProfilePic = profilePicture ?? 0
        };

        var insertedUser = await _supabaseClient.From<UserDto>().Insert(user);
        if (insertedUser.Model is null) return null;
        return insertedUser.Model;
    }

    /// <summary>
    /// This method deletes the given User object from the database.
    /// </summary>
    /// <param name="user">The User Object to delete</param>
    /// <returns>Returns wheter it was possible to Delete the User or not. IF it was Possible it will return true.</returns>
    public async Task<bool> DeleteUser(UserDto user)
    {
        await _supabaseClient.From<UserDto>().Delete(user);
        return true;
    }

    /// <summary>
    /// This method returns a User object from the database based on the given userId.
    /// </summary>
    /// <param name="userId">The ID of the User to get from the Database</param>
    /// <returns>Returns the User Object from the Database. If no User was found, null will be returned</returns>
    public async Task<UserDto?> GetUserById(string userId)
    {
        var user = await _supabaseClient.From<UserDto>().Where(x => x.UserId == userId).Single();

        if (user is null) return null;

        return user;
    }

    /// <summary>
    /// This method updates the given User object in the database and returns the updated object.
    /// </summary>
    /// <param name="user">The updated User Dto</param>
    /// <returns>Returns the Updated User Interface. If it was unable to Update the User, it will return null.</returns>
    public async Task<UserDto?> UpdateUser(UserDto user)
    {
        var updatedUser = await _supabaseClient.From<UserDto>().Update(user);
        if (updatedUser.Model is null) return null;
        return updatedUser.Model;
    }
}