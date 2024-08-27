using System.Linq.Expressions;
using Moq;
using SlottyMedia.Backend.Exceptions.Services.PostExceptions;
using SlottyMedia.Backend.Services;
using SlottyMedia.Database.Daos;
using SlottyMedia.Database.Exceptions;
using SlottyMedia.Database.Repository.PostRepo;
using Supabase.Postgrest;

namespace SlottyMedia.Tests.ServiceTests;

/// <summary>
///     Unit tests for the PostService class.
/// </summary>
[TestFixture]
public class PostServiceTests
{
    private Mock<IPostRepository> _mockPostRepository;
    private PostService _postService;

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

    [Test]
    public async Task InsertPost_ShouldReturnTrue_WhenPostIsInsertedSuccessfully()
    {
        var post = new PostsDao { PostId = Guid.NewGuid(), Content = "Test content" };
        _mockPostRepository.Setup(x => x.AddElement(It.IsAny<PostsDao>())).Returns(Task.CompletedTask);

        await _postService.InsertPost(post.Content, post.UserId ?? Guid.NewGuid(), Guid.NewGuid());

        _mockPostRepository.Verify(x => x.AddElement(It.IsAny<PostsDao>()), Times.Once);
    }

    [Test]
    public void InsertPost_ShouldThrowPostIudException_WhenDatabaseIudActionExceptionIsThrown()
    {
        var post = new PostsDao { PostId = Guid.NewGuid(), Content = "Test content" };
        _mockPostRepository.Setup(x => x.AddElement(It.IsAny<PostsDao>()))
            .ThrowsAsync(new DatabaseIudActionException());

        Assert.ThrowsAsync<PostIudException>(async () => await _postService.InsertPost(post.Content, post.UserId ?? Guid.NewGuid(), Guid.NewGuid()));
    }

    [Test]
    public void InsertPost_ShouldThrowPostGeneralException_WhenGeneralDatabaseExceptionIsThrown()
    {
        var post = new PostsDao { PostId = Guid.NewGuid(), Content = "Test content" };
        _mockPostRepository.Setup(x => x.AddElement(It.IsAny<PostsDao>()))
            .ThrowsAsync(new GeneralDatabaseException());

        Assert.ThrowsAsync<PostGeneralException>(async () => await _postService.InsertPost(post.Content, post.UserId ?? Guid.NewGuid(), Guid.NewGuid()));
    }

    [Test]
    public async Task DeletePost_ShouldReturnTrue_WhenPostIsDeletedSuccessfully()
    {
        var post = new PostsDao { PostId = Guid.NewGuid(), Content = "Test content" };
        _mockPostRepository.Setup(x => x.DeleteElement(It.IsAny<PostsDao>())).Returns(Task.CompletedTask);

        await _postService.DeletePost(post);
        
        _mockPostRepository.Verify(x => x.DeleteElement(It.IsAny<PostsDao>()), Times.Once);
    }

    [Test]
    public void DeletePost_ShouldThrowPostIudException_WhenDatabaseIudActionExceptionIsThrown()
    {
        var post = new PostsDao { PostId = Guid.NewGuid(), Content = "Test content" };
        _mockPostRepository.Setup(x => x.DeleteElement(It.IsAny<PostsDao>()))
            .ThrowsAsync(new DatabaseIudActionException());

        Assert.ThrowsAsync<PostIudException>(async () => await _postService.DeletePost(post));
    }

    [Test]
    public void DeletePost_ShouldThrowPostGeneralException_WhenGeneralDatabaseExceptionIsThrown()
    {
        var post = new PostsDao { PostId = Guid.NewGuid(), Content = "Test content" };
        _mockPostRepository.Setup(x => x.DeleteElement(It.IsAny<PostsDao>()))
            .ThrowsAsync(new GeneralDatabaseException());

        Assert.ThrowsAsync<PostGeneralException>(async () => await _postService.DeletePost(post));
    }

    [Test]
    public async Task GetPostsForUser_ShouldReturnPosts_WhenPostsAreFound()
    {
        var userId = Guid.NewGuid();
        var posts = new List<PostsDao> { new() { PostId = Guid.NewGuid(), Content = "Test content", UserId = userId } };
        _mockPostRepository.Setup(x => x.GetPostsByUserId(It.IsAny<Guid>(), It.IsAny<int>(), It.IsAny<int>())).ReturnsAsync(posts);

        var result = await _postService.GetPostsByUserId(userId, 1, 10);

        Assert.That(result, Is.Not.Null);
        Assert.That(result.Count, Is.EqualTo(1));
        Assert.That(result[0].Content, Is.EqualTo("Test content"));
    }

    [Test]
    public void GetPostsForUser_ShouldThrowPostNotFoundException_WhenDatabaseMissingItemExceptionIsThrown()
    {
        var userId = Guid.NewGuid();
        _mockPostRepository.Setup(x => x.GetPostsByUserId(It.IsAny<Guid>(), It.IsAny<int>(), It.IsAny<int>()))
            .ThrowsAsync(new DatabaseMissingItemException());

        Assert.ThrowsAsync<PostNotFoundException>(async () => await _postService.GetPostsByUserId(userId, 1, 10));
    }

    [Test]
    public void GetPostsForUser_ShouldThrowPostGeneralException_WhenGeneralDatabaseExceptionIsThrown()
    {
        var userId = Guid.NewGuid();
        _mockPostRepository.Setup(x => x.GetPostsByUserId(It.IsAny<Guid>(), It.IsAny<int>(), It.IsAny<int>()))
            .ThrowsAsync(new GeneralDatabaseException());

        Assert.ThrowsAsync<PostGeneralException>(async () => await _postService.GetPostsByUserId(userId, 1, 10));
    }
}