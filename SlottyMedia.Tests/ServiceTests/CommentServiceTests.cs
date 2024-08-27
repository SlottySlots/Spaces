using Moq;
using NUnit.Framework;
using SlottyMedia.Backend.Exceptions.Services.CommentExceptions;
using SlottyMedia.Backend.Services;
using SlottyMedia.Database.Daos;
using SlottyMedia.Database.Exceptions;
using SlottyMedia.Database.Repository.CommentRepo;
using System;
using System.Threading.Tasks;

namespace SlottyMedia.Tests.ServiceTests
{
    /// <summary>
    /// Unit tests for the CommentService class.
    /// </summary>
    [TestFixture]
    public class CommentServiceTests
    {
        private Mock<ICommentRepository> _mockICommentRepository;
        private CommentService _commentService;

        /// <summary>
        /// Initializes the mock objects and the CommentService instance before each test.
        /// </summary>
        [SetUp]
        public void Setup()
        {
            _mockICommentRepository = new Mock<ICommentRepository>();
            _commentService = new CommentService(_mockICommentRepository.Object);
        }

        /// <summary>
        /// Resets the mock objects after each test.
        /// </summary>
        [TearDown]
        public void TearDown()
        {
            _mockICommentRepository.Reset();
        }

        /// <summary>
        /// Tests that InsertComment method inserts a comment when the comment is valid.
        /// </summary>
        [Test]
        public async Task InsertComment_ShouldInsertComment_WhenCommentIsValid()
        {
            var creatorUserId = Guid.NewGuid();
            var postId = Guid.NewGuid();
            var content = "Test Content";

            _mockICommentRepository.Setup(x => x.AddElement(It.IsAny<CommentDao>())).Returns(Task.CompletedTask);

            await _commentService.InsertComment(creatorUserId, postId, content);

            _mockICommentRepository.Verify(x => x.AddElement(It.IsAny<CommentDao>()), Times.Once);
        }

        /// <summary>
        /// Tests that InsertComment method throws CommentIudException when DatabaseIudActionException is thrown.
        /// </summary>
        [Test]
        public void InsertComment_ShouldThrowCommentIudException_WhenDatabaseIudActionExceptionIsThrown()
        {
            var creatorUserId = Guid.NewGuid();
            var postId = Guid.NewGuid();
            var content = "Test Content";

            _mockICommentRepository.Setup(x => x.AddElement(It.IsAny<CommentDao>())).ThrowsAsync(new DatabaseIudActionException());

            Assert.ThrowsAsync<CommentIudException>(async () => await _commentService.InsertComment(creatorUserId, postId, content));
        }

        /// <summary>
        /// Tests that InsertComment method throws CommentGeneralException when GeneralDatabaseException is thrown.
        /// </summary>
        [Test]
        public void InsertComment_ShouldThrowCommentGeneralException_WhenGeneralDatabaseExceptionIsThrown()
        {
            var creatorUserId = Guid.NewGuid();
            var postId = Guid.NewGuid();
            var content = "Test Content";

            _mockICommentRepository.Setup(x => x.AddElement(It.IsAny<CommentDao>())).ThrowsAsync(new GeneralDatabaseException());

            Assert.ThrowsAsync<CommentGeneralException>(async () => await _commentService.InsertComment(creatorUserId, postId, content));
        }

        /// <summary>
        /// Tests that UpdateComment method updates a comment when the comment is valid.
        /// </summary>
        [Test]
        public async Task UpdateComment_ShouldUpdateComment_WhenCommentIsValid()
        {
            var comment = new CommentDao { CommentId = Guid.NewGuid(), Content = "Updated Content" };

            _mockICommentRepository.Setup(x => x.UpdateElement(It.IsAny<CommentDao>())).Returns(Task.CompletedTask);

            await _commentService.UpdateComment(comment);

            _mockICommentRepository.Verify(x => x.UpdateElement(It.IsAny<CommentDao>()), Times.Once);
        }

        /// <summary>
        /// Tests that UpdateComment method throws CommentIudException when DatabaseIudActionException is thrown.
        /// </summary>
        [Test]
        public void UpdateComment_ShouldThrowCommentIudException_WhenDatabaseIudActionExceptionIsThrown()
        {
            var comment = new CommentDao { CommentId = Guid.NewGuid(), Content = "Updated Content" };

            _mockICommentRepository.Setup(x => x.UpdateElement(It.IsAny<CommentDao>())).ThrowsAsync(new DatabaseIudActionException());

            Assert.ThrowsAsync<CommentIudException>(async () => await _commentService.UpdateComment(comment));
        }

        /// <summary>
        /// Tests that UpdateComment method throws CommentGeneralException when GeneralDatabaseException is thrown.
        /// </summary>
        [Test]
        public void UpdateComment_ShouldThrowCommentGeneralException_WhenGeneralDatabaseExceptionIsThrown()
        {
            var comment = new CommentDao { CommentId = Guid.NewGuid(), Content = "Updated Content" };

            _mockICommentRepository.Setup(x => x.UpdateElement(It.IsAny<CommentDao>())).ThrowsAsync(new GeneralDatabaseException());

            Assert.ThrowsAsync<CommentGeneralException>(async () => await _commentService.UpdateComment(comment));
        }

        /// <summary>
        /// Tests that DeleteComment method deletes a comment when the comment is valid.
        /// </summary>
        [Test]
        public async Task DeleteComment_ShouldDeleteComment_WhenCommentIsValid()
        {
            var comment = new CommentDao { CommentId = Guid.NewGuid(), Content = "Test Content" };

            _mockICommentRepository.Setup(x => x.DeleteElement(It.IsAny<CommentDao>())).Returns(Task.CompletedTask);

            await _commentService.DeleteComment(comment);

            _mockICommentRepository.Verify(x => x.DeleteElement(It.IsAny<CommentDao>()), Times.Once);
        }

        /// <summary>
        /// Tests that DeleteComment method throws CommentIudException when DatabaseIudActionException is thrown.
        /// </summary>
        [Test]
        public void DeleteComment_ShouldThrowCommentIudException_WhenDatabaseIudActionExceptionIsThrown()
        {
            var comment = new CommentDao { CommentId = Guid.NewGuid(), Content = "Test Content" };

            _mockICommentRepository.Setup(x => x.DeleteElement(It.IsAny<CommentDao>())).ThrowsAsync(new DatabaseIudActionException());

            Assert.ThrowsAsync<CommentIudException>(async () => await _commentService.DeleteComment(comment));
        }

        /// <summary>
        /// Tests that DeleteComment method throws CommentGeneralException when GeneralDatabaseException is thrown.
        /// </summary>
        [Test]
        public void DeleteComment_ShouldThrowCommentGeneralException_WhenGeneralDatabaseExceptionIsThrown()
        {
            var comment = new CommentDao { CommentId = Guid.NewGuid(), Content = "Test Content" };

            _mockICommentRepository.Setup(x => x.DeleteElement(It.IsAny<CommentDao>())).ThrowsAsync(new GeneralDatabaseException());

            Assert.ThrowsAsync<CommentGeneralException>(async () => await _commentService.DeleteComment(comment));
        }
    }
}