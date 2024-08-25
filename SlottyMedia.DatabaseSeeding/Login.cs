using SlottyMedia.LoggingProvider;
using Supabase;
using Supabase.Gotrue.Exceptions;

namespace SlottyMedia.DatabaseSeeding;

/// <summary>
/// Login class to handle user login and logout operations for the seeding process.
/// </summary>
public class Login
{
    private static readonly Logging<Login> logger = new();
    
    /// <summary>
    /// Login the user with the given client.
    /// </summary>
    /// <param name="client"></param>
    public async Task LoginUser(Client client)
    {
        try
        {
            logger.LogDebug("Logging in user for seeding.");
            await client.Auth.SignIn("kuchenmampfer@udssr.su", "1234567");
        }
        catch (GotrueException ex)
        {
            if (ex.Reason == FailureHint.Reason.UserBadLogin)
            {
                logger.LogDebug("User not found. Creating user for seeding.");
                await client.Auth.SignUp("kuchenmampfer@udssr.su", "1234567");
                await client.Auth.SignIn("kuchenmampfer@udssr.su", "1234567");
            }
        }
        catch (Exception ex)
        {
            logger.LogError(ex, $"Error while logging in user for seeding. {ex.Message}");
        }
    }

    /// <summary>
    /// This method logs out the user.
    /// </summary>
    /// <param name="client"></param>
    public async Task LogoutUser(Client client)
    {
        logger.LogDebug("Logging out user after seeding.");
        await client.Auth.SignOut();
    }
}