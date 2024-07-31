namespace SlottyMedia.Tests;

public class InitializeSupabaseClientTest
{
    private Supabase.Client _supabaseClient;
    [SetUp]
    public void SetUp()
    {
        _supabaseClient = InitializeSupabaseClient.GetSupabaseClient();
    }
    
    [Test]
    public void TestGetSupabaseClient()
    {
        Assert.IsNotNull(_supabaseClient);
    }
}