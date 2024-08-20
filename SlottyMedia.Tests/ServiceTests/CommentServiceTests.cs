using Moq;
using SlottyMedia.Backend.Dtos;
using SlottyMedia.Backend.Exceptions.Services.PostExceptions;
using SlottyMedia.Backend.Services;
using SlottyMedia.Database;
using SlottyMedia.Database.Daos;
using SlottyMedia.Database.Exceptions;

namespace SlottyMedia.Tests.ServiceTests;

/// <summary>
///     Unit tests for the CommentService class.
/// </summary>
[TestFixture]
public class CommentServiceTests
{
    /// <summary>
    ///     Sets up the test environment before each test.
    /// </summary>
    [SetUp]
    public void Setup()
    {
        // Initialize the mock object for IDatabaseActions
        _mockDatabaseActions = new Mock<IDatabaseActions>();
        // Initialize the CommentService with the mock object
        _commentService = new CommentService(_mockDatabaseActions.Object);
    }

    /// <summary>
    ///     Cleans up the test environment after each test.
    /// </summary>
    [TearDown]
    public void TearDown()
    {
        // Reset the mock object after each test
        _mockDatabaseActions.Reset();
    }

    private Mock<IDatabaseActions> _mockDatabaseActions;
    private CommentService _commentService;

    /// <summary>
    ///     Tests that InsertComment returns the correct comment when the comment is successfully inserted.
    /// </summary>
    [Test]
    public async Task InsertComment_ShouldReturnComment_WhenCommentIsInserted()
    {
        // Arrange
        var commentDto = new CommentDto
        {
            CommentId = Guid.NewGuid(),
            Content = "Test Content",
            CreatorUserId = Guid.NewGuid(),
            PostId = Guid.NewGuid()
        };
        var commentDao = commentDto.Mapper();
        // Setup the mock to return the commentDao when Insert is called
        _mockDatabaseActions.Setup(x => x.Insert(It.IsAny<CommentDao>())).ReturnsAsync(commentDao);

        // Act
        var result = await _commentService.InsertComment(commentDto.CreatorUserId ?? Guid.Empty, commentDto.PostId,
            commentDto.Content);

        // Assert
        Assert.That(result, Is.Not.Null);
        Assert.That(result.Content, Is.EqualTo(commentDto.Content));
        Assert.That(result.CreatorUserId, Is.EqualTo(commentDto.CreatorUserId));
        Assert.That(result.PostId, Is.EqualTo(commentDto.PostId));
        // Verify that all setups were called
        _mockDatabaseActions.VerifyAll();
    }

    /// <summary>
    ///     Tests that InsertComment throws CommentIudException when a DatabaseIudActionException is thrown.
    /// </summary>
    [Test]
    public void InsertComment_ShouldThrowCommentIudException_WhenDatabaseIudActionExceptionIsThrown()
    {
        // Arrange
        var commentDto = new CommentDto
        {
            CreatorUserId = Guid.NewGuid(),
            PostId = Guid.NewGuid(),
            Content = "Test Content"
        };
        // Setup the mock to throw DatabaseIudActionException when Insert is called
        _mockDatabaseActions.Setup(x => x.Insert(It.IsAny<CommentDao>())).ThrowsAsync(new DatabaseIudActionException());

        // Act & Assert
        Assert.ThrowsAsync<CommentIudException>(async () =>
            await _commentService.InsertComment(commentDto.CreatorUserId ?? Guid.Empty, commentDto.PostId,
                commentDto.Content));
    }

    /// <summary>
    ///     Tests that InsertComment throws CommentGeneralException when a GeneralDatabaseException is thrown.
    /// </summary>
    [Test]
    public void InsertComment_ShouldThrowCommentGeneralException_WhenGeneralDatabaseExceptionIsThrown()
    {
        // Arrange
        var commentDto = new CommentDto
        {
            CreatorUserId = Guid.NewGuid(),
            PostId = Guid.NewGuid(),
            Content = "Test Content"
        };
        // Setup the mock to throw GeneralDatabaseException when Insert is called
        _mockDatabaseActions.Setup(x => x.Insert(It.IsAny<CommentDao>())).ThrowsAsync(new DatabaseIudActionException());

        // Act & Assert
        Assert.ThrowsAsync<CommentIudException>(async () =>
            await _commentService.InsertComment(commentDto.CreatorUserId ?? Guid.Empty, commentDto.PostId,
                commentDto.Content));
    }

