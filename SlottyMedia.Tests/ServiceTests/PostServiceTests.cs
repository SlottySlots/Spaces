using Moq;
using SlottyMedia.Backend.Exceptions.Services.PostExceptions;
using SlottyMedia.Backend.Services;
using SlottyMedia.Database.Daos;
using SlottyMedia.Database.Exceptions;
using SlottyMedia.Database.Repository.PostRepo;

namespace SlottyMedia.Tests.ServiceTests;

/// <summary>
///     Unit tests for the PostService class.
/// </summary>
[TestFixture]
public class PostServiceTests
{
    /// <summary>
    ///     Sets up the test environment before each test.
    /// </summary>
    [SetUp]
    public void Setup()
    {
        _mockPostRepository = new Mock<IPostRepository>();
        _postService = new PostService(_mockPostRepository.Object);
    }

    /// <summary>
    ///     Cleans up the test environment after each test.
    /// </summary>
    [TearDown]
    public void TearDown()
    {
        _mockPostRepository.Reset();
    }

    private Mock<IPostRepository> _mockPostRepository;
    private PostService _postService;

    /// <summary>
    ///     Tests that InsertPost returns true when a post is inserted successfully.
    /// </summary>
    [Test]
    public async Task InsertPost_ShouldReturnTrue_WhenPostIsInsertedSuccessfully()
    {
        var post = new PostsDao { PostId = Guid.NewGuid(), Content = "Test content" };
        _mockPostRepository.Setup(x => x.AddElement(It.IsAny<PostsDao>())).ReturnsAsync(post);

        await _postService.InsertPost(post.Content, post.UserId ?? Guid.NewGuid(), Guid.NewGuid());

        _mockPostRepository.Verify(x => x.AddElement(It.IsAny<PostsDao>()), Times.Once);
    }

    /// <summary>
    ///     Tests that InsertPost throws PostIudException when DatabaseIudActionException is thrown.
    /// </summary>
    [Test]
    public void InsertPost_ShouldThrowPostIudException_WhenDatabaseIudActionExceptionIsThrown()
    {
        var post = new PostsDao { PostId = Guid.NewGuid(), Content = "Test content" };
        _mockPostRepository.Setup(x => x.AddElement(It.IsAny<PostsDao>()))
            .ThrowsAsync(new DatabaseIudActionException());

        Assert.ThrowsAsync<PostIudException>(async () =>
            await _postService.InsertPost(post.Content, post.UserId ?? Guid.NewGuid(), Guid.NewGuid()));
    }

    /// <summary>
    ///     Tests that InsertPost throws PostGeneralException when GeneralDatabaseException is thrown.
    /// </summary>
    [Test]
    public void InsertPost_ShouldThrowPostGeneralException_WhenGeneralDatabaseExceptionIsThrown()
    {
        var post = new PostsDao { PostId = Guid.NewGuid(), Content = "Test content" };
        _mockPostRepository.Setup(x => x.AddElement(It.IsAny<PostsDao>()))
            .ThrowsAsync(new GeneralDatabaseException());

        Assert.ThrowsAsync<PostGeneralException>(async () =>
            await _postService.InsertPost(post.Content, post.UserId ?? Guid.NewGuid(), Guid.NewGuid()));
    }

    /// <summary>
    ///     Tests that DeletePost returns true when a post is deleted successfully.
    /// </summary>
    [Test]
    public async Task DeletePost_ShouldReturnTrue_WhenPostIsDeletedSuccessfully()
    {
        var post = new PostsDao { PostId = Guid.NewGuid(), Content = "Test content" };
        _mockPostRepository.Setup(x => x.DeleteElement(It.IsAny<PostsDao>())).Returns(Task.CompletedTask);

        await _postService.DeletePost(post);

        _mockPostRepository.Verify(x => x.DeleteElement(It.IsAny<PostsDao>()), Times.Once);
    }

    /// <summary>
    ///     Tests that DeletePost throws PostIudException when DatabaseIudActionException is thrown.
    /// </summary>
    [Test]
    public void DeletePost_ShouldThrowPostIudException_WhenDatabaseIudActionExceptionIsThrown()
    {
        var post = new PostsDao { PostId = Guid.NewGuid(), Content = "Test content" };
        _mockPostRepository.Setup(x => x.DeleteElement(It.IsAny<PostsDao>()))
            .ThrowsAsync(new DatabaseIudActionException());

        Assert.ThrowsAsync<PostIudException>(async () => await _postService.DeletePost(post));
    }

