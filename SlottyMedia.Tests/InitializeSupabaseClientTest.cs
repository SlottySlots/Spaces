namespace SlottyMedia.Tests;

/// <summary>
/// Test class for the InitializeSupabaseClient class.
/// </summary>
public class InitializeSupabaseClientTest
{
    private Supabase.Client _supabaseClient;

    /// <summary>
    /// Setup method to initialize the Supabase client before each test.
    /// </summary>
    [SetUp]
    public async Task Setup()
    {
        _supabaseClient = await InitializeSupabaseClient.GetSupabaseClient();
    }

    /// <summary>
    /// Test method to verify that the Supabase client is not null.
    /// </summary>
    [Test]
    public void TestGetSupabaseClient()
    {
        Assert.IsNotNull(_supabaseClient);
    }
}