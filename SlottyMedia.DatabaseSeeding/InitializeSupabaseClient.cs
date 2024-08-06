using Supabase;

namespace SlottyMedia.DatabaseSeeding;

public class InitializeSupabaseClient
{
    public static Client GetSupabaseClient()
    {
        var url = Environment.GetEnvironmentVariable("SUPABASE_URL");
        var key = Environment.GetEnvironmentVariable("SUPABASE_KEY");
        if (url is null || key is null) throw new Exception("Supabase settings not found");

        var client = new Client(url, key, new SupabaseOptions
        {
            AutoRefreshToken = true,
            AutoConnectRealtime = true
        });


        return client;
    }
}