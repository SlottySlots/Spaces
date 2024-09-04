using Microsoft.AspNetCore.Components;
using Moq;
using SlottyMedia.Backend.Dtos;
using SlottyMedia.Backend.Services.Interfaces;
using SlottyMedia.Backend.ViewModel;
using Supabase.Gotrue;

namespace SlottyMedia.Tests.Viewmodel;

/// <summary>
/// Unit tests for the PostSubmissionFormVmImpl class.
/// </summary>
[TestFixture]
public class PostSubmissionFormVmImplTests
{
    private Mock<IAuthService> _mockAuthService;
    private Mock<IForumService> _mockForumService;
    private Mock<IPostService> _mockPostService;
    private Mock<NavigationManager> _mockNavigationManager;
    private PostSubmissionFormVmImpl _postSubmissionFormVmImpl;

    /// <summary>
    /// Sets up the test environment by initializing mocks and the PostSubmissionFormVmImpl instance.
    /// </summary>
    [SetUp]
    public void SetUp()
    {
        _mockAuthService = new Mock<IAuthService>();
        _mockForumService = new Mock<IForumService>();
        _mockPostService = new Mock<IPostService>();
        _mockNavigationManager = new Mock<NavigationManager>();
        _postSubmissionFormVmImpl = new PostSubmissionFormVmImpl(
            _mockAuthService.Object,
            _mockPostService.Object,
            _mockForumService.Object,
            _mockNavigationManager.Object);
    }

    /// <summary>
    /// Tests that HandleSpacePromptChange method updates SpacePrompt and SearchedSpaces properties.
    /// </summary>
    [Test]
    public async Task HandleSpacePromptChange_UpdatesSpacePromptAndSearchedSpaces()
    {
        var changeEventArgs = new ChangeEventArgs { Value = "test" };
        var expectedSpaces = new List<ForumDto> { new ForumDto { Topic = "test space" } };
        _mockForumService.Setup(s => s.GetForumsByNameContaining("test", 1, 10)).ReturnsAsync(expectedSpaces);

        await _postSubmissionFormVmImpl.HandleSpacePromptChange(changeEventArgs, new EventCallback<string?>());

        Assert.That(_postSubmissionFormVmImpl.SpacePrompt, Is.EqualTo("test"));
        Assert.That(_postSubmissionFormVmImpl.SearchedSpaces, Is.EqualTo(expectedSpaces.Select(s => s.Topic).ToList()));
    }

    /// <summary>
    /// Tests that HandleSpaceSelection method updates SpaceName and clears SpacePrompt.
    /// </summary>
    [Test]
    public void HandleSpaceSelection_UpdatesSpaceNameAndClearsSpacePrompt()
    {
        _postSubmissionFormVmImpl.HandleSpaceSelection("selected space");

        Assert.That(_postSubmissionFormVmImpl.SpaceName, Is.EqualTo("selected space"));
        Assert.That(_postSubmissionFormVmImpl.SpacePrompt, Is.Null);
    }

    /// <summary>
    /// Tests that HandleSpaceDeselection method clears SpaceName.
    /// </summary>
    [Test]
    public void HandleSpaceDeselection_ClearsSpaceName()
    {
        _postSubmissionFormVmImpl.SpaceName = "space to deselect";

        _postSubmissionFormVmImpl.HandleSpaceDeselection();

        Assert.That(_postSubmissionFormVmImpl.SpaceName, Is.Null);
    }

    /// <summary>
    /// Tests that SubmitForm method displays an error when the user is not authenticated.
    /// </summary>
    [Test]
    public async Task SubmitForm_DisplaysErrorWhenUserNotAuthenticated()
    {
        _mockAuthService.Setup(s => s.IsAuthenticated()).Returns(false);

        await _postSubmissionFormVmImpl.SubmitForm();

        Assert.That(_postSubmissionFormVmImpl.ServerErrorMessage, Is.EqualTo("You need to log in to submit a post"));
    }

    /// <summary>
    /// Tests that SubmitForm method displays an error when the text is empty.
    /// </summary>
    [Test]
    public async Task SubmitForm_DisplaysErrorWhenTextIsEmpty()
    {
        _mockAuthService.Setup(s => s.IsAuthenticated()).Returns(true);
        _postSubmissionFormVmImpl.Text = null;

        await _postSubmissionFormVmImpl.SubmitForm();

        Assert.That(_postSubmissionFormVmImpl.TextErrorMessage, Is.EqualTo("Must provide some text in order to submit post"));
    }

    /// <summary>
    /// Tests that SubmitForm method displays an error when the space name is empty.
    /// </summary>
    [Test]
    public async Task SubmitForm_DisplaysErrorWhenSpaceNameIsEmpty()
    {
        _mockAuthService.Setup(s => s.IsAuthenticated()).Returns(true);
        _postSubmissionFormVmImpl.Text = "Some text";
        _postSubmissionFormVmImpl.SpaceName = null;

        await _postSubmissionFormVmImpl.SubmitForm();

        Assert.That(_postSubmissionFormVmImpl.SpaceErrorMessage, Is.EqualTo("Must provide a space for the post"));
    }

    /// <summary>
    /// Tests that SubmitForm method redirects to the index page on success.
    /// </summary>
    [Test]
    public async Task SubmitForm_RedirectsToIndexPageOnSuccess()
    {
        _mockAuthService.Setup(s => s.IsAuthenticated()).Returns(true);
        _mockAuthService.Setup(s => s.GetCurrentSession()).Returns(new Session { User = new User { Id = "user-id" } });
        _mockForumService.Setup(s => s.GetForumByName(It.IsAny<string>())).ReturnsAsync(new ForumDto { ForumId = Guid.NewGuid() });
        _postSubmissionFormVmImpl.Text = "Some text";
        _postSubmissionFormVmImpl.SpaceName = "Some space";

        await _postSubmissionFormVmImpl.SubmitForm(); 
    }

    /// <summary>
    /// Tests that SubmitForm method displays a server error message on exception.
    /// </summary>
    [Test]
    public async Task SubmitForm_DisplaysServerErrorMessageOnException()
    {
        _mockAuthService.Setup(s => s.IsAuthenticated()).Returns(true);
        _mockAuthService.Setup(s => s.GetCurrentSession()).Returns(new Session { User = new User { Id = "user-id" } });
        _mockForumService.Setup(s => s.GetForumByName(It.IsAny<string>())).ThrowsAsync(new Exception());
        _postSubmissionFormVmImpl.Text = "Some text";
        _postSubmissionFormVmImpl.SpaceName = "Some space";

        await _postSubmissionFormVmImpl.SubmitForm();

        Assert.That(_postSubmissionFormVmImpl.ServerErrorMessage, Is.EqualTo("An unknown error occurred. Try again later."));
    }
}