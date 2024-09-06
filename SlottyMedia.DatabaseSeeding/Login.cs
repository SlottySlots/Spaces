using Bogus;
using SlottyMedia.LoggingProvider;
using Supabase;
using Supabase.Gotrue.Exceptions;

namespace SlottyMedia.DatabaseSeeding;

/// <summary>
///     Login class to handle user login and logout operations for the seeding process.
/// </summary>
public class Login
{
    private static readonly Logging<Login> logger = new();

    private static readonly string CredentialsFilePath = "login_credentials.txt";

    /// <summary>
    ///     Login the user with the given client.
    /// </summary>
    /// <param name="client"></param>
    public async Task LoginUser(Client client)
    {
        try
        {
            logger.LogDebug("Logging in user for seeding.");
            var (email, password) = ReadLogin();
            if (email == string.Empty || password == string.Empty)
            {
client = await HandleLogin(client);
            }
            else
            {
                await client.Auth.SignIn(email, password);
            }
        }
        catch (GotrueException ex)
        {
            if (ex.Reason == FailureHint.Reason.UserBadLogin)
            {
                logger.LogDebug("User not found. Creating user for seeding.");

                client = await HandleLogin(client);
            }
        }
        catch (Exception ex)
        {
            logger.LogError(ex, $"Error while logging in user for seeding. {ex.Message}");
        }
    }

    /// <summary>
    ///     This method logs out the user.
    /// </summary>
    /// <param name="client"></param>
    public async Task LogoutUser(Client client)
    {
        logger.LogDebug("Logging out user after seeding.");
        await client.Auth.SignOut();
    }

    private async Task<Client> HandleLogin(Client client)
    {
        var bogus = new Faker();
        var email = bogus.Internet.Email();
        var password = bogus.Internet.Password();
        SaveLogin(email, password);
        await client.Auth.SignUp(email, password);
        await client.Auth.SignIn(email, password);
        return client;
    }

    private void SaveLogin(string email, string password)
    {
        Environment.SetEnvironmentVariable("SEEDING_EMAIL", email, EnvironmentVariableTarget.User);
        Environment.SetEnvironmentVariable("SEEDING_PASSWORD", password, EnvironmentVariableTarget.User);
    }

    private (string email, string password) ReadLogin()
    {
        var email = Environment.GetEnvironmentVariable("SEEDING_EMAIL", EnvironmentVariableTarget.User) ?? string.Empty;
        var password = Environment.GetEnvironmentVariable("SEEDING_PASSWORD", EnvironmentVariableTarget.User) ??
                       string.Empty;

        return (email, password);
    }
}