    /// <summary>
    ///     Tests that DeletePost throws PostGeneralException when GeneralDatabaseException is thrown.
    /// </summary>
    [Test]
    public void DeletePost_ShouldThrowPostGeneralException_WhenGeneralDatabaseExceptionIsThrown()
    {
        var post = new PostsDao { PostId = Guid.NewGuid(), Content = "Test content" };
        _mockPostRepository.Setup(x => x.DeleteElement(It.IsAny<PostsDao>()))
            .ThrowsAsync(new GeneralDatabaseException());

        Assert.ThrowsAsync<PostGeneralException>(async () => await _postService.DeletePost(post));
    }

    /// <summary>
    ///     Tests that GetPostsForUser returns posts when posts are found.
    /// </summary>
    [Test]
    public async Task GetPostsForUser_ShouldReturnPosts_WhenPostsAreFound()
    {
        var userId = Guid.NewGuid();
        var posts = new List<PostsDao> { new() { PostId = Guid.NewGuid(), Content = "Test content", UserId = userId } };
        _mockPostRepository.Setup(x => x.GetPostsByUserId(It.IsAny<Guid>(), It.IsAny<int>(), It.IsAny<int>()))
            .ReturnsAsync(posts);

        var result = await _postService.GetPostsByUserId(userId, 1, 10);

        Assert.That(result, Is.Not.Null);
        Assert.That(result.Count, Is.EqualTo(1));
        Assert.That(result[0].Content, Is.EqualTo("Test content"));
    }

    /// <summary>
    ///     Tests that GetPostsForUser throws PostNotFoundException when DatabaseMissingItemException is thrown.
    /// </summary>
    [Test]
    public void GetPostsForUser_ShouldThrowPostNotFoundException_WhenDatabaseMissingItemExceptionIsThrown()
    {
        var userId = Guid.NewGuid();
        _mockPostRepository.Setup(x => x.GetPostsByUserId(It.IsAny<Guid>(), It.IsAny<int>(), It.IsAny<int>()))
            .ThrowsAsync(new DatabaseMissingItemException());

        Assert.ThrowsAsync<PostNotFoundException>(async () => await _postService.GetPostsByUserId(userId, 1, 10));
    }

    /// <summary>
    ///     Tests that GetPostsForUser throws PostGeneralException when GeneralDatabaseException is thrown.
    /// </summary>
    [Test]
    public void GetPostsForUser_ShouldThrowPostGeneralException_WhenGeneralDatabaseExceptionIsThrown()
    {
        var userId = Guid.NewGuid();
        _mockPostRepository.Setup(x => x.GetPostsByUserId(It.IsAny<Guid>(), It.IsAny<int>(), It.IsAny<int>()))
            .ThrowsAsync(new GeneralDatabaseException());

        Assert.ThrowsAsync<PostGeneralException>(async () => await _postService.GetPostsByUserId(userId, 1, 10));
    }

    /// <summary>
    ///     Tests that UpdatePost returns true when a post is updated successfully.
    /// </summary>
    [Test]
    public async Task UpdatePost_ShouldReturnTrue_WhenPostIsUpdatedSuccessfully()
    {
        var post = new PostsDao { PostId = Guid.NewGuid(), Content = "Updated content" };
        _mockPostRepository.Setup(x => x.UpdateElement(It.IsAny<PostsDao>())).Returns(Task.CompletedTask);

        await _postService.UpdatePost(post);

        _mockPostRepository.Verify(x => x.UpdateElement(It.IsAny<PostsDao>()), Times.Once);
    }

    /// <summary>
    ///     Tests that UpdatePost throws PostIudException when DatabaseIudActionException is thrown.
    /// </summary>
    [Test]
    public void UpdatePost_ShouldThrowPostIudException_WhenDatabaseIudActionExceptionIsThrown()
    {
        var post = new PostsDao { PostId = Guid.NewGuid(), Content = "Updated content" };
        _mockPostRepository.Setup(x => x.UpdateElement(It.IsAny<PostsDao>()))
            .ThrowsAsync(new DatabaseIudActionException());

        Assert.ThrowsAsync<PostIudException>(async () => await _postService.UpdatePost(post));
    }

