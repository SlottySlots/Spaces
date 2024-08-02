using SlottyMedia.Database;
using SlottyMedia.Database.Models;
using Supabase;

namespace SlottyMedia.Tests.DatabaseTests;

/// <summary>
/// Tests for DatabaseActions class.
/// </summary>
[TestFixture]
public class DatabaseActionTests
{
    private Client _supabaseClient;
    private IDatabaseActions _databaseActions;
    private UserDto _userToWorkWith;

    [OneTimeSetUp]
    public async Task OneTimeSetup()
    {
        _supabaseClient = await InitializeSupabaseClient.GetSupabaseClient();
        _databaseActions = new DatabaseActions(_supabaseClient);
    }

    [SetUp]
    public void Setup()
    {
        _userToWorkWith = InitializeModels.GetUserDto();
    }

    [TearDown]
    public async Task TearDown()
    {
        try
        {
            var user = await _databaseActions.GetEntityByField<UserDto>("userID", _userToWorkWith.UserId);
            if (user != null) await _databaseActions.Delete(user);
        }
        catch (Exception ex)
        {
            Console.WriteLine($"TearDown failed with exception: {ex.Message}");
        }
    }

    /// <summary>
    /// Tests the Insert method of DatabaseActions.
    /// </summary>
    [Test]
    public async Task Insert()
    {
        try
        {
            var insertedUser = await _databaseActions.Insert(_userToWorkWith);
            Assert.IsNotNull(insertedUser, "Inserted user should not be null");
            Assert.That(insertedUser.UserId, Is.EqualTo(_userToWorkWith.UserId), "UserId should match");
            Assert.That(insertedUser.UserName, Is.EqualTo(_userToWorkWith.UserName), "UserName should match");
            Assert.That(insertedUser.Description, Is.EqualTo(_userToWorkWith.Description), "Description should match");
        }
        catch (DatabaseExceptions ex)
        {
            Assert.Fail($"Insert test failed with database exception: {ex.Message}");
        }
    }

    /// <summary>
    /// Tests the Update method of DatabaseActions.
    /// </summary>
    [Test]
    public async Task Update()
    {
        try
        {
            var insertedUser = await _databaseActions.Insert(_userToWorkWith);
            Assert.IsNotNull(insertedUser, "Inserted user should not be null");

            insertedUser.Description = "Please don't delete me, I'm updated";
            var updatedUser = await _databaseActions.Update(insertedUser);

            Assert.IsNotNull(updatedUser, "Updated user should not be null");
            Assert.That(updatedUser.UserId, Is.EqualTo(insertedUser.UserId), "UserId should match");
            Assert.That(updatedUser.UserName, Is.EqualTo(insertedUser.UserName), "UserName should match");
            Assert.That(updatedUser.Description, Is.EqualTo(insertedUser.Description), "Description should match");
        }
        catch (DatabaseExceptions ex)
        {
            Assert.Fail($"Update test failed with database exception: {ex.Message}");
        }
    }

    /// <summary>
    /// Tests the Delete method of DatabaseActions.
    /// </summary>
    [Test]
    public async Task Delete()
    {
        try
        {
            var insertedUser = await _databaseActions.Insert(_userToWorkWith);
            Assert.IsNotNull(insertedUser, "Inserted user should not be null");

            var deletedUser = await _databaseActions.Delete(insertedUser);
            Assert.IsNotNull(deletedUser, "Deleted user should not be null");
        }
        catch (DatabaseExceptions ex)
        {
            Assert.Fail($"Delete test failed with database exception: {ex.Message}");
        }
    }

    /// <summary>
    /// Tests the GetEntityByField method of DatabaseActions.
    /// </summary>
    [Test]
    public async Task GetEntityByField()
    {
        try
        {
            var insertedUser = await _databaseActions.Insert(_userToWorkWith);
            Assert.IsNotNull(insertedUser, "Inserted user should not be null");

            var user = await _databaseActions.GetEntityByField<UserDto>("userID", insertedUser.UserId);
            Assert.IsNotNull(user, "Retrieved user should not be null");
            Assert.That(user.UserId, Is.EqualTo(insertedUser.UserId), "UserId should match");
            Assert.That(user.UserName, Is.EqualTo(insertedUser.UserName), "UserName should match");
            Assert.That(user.Description, Is.EqualTo(insertedUser.Description), "Description should match");
        }
        catch (DatabaseExceptions ex)
        {
            Assert.Fail($"GetEntityByField test failed with database exception: {ex.Message}");
        }
    }
}