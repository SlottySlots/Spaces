using SlottyMedia.Backend.Dtos;
using Supabase.Gotrue;

namespace SlottyMedia.Backend.ViewModel.Interfaces;
/// <summary>
/// This Interface represents the viewmodel of the MainLayout (root of our application)
/// </summary>
public interface IMainLayoutVm
{
    /// <summary>
    /// This sets the session on initialization of the page.
    /// </summary>
    /// <returns>
    /// Returns the restored session, or null if nothing was restored.
    /// </returns>
    Task<Session?> RestoreSessionOnInit(); 
    
    
    /// <summary>
    /// This sets a dto holding information about the current user in order to show the current users infos in the profile card 
    /// </summary>
    /// <returns>
    /// Returns a task of type UserInformationDto. The dto is used to update the state in the view. It's null if a error occured.
    /// </returns>
    Task<UserInformationDto?> SetUserInfo();
}