    /// <summary>
    ///     Tests that UpdatePost throws PostGeneralException when GeneralDatabaseException is thrown.
    /// </summary>
    [Test]
    public void UpdatePost_ShouldThrowPostGeneralException_WhenGeneralDatabaseExceptionIsThrown()
    {
        var post = new PostsDao { PostId = Guid.NewGuid(), Content = "Updated content" };
        _mockPostRepository.Setup(x => x.UpdateElement(It.IsAny<PostsDao>()))
            .ThrowsAsync(new GeneralDatabaseException());

        Assert.ThrowsAsync<PostGeneralException>(async () => await _postService.UpdatePost(post));
    }

    /// <summary>
    ///     Tests that GetPostsFromForum returns posts when posts are found.
    /// </summary>
    [Test]
    public async Task GetPostsFromForum_ShouldReturnPosts_WhenPostsAreFound()
    {
        var userId = Guid.NewGuid();
        var posts = new List<PostsDao> { new() { PostId = Guid.NewGuid(), Content = "Test content", UserId = userId, Forum = new ForumDao(Guid.NewGuid(), "Test content")} };
        _mockPostRepository.Setup(x => x.GetPostsByForumId(It.IsAny<Guid>(), It.IsAny<int>(), It.IsAny<int>()))
            .ReturnsAsync(posts);

        var result = await _postService.GetPostsFromForum(userId, 1, 10);

        Assert.That(result, Is.Not.Null);
        Assert.That(result.Count, Is.EqualTo(1));
        Assert.That(result[0], Is.EqualTo("Test content"));
    }

    /// <summary>
    ///     Tests that GetPostsFromForum throws PostNotFoundException when DatabaseMissingItemException is thrown.
    /// </summary>
    [Test]
    public void GetPostsFromForum_ShouldThrowPostNotFoundException_WhenDatabaseMissingItemExceptionIsThrown()
    {
        var userId = Guid.NewGuid();
        _mockPostRepository.Setup(x => x.GetPostsByForumId(It.IsAny<Guid>(), It.IsAny<int>(), It.IsAny<int>()))
            .ThrowsAsync(new DatabaseMissingItemException());

        Assert.ThrowsAsync<PostNotFoundException>(async () => await _postService.GetPostsFromForum(userId, 1, 10));
    }

    /// <summary>
    ///     Tests that GetPostsFromForum throws PostGeneralException when GeneralDatabaseException is thrown.
    /// </summary>
    [Test]
    public void GetPostsFromForum_ShouldThrowPostGeneralException_WhenGeneralDatabaseExceptionIsThrown()
    {
        var userId = Guid.NewGuid();
        _mockPostRepository.Setup(x => x.GetPostsByForumId(It.IsAny<Guid>(), It.IsAny<int>(), It.IsAny<int>()))
            .ThrowsAsync(new GeneralDatabaseException());

        Assert.ThrowsAsync<PostGeneralException>(async () => await _postService.GetPostsFromForum(userId, 1, 10));
    }

    /// <summary>
    ///     Tests that GetPostById returns a post when a post is found.
    /// </summary>
    [Test]
    public async Task GetPostById_ShouldReturnPost_WhenPostIsFound()
    {
        var postId = Guid.NewGuid();
        var post = new PostsDao { PostId = postId, Content = "Test content" };
        _mockPostRepository.Setup(x => x.GetElementById(It.IsAny<Guid>())).ReturnsAsync(post);

        var result = await _postService.GetPostById(postId);

        Assert.That(result, Is.Not.Null);
        Assert.That(result.Content, Is.EqualTo("Test content"));
    }

    /// <summary>
    ///     Tests that GetPostById throws PostNotFoundException when DatabaseMissingItemException is thrown.
    /// </summary>
    [Test]
    public void GetPostById_ShouldThrowPostNotFoundException_WhenDatabaseMissingItemExceptionIsThrown()
    {
        var postId = Guid.NewGuid();
        _mockPostRepository.Setup(x => x.GetElementById(It.IsAny<Guid>()))
            .ThrowsAsync(new DatabaseMissingItemException());

        Assert.ThrowsAsync<PostNotFoundException>(async () => await _postService.GetPostById(postId));
    }

