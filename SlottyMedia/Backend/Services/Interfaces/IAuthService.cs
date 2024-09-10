using Supabase.Gotrue;

namespace SlottyMedia.Backend.Services.Interfaces;

/// <summary>
///     This interface provides functionalities to authenticate a user.
///     In this context, the <a href="https://en.wikipedia.org/wiki/Principal_(computer_security)">Principal</a>
///     refers to the currently logged-in user.
/// </summary>
public interface IAuthService
{
    /// <summary>
    ///     This method is used to sign in the user.
    /// </summary>
    /// <param name="email"></param>
    /// <param name="password"></param>
    /// <returns></returns>
    Task<Session?> SignIn(string email, string password);

    /// <summary>
    ///     This method is used to sign out the user.
    /// </summary>
    /// <returns></returns>
    Task SignOut();

    /// <summary>
    ///     Should restore a session by reading in accessToken, refreshToken Cookie
    /// </summary>
    /// <returns>
    ///     Returns a supabase session
    /// </returns>
    Task<Session?> RestoreSessionAsync();

    /// <summary>
    ///     Saves the accessToken, refreshToken in form of a cookie in the clients browser
    /// </summary>
    /// <param name="session">
    ///     Session on which the tokens are extracted
    /// </param>
    /// <returns>
    ///     Returns the sessions again
    /// </returns>
    Task SaveSessionAsync(Session session);

    /// <summary>
    ///     Checks if a session exists
    /// </summary>
    bool IsAuthenticated();

    /// <summary>
    ///     Retrieves the authentication principal's user ID. Returns <c>null</c> if no authentication
    ///     principal is present.
    /// </summary>
    /// <returns>The principal's ID or <c>null</c> if none was present</returns>
    Guid? GetAuthPrincipalId();

    /// <summary>
    ///     Sets a session in form of a cookie on the client side by using wwwroot/js/cookies.js
    /// </summary>
    /// <param name="accessToken">
    ///     AccessToken about to be set as cookie
    /// </param>
    /// <param name="refreshToken">
    ///     RefreshToken about to be set as cookie
    /// </param>
    /// <returns>
    ///     Returns the session which was set
    /// </returns>
    Task<Session?> SetSession(string accessToken, string refreshToken);

    /// <summary>
    ///     Restores a session on server- and client-side and refreshes a accessToken if necessary
    /// </summary>
    /// <param name="accessToken">
    ///     AccessToken for restoration
    /// </param>
    /// <param name="refreshToken">
    ///     RefreshToken for restoration
    /// </param>
    /// <returns>
    ///     Returns the new session
    /// </returns>
    Task<Session?> RefreshSession(string accessToken, string refreshToken);


    /// <summary>
    ///     Gets the current session set by the client
    /// </summary>
    /// <returns>
    ///     Returns the session
    /// </returns>
    Session? GetCurrentSession();

    /// <summary>
    ///     This sets the session on initialization of the page.
    /// </summary>
    Task<Session?> RestoreSessionOnInit();
}