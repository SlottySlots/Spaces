using SlottyMedia.Backend.Dtos;
using SlottyMedia.Database.Pagination;

namespace SlottyMedia.Backend.ViewModel.Interfaces;

/// <summary>
///     Interface used for profilepage viewmodel
/// </summary>
public interface IProfilePageVm
{
    /// <summary>
    ///     Gets UserInformationDto based on provided userId
    /// </summary>
    /// <param name="userId">
    ///     UserId to look up in db
    /// </param>
    /// <returns>
    ///     UserInformationDto?
    /// </returns>
    public Task<UserInformationDto?> GetUserInfo(Guid userId);

    /// <summary>
    ///     Checks whether a user follows another user based on their ids
    /// </summary>
    /// <param name="userIdToCheck">
    ///     UserId to check
    /// </param>
    /// <param name="userIdLoggedIn">
    ///     UserId that may follow the one to check
    /// </param>
    /// <returns>
    ///     Boolean representing the state. Returns null if to check id is same as the logged in.
    /// </returns>
    public Task<bool?> UserFollowRelation(Guid userIdToCheck, Guid userIdLoggedIn);

    /// <summary>
    ///     Method used to follow a user by id
    /// </summary>
    /// <param name="userIdFollows">
    ///     The user that tries to follow another
    /// </param>
    /// <param name="userIdToFollow">
    ///     The user that the user tries to follow
    /// </param>
    /// <returns>
    ///     Task
    /// </returns>
    public Task FollowUserById(Guid userIdFollows, Guid userIdToFollow);

    /// <summary>
    ///     Method used to unfollow a user by id
    /// </summary>
    /// <param name="userIdFollows">
    ///     The user that tries to unfollow another
    /// </param>
    /// <param name="userIdToUnfollow">
    ///     The user that the user tries to unfollow
    /// </param>
    /// <returns>
    ///     Task
    /// </returns>
    public Task UnfollowUserById(Guid userIdFollows, Guid userIdToUnfollow);

    /// <summary>
    ///     Gets posts of a user by their id and enables slicing via offsets
    /// </summary>
    /// <param name="userId">
    ///     User that the posts belong to
    /// </param>
    /// <param name="startOfSet">
    ///     Startindex of the posts sorted by date
    /// </param>
    /// <param name="endOfSet">
    ///     Endindex of the posts sorted by data
    /// </param>
    /// <returns>
    ///     List of PostDtos
    /// </returns>
    public Task<List<PostDto>> GetPostsByUserId(Guid userId, PageRequest pageRequest);
}