    /// <summary>
    ///     Tests that GetPostById throws PostGeneralException when GeneralDatabaseException is thrown.
    /// </summary>
    [Test]
    public void GetPostById_ShouldThrowPostGeneralException_WhenGeneralDatabaseExceptionIsThrown()
    {
        var postId = Guid.NewGuid();
        _mockPostRepository.Setup(x => x.GetElementById(It.IsAny<Guid>()))
            .ThrowsAsync(new GeneralDatabaseException());

        Assert.ThrowsAsync<PostGeneralException>(async () => await _postService.GetPostById(postId));
    }

    /// <summary>
    ///     Tests that GetForumCountByUserId returns the correct count.
    /// </summary>
    [Test]
    public async Task GetForumCountByUserId_ShouldReturnCorrectCount()
    {
        var userId = Guid.NewGuid();
        var count = 5;
        _mockPostRepository.Setup(x => x.GetForumCountByUserId(It.IsAny<Guid>())).ReturnsAsync(count);

        var result = await _postService.GetForumCountByUserId(userId);

        Assert.That(result, Is.EqualTo(count));
    }

    /// <summary>
    ///     Tests that GetForumCountByUserId throws PostGeneralException when GeneralDatabaseException is thrown.
    /// </summary>
    [Test]
    public void GetForumCountByUserId_ShouldThrowPostGeneralException_WhenGeneralDatabaseExceptionIsThrown()
    {
        var userId = Guid.NewGuid();
        _mockPostRepository.Setup(x => x.GetForumCountByUserId(It.IsAny<Guid>()))
            .ThrowsAsync(new GeneralDatabaseException());

        Assert.ThrowsAsync<PostGeneralException>(async () => await _postService.GetForumCountByUserId(userId));
    }

    /// <summary>
    ///     Tests that GetAllPosts returns posts when posts are found.
    /// </summary>
    [Test]
    public async Task GetAllPosts_ShouldReturnPosts_WhenPostsAreFound()
    {
        var posts = new List<PostsDao> { new() { PostId = Guid.NewGuid(), Content = "Test content" } };
        _mockPostRepository.Setup(x => x.GetAllElements(It.IsAny<int>(), It.IsAny<int>())).ReturnsAsync(posts);

        var result = await _postService.GetAllPosts(1);

        Assert.That(result, Is.Not.Null);
        Assert.That(result.Count, Is.EqualTo(1));
        Assert.That(result[0].Content, Is.EqualTo("Test content"));
    }

    /// <summary>
    ///     Tests that GetAllPosts throws PostNotFoundException when DatabaseMissingItemException is thrown.
    /// </summary>
    [Test]
    public void GetAllPosts_ShouldThrowPostNotFoundException_WhenDatabaseMissingItemExceptionIsThrown()
    {
        _mockPostRepository.Setup(x => x.GetAllElements(It.IsAny<int>(), It.IsAny<int>()))
            .ThrowsAsync(new DatabaseMissingItemException());

        Assert.ThrowsAsync<PostNotFoundException>(async () => await _postService.GetAllPosts(1));
    }

    /// <summary>
    ///     Tests that GetAllPosts throws PostGeneralException when a general exception is thrown.
    /// </summary>
    [Test]
    public void GetAllPosts_ShouldThrowPostGeneralException_WhenGeneralExceptionIsThrown()
    {
        _mockPostRepository.Setup(x => x.GetAllElements(It.IsAny<int>(), It.IsAny<int>()))
            .ThrowsAsync(new GeneralDatabaseException());

        Assert.ThrowsAsync<PostGeneralException>(async () => await _postService.GetAllPosts(1));
    }

    /// <summary>
    ///     Tests that GetPostsByUserIdByForumId returns posts when posts are found.
    /// </summary>
    [Test]
    public async Task GetPostsByUserIdByForumId_ShouldReturnPosts_WhenPostsAreFound()
    {
        var userId = Guid.NewGuid();
        var forumId = Guid.NewGuid();
        var posts = new List<PostsDao>
            { new() { PostId = Guid.NewGuid(), Content = "Test content", UserId = userId, ForumId = forumId } };
        _mockPostRepository.Setup(x =>
                x.GetPostsByUserIdByForumId(It.IsAny<Guid>(), It.IsAny<Guid>(), It.IsAny<int>(), It.IsAny<int>()))
            .ReturnsAsync(posts);

        var result = await _postService.GetPostsByUserIdByForumId(userId, 1, 10, forumId);

        Assert.That(result, Is.Not.Null);
        Assert.That(result.Count, Is.EqualTo(1));
        Assert.That(result[0].Content, Is.EqualTo("Test content"));
    }

