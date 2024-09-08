using Microsoft.AspNetCore.Components;
using SlottyMedia.Backend.Dtos;
using SlottyMedia.Backend.Services.Interfaces;
using SlottyMedia.Backend.ViewModel.Interfaces;

namespace SlottyMedia.Backend.ViewModel;


/// <inheritdoc />
public class CommentVmImpl : ICommentVm
{
    private readonly ICommentService _commentService;
    private readonly IUserService _userService;
    private readonly NavigationManager _navigationManager;

    /// <summary>
    ///     The constructor for the CommentVmImpl.
    /// </summary>
    public CommentVmImpl(ICommentService commentService, IUserService userService, NavigationManager navigationManager)
    {
        _commentService = commentService;
        _userService = userService;
        _navigationManager = navigationManager;
    }
    
    /// <inheritdoc />
    public bool IsLoading { get; private set; }

    /// <inheritdoc />
    public CommentDto? Dto { get; private set; }

    /// <inheritdoc />
    public UserInformationDto? UserInfo { get; private set; }

    /// <inheritdoc />
    public async Task Initialize(Guid commentId)
    {
        IsLoading = true;
        Dto = await _commentService.GetCommentById(commentId);
        UserInfo = await _userService.GetUserInfo(Dto.CreatorUserId!.Value, false, false);
        IsLoading = false;
    }

    /// <inheritdoc />
    public void GoToCreatorProfile()
    {
        _navigationManager.NavigateTo($"/profile/{UserInfo!.UserId}");
    }
}