using SlottyMedia.Backend.Services.Interfaces;
using SlottyMedia.Backend.ViewModel.Interfaces;
using Supabase.Gotrue;

namespace SlottyMedia.Backend.ViewModel;

/// <summary>
/// Implementation of the IRegisterVM interface. It provides the logic of registering a user in supabase
/// </summary>
public class RegisterVm : IRegisterVm
{
    private readonly IAuthService _authService;

    /// <summary>
    /// Constructor for creating the register viewmodel
    /// </summary>
    /// <param name="authService">
    /// Authentication service for methods shared in different authentication viewmodel
    /// </param>
    /// <exception cref="ArgumentNullException">
    /// Provides a exception if dependency injection fails
    /// </exception>
    public RegisterVm(IAuthService authService)
    {
        _authService = authService ?? throw new ArgumentNullException(nameof(authService));
    }


    /// <summary>
    /// Registers a user by using the SignUp method in _authService
    /// </summary>
    /// <param name="email">
    /// Email used to register a user
    /// </param>
    /// <param name="password">
    /// Password used to register a user
    /// </param>
    /// <returns>
    /// Returns the new session of the registered user
    /// </returns>
    public async Task<Session?> RegisterAsync(string email, string password)
    {
        var session = await _authService.SignUp(email, password);
        return session;
    }

    /// <summary>
    /// Gets the current session if existing
    /// </summary>
    /// <returns>
    /// Returns the session set on client and server-side otherwise return null
    /// </returns>
    public Session? GetCurrentSession()
    {
        return _authService.GetCurrentSession();
    }
}