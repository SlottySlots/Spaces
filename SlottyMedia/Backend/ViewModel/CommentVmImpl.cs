using SlottyMedia.Backend.Dtos;
using SlottyMedia.Backend.Services.Interfaces;
using SlottyMedia.Backend.ViewModel.Interfaces;
using SlottyMedia.LoggingProvider;

namespace SlottyMedia.Backend.ViewModel
{
    /// <summary>
    /// The CommentVmImpl class is responsible for handling the logic for the CommentVm.
    /// </summary>
    public class CommentVmImpl : ICommentVm
    {
        private readonly Logging<CommentVmImpl> _logger = new();
        private readonly IUserService _userService;

        /// <summary>
        /// The constructor for the CommentVmImpl.
        /// </summary>
        /// <param name="userService">The user service to be used for fetching user information.</param>
        public CommentVmImpl(IUserService userService)
        {
            _userService = userService;
            IsLoading = true;
        }

        /// <summary>
        /// The user information data transfer object to be rendered.
        /// </summary>
        public UserInformationDto UserInformation { get; set; } = new(true);

        /// <summary>
        /// Gets a value indicating whether the data is still loading.
        /// </summary>
        public bool IsLoading { get; private set; }

        /// <summary>
        /// Initializes the ViewModel with the specified user ID.
        /// </summary>
        /// <param name="userId">The ID of the user to load information for.</param>
        /// <returns>A task representing the asynchronous operation.</returns>
        public async Task Initialize(Guid? userId)
        {
            if (userId is not null)
                try
                {
                    var userInfo = await _userService.GetUserInfo(userId.Value, false, false);
                    if (userInfo is not null)
                    {
                        UserInformation = userInfo;
                        IsLoading = false;
                    }
                }
                catch (Exception e)
                {
                    _logger.LogError(e, $"Failed to load user information for user {userId}. In comment view model.");
                }
        }
    }
}