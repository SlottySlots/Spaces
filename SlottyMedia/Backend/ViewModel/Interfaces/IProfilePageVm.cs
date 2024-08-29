using SlottyMedia.Backend.Dtos;

namespace SlottyMedia.Backend.ViewModel.Interfaces;

public interface IProfilePageVm
{
    /// <summary>
    /// Gets UserInformationDto based on provided userId
    /// </summary>
    /// <param name="userId">
    /// UserId to look up in db
    /// </param>
    /// <returns>
    /// UserInformationDto?
    /// </returns>
    public Task<UserInformationDto?> GetUserInfo(Guid userId);

    /// <summary>
    /// Checks whether a user follows another user based on their ids
    /// </summary>
    /// <param name="userIdToCheck">
    /// UserId to check
    /// </param>
    /// <param name="userIdLoggedIn">
    /// UserId that may follow the one to check
    /// </param>
    /// <returns>
    /// Boolean representing the state. Returns null if to check id is same as the logged in.
    /// </returns>
    public Task<bool?> UserFollowRelation(Guid userIdToCheck, Guid userIdLoggedIn);
}