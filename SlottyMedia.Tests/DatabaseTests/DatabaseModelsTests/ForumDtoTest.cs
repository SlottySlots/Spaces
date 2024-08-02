using SlottyMedia.Backend.Models;
using SlottyMedia.Database;
using SlottyMedia.Database.Models;
using Supabase;

namespace SlottyMedia.Tests.DatabaseTests.DatabaseModelsTests;

/// <summary>
/// Test class for the ForumDto model.
/// </summary>
[TestFixture]
public class ForumDtoTest
{
    private Client _supabaseClient;
    private IDatabaseActions _databaseActions;
    private ForumDto _forumToWorkWith;
    private UserDto _userToWorkWith;

    /// <summary>
    /// One-time setup method to initialize Supabase client and insert test data.
    /// </summary>
    [OneTimeSetUp]
    public async Task OneTimeSetup()
    {
        _supabaseClient = await InitializeSupabaseClient.GetSupabaseClient();
        _databaseActions = new DatabaseActions(_supabaseClient);

        _userToWorkWith = await _databaseActions.Insert(InitializeModels.GetUserDto());
    }

    /// <summary>
    /// Setup method to initialize a new ForumDto instance before each test.
    /// </summary>
    [SetUp]
    public void Setup()
    {
        _forumToWorkWith = new ForumDto()
        {
            CreatorUserId = _userToWorkWith.UserId,
            ForumTopic = "I'm a Test Forum"
        };
    }

    /// <summary>
    /// Tear down method to delete the test forum after each test.
    /// </summary>
    [TearDown]
    public async Task TearDown()
    {
        try
        {
            var forum = await _databaseActions.GetEntityByField<ForumDto>("forumID", _forumToWorkWith.ForumId);
            if (forum != null) await _databaseActions.Delete(forum);
        }
        catch (Exception ex)
        {
            Console.WriteLine($"TearDown failed with exception: {ex.Message}");
        }
    }

    /// <summary>
    /// One-time tear down method to delete the test data after all tests are run.
    /// </summary>
    [OneTimeTearDown]
    public async Task OneTimeTearDown()
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
    /// Test method to insert a new forum into the database.
    /// </summary>
    [Test]
    public async Task Insert()
    {
        try
        {
            var insertedForum = await _databaseActions.Insert(_forumToWorkWith);
            Assert.IsNotNull(insertedForum, "Inserted forum should not be null");
            Assert.That(insertedForum.CreatorUserId, Is.EqualTo(_forumToWorkWith.CreatorUserId),
                "CreatorUserId should match");
            Assert.That(insertedForum.ForumTopic, Is.EqualTo(_forumToWorkWith.ForumTopic), "ForumTopic should match");

            _forumToWorkWith = insertedForum;
        }
        catch (DatabaseExceptions ex)
        {
            Assert.Fail($"Insert test failed with database exception: {ex.Message}");
        }
    }

    /// <summary>
    /// Test method to update an existing forum in the database.
    /// </summary>
    [Test]
    public async Task Update()
    {
        try
        {
            var insertedForum = await _databaseActions.Insert(_forumToWorkWith);
            Assert.IsNotNull(insertedForum, "Inserted forum should not be null");

            insertedForum.ForumTopic = "I'm an updated Test Forum";
            var updatedForum = await _databaseActions.Update(insertedForum);

            Assert.IsNotNull(updatedForum, "Updated forum should not be null");
            Assert.That(updatedForum.ForumId, Is.EqualTo(insertedForum.ForumId), "ForumId should match");
            Assert.That(updatedForum.CreatorUserId, Is.EqualTo(insertedForum.CreatorUserId),
                "CreatorUserId should match");
            Assert.That(updatedForum.ForumTopic, Is.EqualTo(insertedForum.ForumTopic), "ForumTopic should match");

            _forumToWorkWith = updatedForum;
        }
        catch (DatabaseExceptions ex)
        {
            Assert.Fail($"Update test failed with database exception: {ex.Message}");
        }
    }

    /// <summary>
    /// Test method to delete an existing forum from the database.
    /// </summary>
    [Test]
    public async Task Delete()
    {
        try
        {
            var insertedForum = await _databaseActions.Insert(_forumToWorkWith);
            Assert.IsNotNull(insertedForum, "Inserted forum should not be null");

            var deletedForum = await _databaseActions.Delete(insertedForum);
            Assert.IsNotNull(deletedForum, "Deleted forum should not be null");
        }
        catch (DatabaseExceptions ex)
        {
            Assert.Fail($"Delete test failed with database exception: {ex.Message}");
        }
    }

    /// <summary>
    /// Test method to retrieve a forum by a specific field from the database.
    /// </summary>
    [Test]
    public async Task GetEntityByField()
    {
        try
        {
            var insertedForum = await _databaseActions.Insert(_forumToWorkWith);
            Assert.IsNotNull(insertedForum, "Inserted forum should not be null");

            var forum = await _databaseActions.GetEntityByField<ForumDto>("forumID", insertedForum.ForumId);
            Assert.IsNotNull(forum, "Retrieved forum should not be null");
            Assert.That(forum.ForumId, Is.EqualTo(insertedForum.ForumId), "ForumId should match");
            Assert.That(forum.CreatorUserId, Is.EqualTo(insertedForum.CreatorUserId), "CreatorUserId should match");
            Assert.That(forum.ForumTopic, Is.EqualTo(insertedForum.ForumTopic), "ForumTopic should match");

            _forumToWorkWith = forum;
        }
        catch (DatabaseExceptions ex)
        {
            Assert.Fail($"GetEntityByField test failed with database exception: {ex.Message}");
        }
    }
}