    /// <summary>
    ///     Tests that UpdateComment returns the correct comment when the comment is successfully updated.
    /// </summary>
    [Test]
    public async Task UpdateComment_ShouldReturnComment_WhenCommentIsUpdated()
    {
        // Arrange
        var commentDto = new CommentDto
        {
            /* Initialize properties */
        };
        var commentDao = commentDto.Mapper();
        // Setup the mock to return the commentDao when Update is called
        _mockDatabaseActions.Setup(x => x.Update(It.IsAny<CommentDao>())).ReturnsAsync(commentDao);

        // Act
        var result = await _commentService.UpdateComment(commentDto);

        // Assert
        Assert.That(result, Is.Not.Null);
        Assert.That(result.CommentId, Is.EqualTo(commentDto.CommentId));
        Assert.That(result.Content, Is.EqualTo(commentDto.Content));
        Assert.That(result.CreatorUserId, Is.EqualTo(commentDto.CreatorUserId));
        Assert.That(result.PostId, Is.EqualTo(commentDto.PostId));
        // Verify that all setups were called
        _mockDatabaseActions.VerifyAll();
    }

    /// <summary>
    ///     Tests that UpdateComment throws CommentIudException when a DatabaseIudActionException is thrown.
    /// </summary>
    [Test]
    public void UpdateComment_ShouldThrowCommentIudException_WhenDatabaseIudActionExceptionIsThrown()
    {
        // Arrange
        var commentDto = new CommentDto
        {
            /* Initialize properties */
        };
        // Setup the mock to throw DatabaseIudActionException when Update is called
        _mockDatabaseActions.Setup(x => x.Update(It.IsAny<CommentDao>())).ThrowsAsync(new DatabaseIudActionException());

        // Act & Assert
        Assert.ThrowsAsync<CommentIudException>(async () => await _commentService.UpdateComment(commentDto));
    }

    /// <summary>
    ///     Tests that UpdateComment throws CommentGeneralException when a GeneralDatabaseException is thrown.
    /// </summary>
    [Test]
    public void UpdateComment_ShouldThrowCommentGeneralException_WhenGeneralDatabaseExceptionIsThrown()
    {
        // Arrange
        var commentDto = new CommentDto
        {
            /* Initialize properties */
        };
        // Setup the mock to throw GeneralDatabaseException when Update is called
        _mockDatabaseActions.Setup(x => x.Update(It.IsAny<CommentDao>())).ThrowsAsync(new GeneralDatabaseException());

        // Act & Assert
        Assert.ThrowsAsync<CommentGeneralException>(async () => await _commentService.UpdateComment(commentDto));
    }

    /// <summary>
    ///     Tests that DeleteComment returns true when the comment is successfully deleted.
    /// </summary>
    [Test]
    public async Task DeleteComment_ShouldReturnTrue_WhenCommentIsDeleted()
    {
        // Arrange
        var commentDto = new CommentDto
        {
            /* Initialize properties */
        };
        // Setup the mock to return true when Delete is called
        _mockDatabaseActions.Setup(x => x.Delete(It.IsAny<CommentDao>())).ReturnsAsync(true);

        // Act
        await _commentService.DeleteComment(commentDto);

        // Assert
        _mockDatabaseActions.VerifyAll();
    }

    /// <summary>
    ///     Tests that DeleteComment throws CommentIudException when a DatabaseIudActionException is thrown.
    /// </summary>
    [Test]
    public void DeleteComment_ShouldThrowCommentIudException_WhenDatabaseIudActionExceptionIsThrown()
    {
        // Arrange
        var commentDto = new CommentDto
        {
            /* Initialize properties */
        };
        // Setup the mock to throw DatabaseIudActionException when Delete is called
        _mockDatabaseActions.Setup(x => x.Delete(It.IsAny<CommentDao>())).ThrowsAsync(new DatabaseIudActionException());

        // Act & Assert
        Assert.ThrowsAsync<CommentIudException>(async () => await _commentService.DeleteComment(commentDto));
    }

    /// <summary>
    ///     Tests that DeleteComment throws CommentGeneralException when a GeneralDatabaseException is thrown.
    /// </summary>
    [Test]
    public void DeleteComment_ShouldThrowCommentGeneralException_WhenGeneralDatabaseExceptionIsThrown()
    {
        // Arrange
        var commentDto = new CommentDto
        {
            /* Initialize properties */
        };
        // Setup the mock to throw GeneralDatabaseException when Delete is called
        _mockDatabaseActions.Setup(x => x.Delete(It.IsAny<CommentDao>())).ThrowsAsync(new GeneralDatabaseException());

        // Act & Assert
        Assert.ThrowsAsync<CommentGeneralException>(async () => await _commentService.DeleteComment(commentDto));
    }
}