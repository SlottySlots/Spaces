using SlottyMedia.Backend.Exceptions.auth;
using SlottyMedia.Backend.Services.Interfaces;
using SlottyMedia.LoggingProvider;
using Supabase.Gotrue;
using Client = Supabase.Client;

namespace SlottyMedia.Backend.Services;

/// <inheritdoc />
public class AuthService : IAuthService
{
    private static readonly Logging<AuthService> Logger = new();
    private readonly ICookieService _cookieService;
    private readonly Client _supabaseClient;


    /// <summary>
    ///     Initialize scoped service by ctor injection
    /// </summary>
    /// <param name="supabaseClient">
    ///     Injected supabaseClient
    /// </param>
    /// <param name="cookieService">
    ///     Injected cookieService
    /// </param>
    public AuthService(Client supabaseClient, ICookieService cookieService)
    {
        Logger.LogInfo("AuthService initialized");
        _supabaseClient = supabaseClient;
        _cookieService = cookieService;
    }

    /// <inheritdoc />
    public async Task<Session?> SignIn(string email, string password)
    {
        Logger.LogDebug($"Signing in user with email: {email}");
        var session = await _supabaseClient.Auth.SignIn(email, password);
        if (session != null) await SaveSessionAsync(session);
        return session;
    }

    /// <inheritdoc />
    public async Task SaveSessionAsync(Session session)
    {
        Logger.LogDebug("Saving session");
        if (session is { AccessToken: not null, RefreshToken: not null })
        {
            await _cookieService.SetCookie("supabase.auth.token", session.AccessToken, 7);
            await _cookieService.SetCookie("supabase.auth.refreshToken", session.RefreshToken, 7);
        }
        else
        {
            throw new TokenNotProvidedException(session.AccessToken is null, session.RefreshToken is null);
        }
    }

    /// <inheritdoc />
    public async Task<Session?> RestoreSessionAsync()
    {
        Logger.LogDebug("Restoring session");
        var accessToken = await _cookieService.GetCookie("supabase.auth.token");
        var refreshToken = await _cookieService.GetCookie("supabase.auth.refreshToken");
        if (!string.IsNullOrEmpty(accessToken) && !string.IsNullOrEmpty(refreshToken) && !IsAuthenticated())
            try
            {
                var session = await RefreshSession(accessToken, refreshToken);
                if (session != null)
                {
                    await SaveSessionAsync(session);
                    return session;
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error refreshing session: {ex.Message}");
                await SignOut();
            }
        else
            throw new TokenNotProvidedException(string.IsNullOrEmpty(accessToken), string.IsNullOrEmpty(refreshToken));

        return null;
    }

    /// <inheritdoc />
    public async Task<Session?> SetSession(string accessToken, string refreshToken)
    {
        Logger.LogDebug("Setting session");
        var session = await _supabaseClient.Auth.SetSession(accessToken, refreshToken);
        return session;
    }

    /// <inheritdoc />
    public async Task SignOut()
    {
        Logger.LogDebug("Signing out");
        await _supabaseClient.Auth.SignOut();
        await _cookieService.RemoveCookie("supabase.auth.token");
        await _cookieService.RemoveCookie("supabase.auth.refreshToken");
    }

    /// <inheritdoc />
    public async Task<Session?> RefreshSession(string accessToken, string refreshToken)
    {
        Logger.LogDebug("Refreshing session");
        var session = await _supabaseClient.Auth.SetSession(accessToken, refreshToken, true);
        return session;
    }

    /// <inheritdoc />
    public bool IsAuthenticated()
    {
        Logger.LogDebug("Checking if user is authenticated");
        return _supabaseClient.Auth.CurrentSession != null;
    }

    /// <inheritdoc />
    public virtual Session? GetCurrentSession()
    {
        Logger.LogDebug("Getting current session");
        var session = _supabaseClient.Auth.CurrentSession;
        return session;
    }

    /// <inheritdoc />
    public Guid? GetAuthPrincipalId()
    {
        var principalIdStr = GetCurrentSession()?.User?.Id;
        return principalIdStr is null ? null : Guid.Parse(principalIdStr);
    }

    /// <summary>
    ///     This restores the session on initialization of the page.
    /// </summary>
    public virtual async Task<Session?> RestoreSessionOnInit()
    {
        if (GetCurrentSession() == null)
            try
            {
                var session = await RestoreSessionAsync();
                return session;
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error: {ex.Message}");
            }

        return null;
    }
}