    /// <summary>
    ///     Tests that GetPostsByUserIdByForumId throws PostNotFoundException when DatabaseMissingItemException is thrown.
    /// </summary>
    [Test]
    public void GetPostsByUserIdByForumId_ShouldThrowPostNotFoundException_WhenDatabaseMissingItemExceptionIsThrown()
    {
        var userId = Guid.NewGuid();
        var forumId = Guid.NewGuid();
        _mockPostRepository.Setup(x =>
                x.GetPostsByUserIdByForumId(It.IsAny<Guid>(), It.IsAny<Guid>(), It.IsAny<int>(), It.IsAny<int>()))
            .ThrowsAsync(new DatabaseMissingItemException());

        Assert.ThrowsAsync<PostNotFoundException>(async () =>
            await _postService.GetPostsByUserIdByForumId(userId, 1, 10, forumId));
    }

    /// <summary>
    ///     Tests that GetPostsByUserIdByForumId throws PostGeneralException when GeneralDatabaseException is thrown.
    /// </summary>
    [Test]
    public void GetPostsByUserIdByForumId_ShouldThrowPostGeneralException_WhenGeneralDatabaseExceptionIsThrown()
    {
        var userId = Guid.NewGuid();
        var forumId = Guid.NewGuid();
        _mockPostRepository.Setup(x =>
                x.GetPostsByUserIdByForumId(It.IsAny<Guid>(), It.IsAny<Guid>(), It.IsAny<int>(), It.IsAny<int>()))
            .ThrowsAsync(new GeneralDatabaseException());

        Assert.ThrowsAsync<PostGeneralException>(async () =>
            await _postService.GetPostsByUserIdByForumId(userId, 1, 10, forumId));
    }

    /// <summary>
    ///     Tests that GetPostsByForumId returns posts when posts are found.
    /// </summary>
    [Test]
    public async Task GetPostsByForumId_ShouldReturnPosts_WhenPostsAreFound()
    {
        var forumId = Guid.NewGuid();
        var posts = new List<PostsDao>
            { new() { PostId = Guid.NewGuid(), Content = "Test content", ForumId = forumId } };
        _mockPostRepository.Setup(x => x.GetPostsByForumId(It.IsAny<Guid>(), It.IsAny<int>(), It.IsAny<int>()))
            .ReturnsAsync(posts);

        var result = await _postService.GetPostsByForumId(forumId, 1, 10);

        Assert.That(result, Is.Not.Null);
        Assert.That(result.Count, Is.EqualTo(1));
        Assert.That(result[0].Content, Is.EqualTo("Test content"));
    }

    /// <summary>
    ///     Tests that GetPostsByForumId throws PostNotFoundException when DatabaseMissingItemException is thrown.
    /// </summary>
    [Test]
    public void GetPostsByForumId_ShouldThrowPostNotFoundException_WhenDatabaseMissingItemExceptionIsThrown()
    {
        var forumId = Guid.NewGuid();
        _mockPostRepository.Setup(x => x.GetPostsByForumId(It.IsAny<Guid>(), It.IsAny<int>(), It.IsAny<int>()))
            .ThrowsAsync(new DatabaseMissingItemException());

        Assert.ThrowsAsync<PostNotFoundException>(async () => await _postService.GetPostsByForumId(forumId, 1, 10));
    }

    /// <summary>
    ///     Tests that GetPostsByForumId throws PostGeneralException when GeneralDatabaseException is thrown.
    /// </summary>
    [Test]
    public void GetPostsByForumId_ShouldThrowPostGeneralException_WhenGeneralDatabaseExceptionIsThrown()
    {
        var forumId = Guid.NewGuid();
        _mockPostRepository.Setup(x => x.GetPostsByForumId(It.IsAny<Guid>(), It.IsAny<int>(), It.IsAny<int>()))
            .ThrowsAsync(new GeneralDatabaseException());

        Assert.ThrowsAsync<PostGeneralException>(async () => await _postService.GetPostsByForumId(forumId, 1, 10));
    }
    
    
}