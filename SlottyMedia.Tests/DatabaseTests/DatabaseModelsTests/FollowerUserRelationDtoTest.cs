using SlottyMedia.Database;
using SlottyMedia.Database.Models;
using Supabase;

namespace SlottyMedia.Tests.DatabaseTests.DatabaseModelsTests;

/// <summary>
/// Test class for the FollowerUserRelationDto model.
/// </summary>
[TestFixture]
public class FollowerUserRelationDtoTest
{
    private Client _supabaseClient;
    private IDatabaseActions _databaseActions;
    private FollowerUserRelationDto _relationToWorkWith;
    private UserDto _followerUser;
    private UserDto _followedUser;

    /// <summary>
    /// One-time setup method to initialize Supabase client and insert test data.
    /// </summary>
    [OneTimeSetUp]
    public async Task OneTimeSetup()
    {
        _supabaseClient = await InitializeSupabaseClient.GetSupabaseClient();
        _databaseActions = new DatabaseActions(_supabaseClient);

        _followerUser = await _databaseActions.Insert(InitializeModels.GetUserDto());

        _followedUser = await _databaseActions.Insert(InitializeModels.GetUserDto());
    }

    /// <summary>
    /// Setup method to initialize a new FollowerUserRelationDto instance before each test.
    /// </summary>
    [SetUp]
    public void Setup()
    {
        _relationToWorkWith = new FollowerUserRelationDto()
        {
            FollowerUserId = _followerUser.UserId,
            FollowedUserId = _followedUser.UserId
        };
    }

    /// <summary>
    /// Tear down method to delete the test relation after each test.
    /// </summary>
    [TearDown]
    public async Task TearDown()
    {
        try
        {
            var relation = await _databaseActions.GetEntityByField<FollowerUserRelationDto>("followerUserRelationID",
                _relationToWorkWith.FollowerUserRelationId);
            if (relation != null) await _databaseActions.Delete(relation);
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
            var follower = await _databaseActions.GetEntityByField<UserDto>("userID", _followerUser.UserId);
            if (follower != null) await _databaseActions.Delete(follower);

            var followed = await _databaseActions.GetEntityByField<UserDto>("userID", _followedUser.UserId);
            if (followed != null) await _databaseActions.Delete(followed);
        }
        catch (Exception ex)
        {
            Console.WriteLine($"OneTimeTearDown failed with exception: {ex.Message}");
        }
    }

    /// <summary>
    /// Test method to insert a new follower-user relation into the database.
    /// </summary>
    [Test]
    public async Task Insert()
    {
        try
        {
            var insertedRelation = await _databaseActions.Insert(_relationToWorkWith);
            Assert.IsNotNull(insertedRelation, "Inserted relation should not be null");
            Assert.That(insertedRelation.FollowerUserId, Is.EqualTo(_relationToWorkWith.FollowerUserId),
                "FollowerUserId should match");
            Assert.That(insertedRelation.FollowedUserId, Is.EqualTo(_relationToWorkWith.FollowedUserId),
                "FollowedUserId should match");

            _relationToWorkWith = insertedRelation;
        }
        catch (DatabaseExceptions ex)
        {
            Assert.Fail($"Insert test failed with database exception: {ex.Message}");
        }
    }

    /// <summary>
    /// Test method to delete an existing follower-user relation from the database.
    /// </summary>
    [Test]
    public async Task Delete()
    {
        try
        {
            var insertedRelation = await _databaseActions.Insert(_relationToWorkWith);
            Assert.IsNotNull(insertedRelation, "Inserted relation should not be null");

            var deletedRelation = await _databaseActions.Delete(insertedRelation);
            Assert.IsNotNull(deletedRelation, "Deleted relation should not be null");
        }
        catch (DatabaseExceptions ex)
        {
            Assert.Fail($"Delete test failed with database exception: {ex.Message}");
        }
    }

    /// <summary>
    /// Test method to retrieve a follower-user relation by a specific field from the database.
    /// </summary>
    [Test]
    public async Task GetEntityByField()
    {
        try
        {
            var insertedRelation = await _databaseActions.Insert(_relationToWorkWith);
            Assert.IsNotNull(insertedRelation, "Inserted relation should not be null");

            var relation = await _databaseActions.GetEntityByField<FollowerUserRelationDto>("followerUserRelationID",
                insertedRelation.FollowerUserRelationId);
            Assert.IsNotNull(relation, "Retrieved relation should not be null");
            Assert.That(relation.FollowerUserId, Is.EqualTo(insertedRelation.FollowerUserId),
                "FollowerUserId should match");
            Assert.That(relation.FollowedUserId, Is.EqualTo(insertedRelation.FollowedUserId),
                "FollowedUserId should match");
            Assert.That(relation.CreatedAt, Is.EqualTo(insertedRelation.CreatedAt), "CreatedAt should match");

            _relationToWorkWith = relation;
        }
        catch (DatabaseExceptions ex)
        {
            Assert.Fail($"GetEntityByField test failed with database exception: {ex.Message}");
        }
    }
}