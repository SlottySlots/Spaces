using SlottyMedia.Backend.Exceptions.signup;
using SlottyMedia.Backend.Services.Interfaces;
using SlottyMedia.Database.Repository.RoleRepo;
using SlottyMedia.DatabaseSeeding.Avatar;
using SlottyMedia.LoggingProvider;
using Supabase.Gotrue;
using Client = Supabase.Client;

namespace SlottyMedia.Backend.Services;

/// <inheritdoc />
public class SignupServiceImpl : ISignupService
{
    private static readonly Logging<SignupServiceImpl> Logger = new();
    private readonly IAvatarGenerator _avatarGenerator;

    private readonly ICookieService _cookieService;
    private readonly IRoleRepository _roleRepository;
    private readonly Client _supabaseClient;
    private readonly IUserService _userService;

    /// <summary>
    ///     Standard Constructor for dependency injection
    /// </summary>
    public SignupServiceImpl(
        Client supabaseClient,
        IUserService userService,
        ICookieService cookieService,
        IRoleRepository roleRepository,
        IAvatarGenerator avatarGenerator)
    {
        _supabaseClient = supabaseClient;
        _userService = userService;
        _cookieService = cookieService;
        _roleRepository = roleRepository;
        _avatarGenerator = avatarGenerator;
    }

    /// <inheritdoc />
    public virtual async Task<Session> SignUp(string username, string email, string password)
    {
        Logger.LogInfo("Attempting to perform signup...");
        Logger.LogDebug($"Signing up user with username: '{username}', email: '{email}'...");

        // throw exception if username contains illegal characters
        if (!username.All(char.IsLetterOrDigit))
        {
            Logger.LogInfo("Signup failed because username contained illegal characters");
            throw new IllegalCharsInUsernameException();
        }

        // throw exception if username is too long or too short
        if (username.Length < 3 || username.Length > 15)
        {
            Logger.LogInfo("Signup failed because username was of illegal size (should be between 3 and 15)");
            throw new IllegalUsernameLengthException();
        }

        // throw exception if password is too short
        if (password.Length < 5)
        {
            Logger.LogInfo("Signup failed because password was too short (should be at least 5 characters long)");
            throw new PasswordTooShortException();
        }

        // throw exception if username already exists
        var isUsernameTaken = await _userService.ExistsByUserName(username);
        if (isUsernameTaken)
        {
            Logger.LogInfo("Signup failed because username was already taken");
            throw new UsernameAlreadyExistsException(username);
        }

        await _supabaseClient.Auth.SignUp(email, password);
        //This is not needed?
        var session = await _supabaseClient.Auth.SignIn(email, password);

        // TODO Check if email already exists, it is unclear how supabase responds in that case!

        // throw exception if, for whichever reason, the session is null
        if (session == null)
            throw new InvalidOperationException(
                "An unknown error occured in the Supabase client while attempting to perform a signup.");

        //TODO catch excception if role does not exist
        var roleId = await _roleRepository.GetRoleIdByName("User");

        await _userService.CreateUser(
            session.User!.Id!,
            username,
            session.User.Email!,
            roleId,
            "Hey, I'm a new user!",
            _avatarGenerator.RandomAvatarB64());


        // save cookies
        Logger.LogDebug("Setting cookies for user.");
        await _cookieService.SetCookie("supabase.auth.token", session.AccessToken!, 7);
        await _cookieService.SetCookie("supabase.auth.refreshToken", session.RefreshToken!, 7);

        return session;
    }
}