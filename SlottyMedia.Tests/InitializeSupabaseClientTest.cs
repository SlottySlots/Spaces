namespace SlottyMedia.Tests;

public class InitializeSupabaseClientTest
{
    private Supabase.Client _supabaseClient;
    [SetUp]
    public async Task Setup()
    {
        _supabaseClient = await InitializeSupabaseClient.GetSupabaseClient();
    }
    
    [Test]
    public void TestGetSupabaseClient()
    {
        Assert.IsNotNull(_supabaseClient);
    }
}