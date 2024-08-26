using SlottyMedia.Database.Daos;
using SlottyMedia.Database.Exceptions;

namespace SlottyMedia.Tests.DatabaseTests.DatabaseModelsTests;

/// <summary>
///     Test class for the UserLikePostRelationDao model.
/// </summary>
[TestFixture]
public class UserLikePostRelationDaoTest : BaseDatabaseTestClass
{
    /// <summary>
    ///     One-time setup method to initialize Supabase client and insert test data.
    /// </summary>
    [OneTimeSetUp]
    public async Task OneTimeSetup()
    {
        _userToWorkWith = await DatabaseActions.Insert(InitializeModels.GetUserDto(UserId));

        _forumToWorkWirh = await DatabaseActions.Insert(InitializeModels.GetForumDto(_userToWorkWith));

        _postToWorkWith =
            await DatabaseActions.Insert(InitializeModels.GetPostsDto(_forumToWorkWirh, _userToWorkWith));
    }

    /// <summary>
    ///     Setup method to initialize a new UserLikePostRelationDao instance before each test.
    /// </summary>
    [SetUp]
    public void Setup()
    {
        _relationToWorkWith = new UserLikePostRelationDao
        {
            UserId = _userToWorkWith.UserId,
            PostId = _postToWorkWith.PostId
        };
    }

    /// <summary>
    ///     Tear down method to delete the test relation after each test.
    /// </summary>
    [TearDown]
    public async Task TearDown()
    {
        try
        {
            if (_relationToWorkWith.UserLikePostRelationId is null) return;

            var relation = await DatabaseActions.GetEntityByField<UserLikePostRelationDao>("userLikePostRelationID",
                _relationToWorkWith.UserLikePostRelationId.ToString() ?? "");
            if (relation != null) await DatabaseActions.Delete(relation);
        }
        catch (Exception ex)
        {
            Console.WriteLine($"TearDown failed with exception: {ex.Message}");
        }
    }

    /// <summary>
    ///     One-time tear down method to delete the test data after all tests are run.
    /// </summary>
    [OneTimeTearDown]
    public async Task OneTimeTearDown()
    {
        try
        {
            if (_postToWorkWith.PostId is null || _forumToWorkWirh.ForumId is null ||
                _userToWorkWith.UserId is null) return;

            var post = await DatabaseActions.GetEntityByField<PostsDao>("postID",
                _postToWorkWith.PostId.ToString() ?? "");
            if (post != null) await DatabaseActions.Delete(post);

            var forum = await DatabaseActions.GetEntityByField<ForumDao>("forumID",
                _forumToWorkWirh.ForumId.ToString() ?? "");
            if (forum != null) await DatabaseActions.Delete(forum);

            var user = await DatabaseActions.GetEntityByField<UserDao>("userID",
                _userToWorkWith.UserId.ToString() ?? "");
            if (user != null) await DatabaseActions.Delete(user);
        }
        catch (DatabaseMissingItemException)
        {
        }
        catch (Exception ex)
        {
            Console.WriteLine($"OneTimeTearDown failed with exception: {ex.Message}");
        }
    }

    private UserLikePostRelationDao _relationToWorkWith;
    private UserDao _userToWorkWith;
    private PostsDao _postToWorkWith;
    private ForumDao _forumToWorkWirh;

    /// <summary>
    ///     Test method to insert a new user-like-post relation into the database.
    /// </summary>
    [Test]
    public async Task Insert()
    {
        try
        {
            var insertedRelation = await DatabaseActions.Insert(_relationToWorkWith);
            Assert.Multiple(() =>
            {
                Assert.That(insertedRelation, Is.Not.Null, "Inserted relation should not be null");
                Assert.That(insertedRelation.UserId, Is.EqualTo(_relationToWorkWith.UserId), "UserId should match");
                Assert.That(insertedRelation.PostId, Is.EqualTo(_relationToWorkWith.PostId), "PostId should match");
            });

            _relationToWorkWith = insertedRelation;
        }
        catch (GeneralDatabaseException ex)
        {
            Assert.Fail($"Insert test failed with database exception: {ex.Message}");
        }
    }

    /// <summary>
    ///     Test method to delete an existing user-like-post relation from the database.
    /// </summary>
    [Test]
    public async Task Delete()
    {
        try
        {
            var insertedRelation = await DatabaseActions.Insert(_relationToWorkWith);
            Assert.That(insertedRelation, Is.Not.Null, "Inserted relation should not be null");

            var deletedRelation = await DatabaseActions.Delete(insertedRelation);
            Assert.That(deletedRelation, Is.True, "Deleted relation should not be false");
        }
        catch (DatabaseMissingItemException)
        {
        }
        catch (GeneralDatabaseException ex)
        {
            Assert.Fail($"Delete test failed with database exception: {ex.Message}");
        }
    }

    /// <summary>
    ///     Test method to retrieve a user-like-post relation by a specific field from the database.
    /// </summary>
    [Test]
    public async Task GetEntityByField()
    {
        try
        {
            var insertedRelation = await DatabaseActions.Insert(_relationToWorkWith);
            Assert.Multiple(() =>
            {
                Assert.That(insertedRelation, Is.Not.Null, "Inserted relation should not be null");
                Assert.That(insertedRelation.UserLikePostRelationId, Is.Not.Null,
                    "Inserted relation ID should not be null");
            });

            var relation = await DatabaseActions.GetEntityByField<UserLikePostRelationDao>("userLikePostRelationID",
                insertedRelation.UserLikePostRelationId.ToString() ?? "");
            Assert.Multiple(() =>
            {
                Assert.That(relation, Is.Not.Null, "Retrieved relation should not be null");
                if (relation != null)
                {
                    Assert.That(relation.UserId, Is.EqualTo(insertedRelation.UserId), "UserId should match");
                    Assert.That(relation.PostId, Is.EqualTo(insertedRelation.PostId), "PostId should match");
                    Assert.That(relation.CreatedAt, Is.EqualTo(insertedRelation.CreatedAt), "CreatedAt should match");
                }
            });

            _relationToWorkWith = relation;
        }
        catch (GeneralDatabaseException ex)
        {
            Assert.Fail($"GetEntityByField test failed with database exception: {ex.Message}");
        }
    }
}