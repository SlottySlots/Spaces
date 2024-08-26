using SlottyMedia.Backend.Dtos;

namespace SlottyMedia.Backend.ViewModel.Interfaces;

/// <summary>
///     Interface for user view model implementation.
/// </summary>
public interface IUserVmImpl
{
    /// <summary>
    ///     Asynchronously retrieves a user by their unique identifier.
    /// </summary>
    /// <param name="userId">The unique identifier of the user.</param>
    /// <returns>A task that represents the asynchronous operation. The task result contains the user data transfer object.</returns>
    public Task<UserDto> GetUserById(Guid userId);

    /// <summary>
    ///     Updates the given UserDto object in the database and returns the updated object.
    /// </summary>
    /// <param name="user">The UserDto object to be updated.</param>
    /// <returns>A task that represents the asynchronous operation. The task result contains the updated UserDto object.</returns>
    public Task<UserDto> UpdateUser(UserDto user);
}