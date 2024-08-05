using SlottyMedia.Backend.Models;
using SlottyMedia.Database;
using SlottyMedia.Database.Models;
using Supabase;

namespace SlottyMedia.Tests.DatabaseTests.DatabaseModelsTests;

/// <summary>
/// Test class for the UserLikePostRelationDto model.
/// </summary>
[TestFixture]
public class UserLikePostRelationDtoTest
{
    private Client _supabaseClient;
    private IDatabaseActions _databaseActions;
    private UserLikePostRelationDto _relationToWorkWith;
    private UserDto _userToWorkWith;
    private PostsDto _postToWorkWith;
    private ForumDto _forumToWorkWirh;

    /// <summary>
    /// One-time setup method to initialize Supabase client and insert test data.
    /// </summary>
    [OneTimeSetUp]
    public async Task OneTimeSetup()
    {
        _supabaseClient = await InitializeSupabaseClient.GetSupabaseClient();
        _databaseActions = new DatabaseActions(_supabaseClient);

        _userToWorkWith = await _databaseActions.Insert(InitializeModels.GetUserDto());

        _forumToWorkWirh = await _databaseActions.Insert(InitializeModels.GetForumDto(_userToWorkWith));

        _postToWorkWith =
            await _databaseActions.Insert(InitializeModels.GetPostsDto(_forumToWorkWirh, _userToWorkWith));
    }

    /// <summary>
    /// Setup method to initialize a new UserLikePostRelationDto instance before each test.
    /// </summary>
    [SetUp]
    public void Setup()
    {
        _relationToWorkWith = new UserLikePostRelationDto()
        {
            UserId = _userToWorkWith.UserId,
            PostId = _postToWorkWith.PostId
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
            var relation = await _databaseActions.GetEntityByField<UserLikePostRelationDto>("userLikePostRelationID",
                _relationToWorkWith.UserLikePostRelationId);
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
            var post = await _databaseActions.GetEntityByField<PostsDto>("postID", _postToWorkWith.PostId);
            if (post != null) await _databaseActions.Delete(post);

            var forum = await _databaseActions.GetEntityByField<ForumDto>("forumID", _forumToWorkWirh.ForumId);
            if (forum != null) await _databaseActions.Delete(forum);

            var user = await _databaseActions.GetEntityByField<UserDto>("userID", _userToWorkWith.UserId);
            if (user != null) await _databaseActions.Delete(user);
        }
        catch (Exception ex)
        {
            Console.WriteLine($"OneTimeTearDown failed with exception: {ex.Message}");
        }
    }

    /// <summary>
    /// Test method to insert a new user-like-post relation into the database.
    /// </summary>
    [Test]
    public async Task Insert()
    {
        try
        {
            var insertedRelation = await _databaseActions.Insert(_relationToWorkWith);
            Assert.IsNotNull(insertedRelation, "Inserted relation should not be null");
            Assert.That(insertedRelation.UserId, Is.EqualTo(_relationToWorkWith.UserId), "UserId should match");
            Assert.That(insertedRelation.PostId, Is.EqualTo(_relationToWorkWith.PostId), "PostId should match");

            _relationToWorkWith = insertedRelation;
        }
        catch (DatabaseExceptions ex)
        {
            Assert.Fail($"Insert test failed with database exception: {ex.Message}");
        }
    }

    /// <summary>
    /// Test method to delete an existing user-like-post relation from the database.
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
    /// Test method to retrieve a user-like-post relation by a specific field from the database.
    /// </summary>
    [Test]
    public async Task GetEntityByField()
    {
        try
        {
            var insertedRelation = await _databaseActions.Insert(_relationToWorkWith);
            Assert.IsNotNull(insertedRelation, "Inserted relation should not be null");

            var relation = await _databaseActions.GetEntityByField<UserLikePostRelationDto>("userLikePostRelationID",
                insertedRelation.UserLikePostRelationId);
            Assert.IsNotNull(relation, "Retrieved relation should not be null");
            Assert.That(relation.UserId, Is.EqualTo(insertedRelation.UserId), "UserId should match");
            Assert.That(relation.PostId, Is.EqualTo(insertedRelation.PostId), "PostId should match");
            Assert.That(relation.CreatedAt, Is.EqualTo(insertedRelation.CreatedAt), "CreatedAt should match");

            _relationToWorkWith = relation;
        }
        catch (DatabaseExceptions ex)
        {
            Assert.Fail($"GetEntityByField test failed with database exception: {ex.Message}");
        }
    }
}