using SlottyMedia.Backend.Exceptions;
using SlottyMedia.Backend.Services.Interfaces;
using Supabase.Gotrue;

using Client = Supabase.Client;

namespace SlottyMedia.Backend.Services;

public class SignupServiceImpl : ISignupService
{
    private readonly Client _supabaseClient;
    private readonly IUserService _userService;
    private readonly ICookieService _cookieService;

    
    public SignupServiceImpl(Client supabaseClient, IUserService userService, ICookieService cookieService)
    {
        _supabaseClient = supabaseClient;
        _userService = userService;
        _cookieService = cookieService;
    }

    
    public async Task<Session> SignUp(string username, string email, string password)
    {
        // throw exception if username already exists
        var user = await _userService.GetUserByUsername(username);
        if (user == null)
            throw new UsernameAlreadyExistsException(username);
        
        // throw exception if email already exists
        user = await _userService.GetUserByEmail(email);
        if (user == null)
            throw new EmailAlreadyExistsException(email);
        
        // else: sign up user
        var options = new SignUpOptions
        {
            Data = new Dictionary<string, object>
            {
                { "username", username }
            }
        };
        var session = await _supabaseClient.Auth.SignUp(email, password, options);
        
        // throw exception if, for whichever reason, the session is null
        if (session == null)
            throw new InvalidOperationException("An unknown error occured in the Supabase client while attempting to perform a signup.");
        
        // save cookies
        await _cookieService.SetCookie("supabase.auth.token", session.AccessToken, 7);
        await _cookieService.SetCookie("supabase.auth.refreshToken", session.RefreshToken, 7);

        return session;
    }
}