using SlottyMedia.Database;
using SlottyMedia.Database.Daos;
using Supabase;
using Supabase.Gotrue.Exceptions;

namespace SlottyMedia.Tests.DatabaseTests;

/// <summary>
///     This class is the Base Class for all Database Tests
/// </summary>
public class BaseDatabaseTestClass
{
    private readonly Client _client = InitializeSupabaseClient.GetSupabaseClient();

    /// <summary>
    ///     The UserId of the User
    /// </summary>
    public Guid UserId { get; set; }

    /// <summary>
    ///     The DatabaseActions Object
    /// </summary>
    public DatabaseActions DatabaseActions { get; set; }

    public UserDao UserToWorkWith { get; set; }


    /// <summary>
    ///     This Method is used to setup the Tests. It logs in the User and sets the UserId Property
    ///     if the Login was successful if not it will signup the User and set the UserId Property
    /// </summary>
    [OneTimeSetUp]
    public async Task Setup()
    {
        try
        {
            await _client.Auth.SignIn("kuchenmampfer@udssr.su", "1234567");
            UserId = Guid.Parse(_client.Auth.CurrentUser!.Id!);
        }
        catch (GotrueException ex)
        {
            if (ex.Reason == FailureHint.Reason.UserBadLogin)
            {
                await _client.Auth.SignUp("kuchenmampfer@udssr.su", "1234567");
                await _client.Auth.SignIn("kuchenmampfer@udssr.su", "1234567");
                UserId = Guid.Parse(_client.Auth.CurrentUser!.Id!);
            }
        }
        catch (Exception)
        {
            Assert.Fail("Could not login");
        }

        DatabaseActions = new DatabaseActions(_client);
    }

    /// <summary>
    ///     This Method is used to TearDown the Tests. It logs out the User
    /// </summary>
    [OneTimeTearDown]
    public async Task TearDown()
    {
        await _client.Auth.SignOut();
    }
}