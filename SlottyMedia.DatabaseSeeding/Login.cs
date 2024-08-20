using Supabase;
using Supabase.Gotrue.Exceptions;

namespace SlottyMedia.DatabaseSeeding;

public class Login
{
    public async Task LoginUser(Client client)
    {
        try
        {
            await client.Auth.SignIn("kuchenmampfer@udssr.su", "1234567");
        }
        catch (GotrueException ex)
        {
            if (ex.Reason == FailureHint.Reason.UserBadLogin)
            {
                await client.Auth.SignUp("kuchenmampfer@udssr.su", "1234567");
                await client.Auth.SignIn("kuchenmampfer@udssr.su", "1234567");
            }
        }
        catch (Exception)
        {
        }
    }

    public async Task LogoutUser(Client client)
    {
        await client.Auth.SignOut();
    }
}