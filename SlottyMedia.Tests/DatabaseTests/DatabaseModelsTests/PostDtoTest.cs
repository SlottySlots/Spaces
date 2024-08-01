using SlottyMedia.Backend.Models;
using SlottyMedia.Database;
using SlottyMedia.Database.Models;
using Supabase;

namespace SlottyMedia.Tests.DatabaseTests.DatabaseModelsTests;

/// <summary>
/// Test class for the PostsDto model.
/// </summary>
[TestFixture]
public class PostDtoTest
{
    private Client _supabaseClient;
    private IDatabaseActions _databaseActions;
    private PostsDto _postToWorkWith;
    private UserDto _userToWorkWith;
    private ForumDto _forumToWorkWith;

    /// <summary>
    /// One-time setup method to initialize Supabase client and insert test data.
    /// </summary>
    [OneTimeSetUp]
    public async Task OneTimeSetup()
    {
        _supabaseClient = await InitializeSupabaseClient.GetSupabaseClient();
        _databaseActions = new DatabaseActions(_supabaseClient);

        _userToWorkWith = await _databaseActions.Insert(new UserDto()
        {
            UserId = Guid.NewGuid().ToString(),
            UserName = "I'm a Test User",
            Description = "Please don't delete me",
            RoleId = "c0589855-a81c-451d-8587-3061926a1f3a"
        });

        _forumToWorkWith = await _databaseActions.Insert(new ForumDto()
        {
            CreatorUserId = _userToWorkWith.UserId,
            ForumTopic = "I'm a Test Forum"
        });
    }

    /// <summary>
    /// Setup method to initialize a new PostsDto instance before each test.
    /// </summary>
    [SetUp]
    public void Setup()
    {
        _postToWorkWith = new PostsDto()
        {
            ForumId = _forumToWorkWith.ForumId,
            UserId = _userToWorkWith.UserId,
            Headline = "I'm a Test Posts Headline",
            Content = "I'm a Test Post"
        };
    }

    /// <summary>
    /// Tear down method to delete the test post after each test.
    /// </summary>
    [TearDown]
    public async Task TearDown()
    {
        try
        {
            var post = await _databaseActions.GetEntityByField<PostsDto>("postID", _postToWorkWith.PostId);
            if (post != null) await _databaseActions.Delete(post);
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
            var forum = await _databaseActions.GetEntityByField<ForumDto>("forumID", _forumToWorkWith.ForumId);
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
    /// Test method to insert a new post into the database.
    /// </summary>
    [Test]
    public async Task Insert()
    {
        try
        {
            var insertedPost = await _databaseActions.Insert(_postToWorkWith);
            Assert.IsNotNull(insertedPost, "Inserted post should not be null");
            Assert.That(insertedPost.UserId, Is.EqualTo(_postToWorkWith.UserId), "CreatorUserId should match");
            Assert.That(insertedPost.Content, Is.EqualTo(_postToWorkWith.Content), "Content should match");

            _postToWorkWith = insertedPost;
        }
        catch (DatabaseExceptions ex)
        {
            Assert.Fail($"Insert test failed with database exception: {ex.Message}");
        }
    }

    /// <summary>
    /// Test method to update an existing post in the database.
    /// </summary>
    [Test]
    public async Task Update()
    {
        try
        {
            var insertedPost = await _databaseActions.Insert(_postToWorkWith);
            Assert.IsNotNull(insertedPost, "Inserted post should not be null");

            insertedPost.Content = "I'm an updated Test Post";
            var updatedPost = await _databaseActions.Update(insertedPost);

            Assert.IsNotNull(updatedPost, "Updated post should not be null");
            Assert.That(updatedPost.PostId, Is.EqualTo(insertedPost.PostId), "PostId should match");
            Assert.That(updatedPost.UserId, Is.EqualTo(insertedPost.UserId), "CreatorUserId should match");
            Assert.That(updatedPost.Content, Is.EqualTo(insertedPost.Content), "Content should match");

            _postToWorkWith = updatedPost;
        }
        catch (DatabaseExceptions ex)
        {
            Assert.Fail($"Update test failed with database exception: {ex.Message}");
        }
    }

    /// <summary>
    /// Test method to delete an existing post from the database.
    /// </summary>
    [Test]
    public async Task Delete()
    {
        try
        {
            var insertedPost = await _databaseActions.Insert(_postToWorkWith);
            Assert.IsNotNull(insertedPost, "Inserted post should not be null");

            var deletedPost = await _databaseActions.Delete(insertedPost);
            Assert.IsNotNull(deletedPost, "Deleted post should not be null");
        }
        catch (DatabaseExceptions ex)
        {
            Assert.Fail($"Delete test failed with database exception: {ex.Message}");
        }
    }

    /// <summary>
    /// Test method to retrieve a post by a specific field from the database.
    /// </summary>
    [Test]
    public async Task GetEntityByField()
    {
        try
        {
            var insertedPost = await _databaseActions.Insert(_postToWorkWith);
            Assert.IsNotNull(insertedPost, "Inserted post should not be null");

            var post = await _databaseActions.GetEntityByField<PostsDto>("postID", insertedPost.PostId);
            Assert.IsNotNull(post, "Retrieved post should not be null");
            Assert.That(post.PostId, Is.EqualTo(insertedPost.PostId), "PostId should match");
            Assert.That(post.UserId, Is.EqualTo(insertedPost.UserId), "CreatorUserId should match");
            Assert.That(post.Content, Is.EqualTo(insertedPost.Content), "Content should match");

            _postToWorkWith = post;
        }
        catch (DatabaseExceptions ex)
        {
            Assert.Fail($"GetEntityByField test failed with database exception: {ex.Message}");
        }
    }
}