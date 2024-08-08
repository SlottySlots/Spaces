using Supabase.Gotrue;

namespace SlottyMedia.Backend.ViewModel.Interfaces;

/// <summary>
///     Interface providing the contract to register a user in a viewmodel
/// </summary>
public interface IRegisterVm
{
    /// <summary>
    ///     Registers a user by:
    ///     1. Saving user in db
    ///     2. Saving cookies in clients browser
    /// </summary>
    /// <param name="email">
    ///     Email used to register
    /// </param>
    /// <param name="password">
    ///     Password used to register
    /// </param>
    /// <returns>
    ///     Returns the session returned by viewmodel
    /// </returns>
    public Task<Session?> RegisterAsync(string email, string password);

    /// <summary>
    ///     Gets the current session if it exists, otherwise null
    /// </summary>
    /// <returns>
    ///     Returns the session set on client-side (if available otherwise null)
    /// </returns>
    public Session? GetCurrentSession();
}