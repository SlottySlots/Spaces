using SlottyMedia.Backend.Dtos;
using SlottyMedia.Backend.Services.Interfaces;
using SlottyMedia.Backend.ViewModel.Interfaces;
using SlottyMedia.Database.Pagination;

namespace SlottyMedia.Backend.ViewModel;

/// <summary>
///     Viewmodel used for the profile page /profile?id=..
/// </summary>
public class ProfilePageVmImpl : IProfilePageVm
{
    private readonly IPostService _postService;
    private readonly IUserService _userService;

    /// <summary>
    ///     Ctor for dep inject
    /// </summary>
    public ProfilePageVmImpl(IUserService userService, IPostService postService)
    {
        _userService = userService;
        _postService = postService;
    }


    /// <summary>
    ///     Gets common user information by id such as name, description, picture, ..
    /// </summary>
    /// <param name="userId">
    ///     User Id to retrieve information from
    /// </param>
    /// <returns>
    ///     UserInformationDto. Can be null when no information could be retrieved e.g. when user doesn't exist
    /// </returns>
    public async Task<UserInformationDto?> GetUserInfo(Guid userId)
    {
       return await _userService.GetUserInfo(userId);
    }


    /// <summary>
    ///     Checks the follow relation of two users
    /// </summary>
    /// <param name="userIdToCheck">
    ///     User that may be followed by the userIdLoggedIn
    /// </param>
    /// <param name="userIdLoggedIn">
    ///     User that may have followed the another
    /// </param>
    /// <returns>
    ///     Bool. Can be null whenever the ids are the same. Hence indicating a wrong usage.
    /// </returns>
    public async Task<bool?> UserFollowRelation(Guid userIdToCheck, Guid userIdLoggedIn)
    {
        if (userIdToCheck != userIdLoggedIn)
            return await _userService.UserFollowRelation(userIdToCheck, userIdLoggedIn);
        return null;
    }

    /// <summary>
    ///     Follows a user by its ids
    /// </summary>
    /// <param name="userIdFollows">
    ///     User that tries to follow
    /// </param>
    /// <param name="userIdToFollow">
    ///     User that will be followed by another
    /// </param>
    public async Task FollowUserById(Guid userIdFollows, Guid userIdToFollow)
    {
        await _userService.FollowUserById(userIdFollows, userIdToFollow);
    }

    /// <summary>
    ///     Unfollows a user
    /// </summary>
    /// <param name="userIdFollows">
    ///     User that follows another
    /// </param>
    /// <param name="userIdToUnfollow">
    ///     User that will be unfollowed
    /// </param>
    public async Task UnfollowUserById(Guid userIdFollows, Guid userIdToUnfollow)
    {
        await _userService.UnfollowUserById(userIdFollows, userIdToUnfollow);
    }


    /// <summary>
    ///     Gets post by another user by id
    /// </summary>
    /// <param name="userId">
    ///     User the posts belongs to
    /// </param>
    /// <param name="startOfSet">
    ///     Starting index on which the follows are retrieved (they are sorted by date)
    /// </param>
    /// <param name="endOfSet">
    ///     Ending index used to slice the posts in a specific intervall
    /// </param>
    /// <returns>
    ///     List of PostDtos
    /// </returns>
    public async Task<List<PostDto>> GetPostsByUserId(Guid userId, PageRequest pageRequest)
    {
        var posts = await _postService.GetPostsByUserId(userId, pageRequest);
        return posts.Content;
    }
}