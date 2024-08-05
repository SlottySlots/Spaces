using Supabase.Gotrue;

namespace SlottyMedia.Backend.Services.Interfaces;
public interface IAuthService
{
    /// <summary>
    /// This method is used to sign up the user.
    /// </summary>
    /// <param name="email"></param>
    /// <param name="password"></param>
    /// <returns></returns>
    Task<Session?> SignUp(string email, string password);
    /// <summary>
    /// This method is used to sign in the user.
    /// </summary>
    /// <param name="email"></param>
    /// <param name="password"></param>
    /// <returns></returns>
    Task<Session?> SignIn(string? email, string? password);
    /// <summary>
    /// This method is used to sign out the user.
    /// </summary>
    /// <returns></returns>
    Task SignOut();
    /// <summary>
    /// This method is used to check if the user is authenticated.
    /// </summary>
    /// <returns></returns>
    bool IsAuthenticated();

    Task<Session?> SetSession(string sessionToken, string refreshToken);

    Task<string?> GetAccessToken();

    Task<Session?> RefreshSession(string accessToken, string refreshToken);

    Session? GetCurrentSession();
}