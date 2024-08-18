using Microsoft.AspNetCore.Components;
using Microsoft.IdentityModel.Tokens;
using SlottyMedia.Backend.Services.Interfaces;
using SlottyMedia.Backend.ViewModel.Interfaces;

namespace SlottyMedia.Backend.ViewModel;


public class PostSubmissionFormVmImpl : IPostSubmissionFormVm
{
    private readonly IAuthService _authService;
    private readonly IPostService _postService;
    private readonly NavigationManager _navigationManager;

    public PostSubmissionFormVmImpl(IAuthService authService, IPostService postService, NavigationManager navigationManager)
    {
        _authService = authService;
        _postService = postService;
        _navigationManager = navigationManager;
    }

    public string? Text { get; set; }
    
    public string? TextErrorMessage { get; set; }
    
    public string? ServerErrorMessage { get; set; }
    
    public async Task SubmitForm()
    {
        // reset all error messages when form is (re-)submitted
        _resetErrorMessages();
        
        // if no user is logged in (for whichever reason): display error
        // This case should never happen. The post submission form should only
        // be accessible to authenticated users!
        // This case is handled nonetheless for safety reasons.
        if (!_authService.IsAuthenticated())
        {
            ServerErrorMessage = "You need to log in to submit a post";
            return;
        }
        
        // display error when fields are empty
        if (Text.IsNullOrEmpty())
        {
            TextErrorMessage = "Must provide some text in order to submit post";
            return;
        }
        
        // attempt to submit post
        try
        {
            var userId = _authService.GetCurrentSession()!.User!.Id;
            await _postService.InsertPost(Text!, new Guid(userId!));
        }
        catch
        {
            ServerErrorMessage = "An unknown error occurred. Try again later.";
            return;
        }
        
        // if no errors occurred: redirect to index page
        _navigationManager.NavigateTo("/");
    }

    private void _resetErrorMessages()
    {
        TextErrorMessage = null;
    }
}