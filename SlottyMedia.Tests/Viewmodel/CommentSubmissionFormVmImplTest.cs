using Microsoft.AspNetCore.Components;
using Moq;
using SlottyMedia.Backend.Services.Interfaces;
using SlottyMedia.Backend.ViewModel;
using Supabase.Gotrue;

namespace SlottyMedia.Tests.Viewmodel;

/// <summary>
///     Unit tests for the CommentSubmissionFormVmImpl class.
/// </summary>
[TestFixture]
public class CommentSubmissionFormVmImplTests
{
    /// <summary>
    ///     Sets up the test environment by initializing mocks and the CommentSubmissionFormVmImpl instance.
    /// </summary>
    [SetUp]
    public void SetUp()
    {
        _mockAuthService = new Mock<IAuthService>();
        _mockCommentService = new Mock<ICommentService>();
        _mockNavigationManager = new Mock<NavigationManager>();
        _commentSubmissionFormVmImpl = new CommentSubmissionFormVmImpl(_mockAuthService.Object,
            _mockCommentService.Object, _mockNavigationManager.Object);
    }

    private Mock<IAuthService> _mockAuthService;
    private Mock<ICommentService> _mockCommentService;
    private Mock<NavigationManager> _mockNavigationManager;
    private CommentSubmissionFormVmImpl _commentSubmissionFormVmImpl;

    /// <summary>
    ///     Tests that SubmitForm method successfully submits a comment.
    /// </summary>
    [Test]
    public async Task SubmitForm_SuccessfullySubmitsComment()
    {
        var postId = Guid.NewGuid();
        var userId = Guid.NewGuid().ToString();
        _mockAuthService.Setup(s => s.IsAuthenticated()).Returns(true);
        _mockAuthService.Setup(s => s.GetCurrentSession()).Returns(new Session { User = new User { Id = userId } });
        _commentSubmissionFormVmImpl.Text = "This is a comment";

        await _commentSubmissionFormVmImpl.SubmitForm(postId);

        _mockCommentService.Verify(s => s.InsertComment(new Guid(userId), postId, "This is a comment"), Times.Once);
        _mockNavigationManager.Verify(n => n.Refresh(true), Times.Once);
        Assert.That(_commentSubmissionFormVmImpl.TextErrorMessage, Is.Null);
        Assert.That(_commentSubmissionFormVmImpl.ServerErrorMessage, Is.Null);
    }

    /// <summary>
    ///     Tests that SubmitForm method displays an error when the user is not authenticated.
    /// </summary>
    [Test]
    public async Task SubmitForm_DisplaysErrorWhenNotAuthenticated()
    {
        var postId = Guid.NewGuid();
        _mockAuthService.Setup(s => s.IsAuthenticated()).Returns(false);

        await _commentSubmissionFormVmImpl.SubmitForm(postId);

        Assert.That(_commentSubmissionFormVmImpl.ServerErrorMessage, Is.EqualTo("You need to log in to submit a post"));
        _mockCommentService.Verify(s => s.InsertComment(It.IsAny<Guid>(), It.IsAny<Guid>(), It.IsAny<string>()),
            Times.Never);
        _mockNavigationManager.Verify(n => n.Refresh(It.IsAny<bool>()), Times.Never);
    }

    /// <summary>
    ///     Tests that SubmitForm method displays an error when the comment text is empty.
    /// </summary>
    [Test]
    public async Task SubmitForm_DisplaysErrorWhenTextIsEmpty()
    {
        var postId = Guid.NewGuid();
        _mockAuthService.Setup(s => s.IsAuthenticated()).Returns(true);
        _commentSubmissionFormVmImpl.Text = string.Empty;

        await _commentSubmissionFormVmImpl.SubmitForm(postId);

        Assert.That(_commentSubmissionFormVmImpl.TextErrorMessage,
            Is.EqualTo("Must provide some text in order to submit comment"));
        _mockCommentService.Verify(s => s.InsertComment(It.IsAny<Guid>(), It.IsAny<Guid>(), It.IsAny<string>()),
            Times.Never);
        _mockNavigationManager.Verify(n => n.Refresh(It.IsAny<bool>()), Times.Never);
    }

    /// <summary>
    ///     Tests that SubmitForm method displays a server error when an exception is thrown.
    /// </summary>
    [Test]
    public async Task SubmitForm_DisplaysServerErrorOnException()
    {
        var postId = Guid.NewGuid();
        var userId = Guid.NewGuid().ToString();
        _mockAuthService.Setup(s => s.IsAuthenticated()).Returns(true);
        _mockAuthService.Setup(s => s.GetCurrentSession()).Returns(new Session { User = new User { Id = userId } });
        _commentSubmissionFormVmImpl.Text = "This is a comment";
        _mockCommentService.Setup(s => s.InsertComment(It.IsAny<Guid>(), It.IsAny<Guid>(), It.IsAny<string>()))
            .ThrowsAsync(new Exception());

        await _commentSubmissionFormVmImpl.SubmitForm(postId);

        Assert.That(_commentSubmissionFormVmImpl.ServerErrorMessage,
            Is.EqualTo("An unknown error occurred. Try again later."));
        _mockNavigationManager.Verify(n => n.Refresh(It.IsAny<bool>()), Times.Never);
    }
}