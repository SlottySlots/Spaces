using Microsoft.AspNetCore.Components;
using Moq;
using NUnit.Framework;
using SlottyMedia.Backend.Dtos;
using SlottyMedia.Backend.Services.Interfaces;
using SlottyMedia.Backend.ViewModel;
using SlottyMedia.Database.Pagination;
using Supabase.Gotrue;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace SlottyMedia.Tests.Viewmodel
{
    /// <summary>
    /// Unit tests for the PostSubmissionFormVmImpl class.
    /// </summary>
    [TestFixture]
    public class PostSubmissionFormVmImplTests
    {
        private Mock<IAuthService> _mockAuthService;
        private Mock<IForumService> _mockForumService;
        private Mock<IPostService> _mockPostService;
        private Mock<ISearchService> _mockSearchService;
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
            _mockSearchService = new Mock<ISearchService>();
            _mockNavigationManager = new Mock<NavigationManager>();
            _postSubmissionFormVmImpl = new PostSubmissionFormVmImpl(
                _mockAuthService.Object,
                _mockPostService.Object,
                _mockForumService.Object,
                _mockSearchService.Object,
                _mockNavigationManager.Object);
        }

        /// <summary>
        /// Tests that HandleSpacePromptChange updates the searched spaces when a valid prompt is provided.
        /// </summary>
        [Test]
        public async Task HandleSpacePromptChange_ValidPrompt_UpdatesSearchedSpaces()
        {
            var changeEventArgs = new ChangeEventArgs { Value = "test" };
            var forums = new List<ForumDto> { new ForumDto { Topic = "test space" } };
            var searchResults = new PageImpl<ForumDto>(forums, 1, 10, 1, null);
            _mockSearchService.Setup(s => s.SearchByForumTopicContaining("test", It.IsAny<PageRequest>())).ReturnsAsync(searchResults);

            await _postSubmissionFormVmImpl.HandleSpacePromptChange(changeEventArgs, EventCallback.Factory.Create(this, (Func<string?, Task>)(value => Task.CompletedTask)));

            Assert.That(_postSubmissionFormVmImpl.SpacePrompt, Is.EqualTo("test"));
            Assert.That(_postSubmissionFormVmImpl.SearchedSpaces, Has.Count.EqualTo(1));
            Assert.That(_postSubmissionFormVmImpl.SearchedSpaces[0], Is.EqualTo("test space"));
        }

        /// <summary>
        /// Tests that HandleSpaceSelection updates the space name when a valid space name is provided.
        /// </summary>
        [Test]
        public void HandleSpaceSelection_ValidSpaceName_UpdatesSpaceName()
        {
            _postSubmissionFormVmImpl.HandleSpaceSelection("test space");

            Assert.That(_postSubmissionFormVmImpl.SpaceName, Is.EqualTo("test space"));
            Assert.That(_postSubmissionFormVmImpl.SpacePrompt, Is.Null);
        }

        /// <summary>
        /// Tests that HandleSpaceDeselection clears the space name.
        /// </summary>
        [Test]
        public void HandleSpaceDeselection_ClearsSpaceName()
        {
            _postSubmissionFormVmImpl.SpaceName = "test space";

            _postSubmissionFormVmImpl.HandleSpaceDeselection();

            Assert.That(_postSubmissionFormVmImpl.SpaceName, Is.Null);
        }

        /// <summary>
        /// Tests that SubmitForm sets the server error message when the user is unauthenticated.
        /// </summary>
        [Test]
        public async Task SubmitForm_UnauthenticatedUser_SetsServerErrorMessage()
        {
            _mockAuthService.Setup(a => a.IsAuthenticated()).Returns(false);

            await _postSubmissionFormVmImpl.SubmitForm();

            Assert.That(_postSubmissionFormVmImpl.ServerErrorMessage, Is.EqualTo("You need to log in to submit a post"));
        }

        /// <summary>
        /// Tests that SubmitForm sets the text error message when the text is empty.
        /// </summary>
        [Test]
        public async Task SubmitForm_EmptyText_SetsTextErrorMessage()
        {
            _postSubmissionFormVmImpl.Text = null;
            _mockAuthService.Setup(a => a.IsAuthenticated()).Returns(true);

            await _postSubmissionFormVmImpl.SubmitForm();

            Assert.That(_postSubmissionFormVmImpl.TextErrorMessage, Is.EqualTo("Must provide some text in order to submit post"));
        }

        /// <summary>
        /// Tests that SubmitForm sets the space error message when the space name is empty.
        /// </summary>
        [Test]
        public async Task SubmitForm_EmptySpaceName_SetsSpaceErrorMessage()
        {
            _postSubmissionFormVmImpl.Text = "test text";
            _postSubmissionFormVmImpl.SpaceName = null;
            _mockAuthService.Setup(a => a.IsAuthenticated()).Returns(true);

            await _postSubmissionFormVmImpl.SubmitForm();

            Assert.That(_postSubmissionFormVmImpl.SpaceErrorMessage, Is.EqualTo("Must provide a space for the post"));
        }

        /// <summary>
        /// Tests that SubmitForm displays a server error message when an exception occurs.
        /// </summary>
        [Test]
        public async Task SubmitForm_DisplaysServerErrorWhenExceptionOccurs()
        {
            _postSubmissionFormVmImpl.Text = "test text";
            _postSubmissionFormVmImpl.SpaceName = "test space";
            _mockAuthService.Setup(a => a.IsAuthenticated()).Returns(true);
            _mockForumService.Setup(f => f.GetForumByName("test space")).ThrowsAsync(new Exception());

            await _postSubmissionFormVmImpl.SubmitForm();

            Assert.That(_postSubmissionFormVmImpl.ServerErrorMessage, Is.EqualTo("An unknown error occurred. Try again later."));
        }
    }
}