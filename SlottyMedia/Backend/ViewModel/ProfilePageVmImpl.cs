using SlottyMedia.Backend.Dtos;
using SlottyMedia.Backend.Services.Interfaces;
using SlottyMedia.Backend.ViewModel.Interfaces;
using SlottyMedia.LoggingProvider;

namespace SlottyMedia.Backend.ViewModel;

public class ProfilePageVmImpl : IProfilePageVm
{
    private readonly IUserService _userService;
    private readonly Logging<MainLayoutVmImpl> _logger = new();


    public ProfilePageVmImpl(IUserService userService)
    {
        _userService = userService;
    }


    public async Task<UserInformationDto?> GetUserInfo(Guid userId)
    {

        var userDao = await _userService.GetUserDaoById(userId);
        var amountOfFriends = await _userService.GetCountOfUserFriends(userId);
        var amountOfSpaces = await _userService.GetCountOfUserSpaces(userId);
        if (userDao is { UserId: null, UserName: null, Description: null, Email: null })
        {
            _logger.LogError(
                $"User with id {userId} was not found in db while retrieval on profile page");
        }
        else
        {
            var userInformationDto = new UserInformationDto
            {
                UserId = userDao.UserId!,
                Username = userDao.UserName!,
                Description = userDao.Description!,
                ProfilePic = userDao.ProfilePic,
                FriendsAmount = amountOfFriends,
                SpacesAmount = amountOfSpaces,
                CreatedAt = userDao.CreatedAt!
            };
            return userInformationDto;
        }

        return null;
    }

    public async Task<bool?> UserFollowRelation(Guid userIdToCheck, Guid userIdLoggedIn)
    {
        if (userIdToCheck != userIdLoggedIn)
        {
            return await _userService.UserFollowRelation(userIdToCheck, userIdLoggedIn);
 
        }
        return null;
    }
}