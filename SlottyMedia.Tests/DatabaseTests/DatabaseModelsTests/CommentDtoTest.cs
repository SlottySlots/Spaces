using SlottyMedia.Backend.Models;
using SlottyMedia.Database;
using SlottyMedia.Database.Models;
using Supabase;

namespace SlottyMedia.Tests.DatabaseTests.DatabaseModelsTests;

/// <summary>
/// Test class for the CommentDto model.
/// </summary>
[TestFixture]
public class CommentDtoTest
{
    private Client _supabaseClient;
    private IDatabaseActions _databaseActions;
    private CommentDto _commentToWorkWith;
    private UserDto _userToWorkWith;
    private PostsDto _postToWorkWith;
    private ForumDto _forumToWorkWith;

    /// <summary>
    /// One-time setup method to initialize Supabase client and insert test data.
    /// </summary>
    [OneTimeSetUp]
    public async Task OneTimeSetup()
    {
        _supabaseClient = await InitializeSupabaseClient.GetSupabaseClient();
        _databaseActions = new DatabaseActions(_supabaseClient);

        _userToWorkWith = await _databaseActions.Insert(InitializeModels.GetUserDto());

        _forumToWorkWith = await _databaseActions.Insert(InitializeModels.GetForumDto(_userToWorkWith));

        _postToWorkWith =
            await _databaseActions.Insert(InitializeModels.GetPostsDto(_forumToWorkWith, _userToWorkWith));
    }

    /// <summary>
    /// Setup method to initialize a new CommentDto instance before each test.
    /// </summary>
    [SetUp]
    public void Setup()
    {
        _commentToWorkWith = new CommentDto()
        {
            CreatorUserId = _userToWorkWith.UserId,
            PostId = _postToWorkWith.PostId,
            Content = "I'm a Test Comment"
        };
    }

    /// <summary>
    /// Tear down method to delete the test comment after each test.
    /// </summary>
    [TearDown]
    public async Task TearDown()
    {
        try
        {
            var comment =
                await _databaseActions.GetEntityByField<CommentDto>("commentID", _commentToWorkWith.CommentId);
            if (comment != null) await _databaseActions.Delete(comment);
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
    /// Test method to insert a new comment into the database.
    /// </summary>
    [Test]
    public async Task Insert()
    {
        try
        {
            var insertedComment = await _databaseActions.Insert(_commentToWorkWith);
            Assert.IsNotNull(insertedComment, "Inserted comment should not be null");
            Assert.That(insertedComment.CreatorUserId, Is.EqualTo(_commentToWorkWith.CreatorUserId),
                "CreatorUserId should match");
            Assert.That(insertedComment.Content, Is.EqualTo(_commentToWorkWith.Content), "Content should match");

            _commentToWorkWith = insertedComment;
        }
        catch (DatabaseExceptions ex)
        {
            Assert.Fail($"Insert test failed with database exception: {ex.Message}");
        }
    }

    /// <summary>
    /// Test method to update an existing comment in the database.
    /// </summary>
    [Test]
    public async Task Update()
    {
        try
        {
            var insertedComment = await _databaseActions.Insert(_commentToWorkWith);
            Assert.IsNotNull(insertedComment, "Inserted comment should not be null");

            insertedComment.Content = "I'm an updated Test Comment";
            var updatedComment = await _databaseActions.Update(insertedComment);

            Assert.IsNotNull(updatedComment, "Updated comment should not be null");
            Assert.That(updatedComment.CreatorUserId, Is.EqualTo(insertedComment.CreatorUserId),
                "CreatorUserId should match");
            Assert.That(updatedComment.Content, Is.EqualTo(insertedComment.Content), "Content should match");

            _commentToWorkWith = updatedComment;
        }
        catch (DatabaseExceptions ex)
        {
            Assert.Fail($"Update test failed with database exception: {ex.Message}");
        }
    }

    /// <summary>
    /// Test method to delete an existing comment from the database.
    /// </summary>
    [Test]
    public async Task Delete()
    {
        try
        {
            var insertedComment = await _databaseActions.Insert(_commentToWorkWith);
            Assert.IsNotNull(insertedComment, "Inserted comment should not be null");

            var deletedComment = await _databaseActions.Delete(insertedComment);
            Assert.IsNotNull(deletedComment, "Deleted comment should not be null");
        }
        catch (DatabaseExceptions ex)
        {
            Assert.Fail($"Delete test failed with database exception: {ex.Message}");
        }
    }

    /// <summary>
    /// Test method to retrieve a comment by a specific field from the database.
    /// </summary>
    [Test]
    public async Task GetEntityByField()
    {
        try
        {
            var insertedComment = await _databaseActions.Insert(_commentToWorkWith);
            Assert.IsNotNull(insertedComment, "Inserted comment should not be null");

            var comment = await _databaseActions.GetEntityByField<CommentDto>("commentID", insertedComment.CommentId);
            Assert.IsNotNull(comment, "Retrieved comment should not be null");
            Assert.That(comment.CreatorUserId, Is.EqualTo(insertedComment.CreatorUserId), "CreatorUserId should match");
            Assert.That(comment.Content, Is.EqualTo(insertedComment.Content), "Content should match");

            _commentToWorkWith = comment;
        }
        catch (DatabaseExceptions ex)
        {
            Assert.Fail($"GetEntityByField test failed with database exception: {ex.Message}");
        }
    }
}