using Supabase.Gotrue;

namespace SlottyMedia.Backend.ViewModel.Interfaces;

/// <summary>
///     Interface used as auth viewmodel
/// </summary>
public interface IAuthVm
{
    /// <summary>
    ///     Gets the current logged in session of a user.
    /// </summary>
    /// <returns>
    ///     The current session of the user. Can be null if the user isn't logged in.
    /// </returns>
    public Session? GetCurrentSession();

    /// <summary>
    ///     Gets the user ID of the current logged in user.
    /// </summary>
    /// <returns>
    ///     The user ID as a Guid.
    /// </returns>
    public Guid GetCurrentUserId();

    /// <summary>
    ///     Checks if the user is authenticated.
    /// </summary>
    /// <returns>
    ///     True if the user is authenticated, otherwise false.
    /// </returns>
    public bool IsAuthenticated();
}