using Supabase.Gotrue;

namespace SlottyMedia.Backend.ViewModel.Interfaces;

/// <summary>
///     Interface used as auth viewmodel
/// </summary>
public interface IAuthVm
{
    /// <summary>
    ///     Gets the current logged in session of a user
    /// </summary>
    /// <returns>
    ///     Session. Can be null if user isn't logged in
    /// </returns>
    public Session? GetCurrentSession();
}