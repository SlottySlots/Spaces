using System.Linq.Expressions;
using Moq;
using SlottyMedia.Backend.Services;
using SlottyMedia.Database;
using SlottyMedia.Database.Daos;
using Supabase.Postgrest;
using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace SlottyMedia.Tests.ServiceTests
{
    [TestFixture]
    public class PostServiceTest
    {
        private Mock<IDatabaseActions> _mockDatabaseActions;
        private PostService _postService;

        [SetUp]
        public void Setup()
        {
            _mockDatabaseActions = new Mock<IDatabaseActions>();
            _postService = new PostService(_mockDatabaseActions.Object);
        }

        [Test]
        public async Task InsertPost_ShouldReturnInsertedPost()
        {
            // Arrange
            var post = new PostsDao
            {
                Headline = "Test Title",
                Content = "Test Content",
                UserId = Guid.NewGuid(),
                ForumId = Guid.NewGuid()
            };

            _mockDatabaseActions.Setup(x => x.Insert(It.IsAny<PostsDao>())).ReturnsAsync(post);

            // Act
            var result = await _postService.InsertPost(post.Headline, post.Content, post.UserId ?? Guid.Empty,
                post.ForumId ?? Guid.Empty);

            // Assert
            Assert.That(result, Is.EqualTo(post));
        }

        [Test]
        public async Task UpdatePost_ShouldReturnUpdatedPost()
        {
            // Arrange
            var post = new PostsDao
            {
                Headline = "Updated Title",
                Content = "Updated Content",
                UserId = Guid.NewGuid(),
                ForumId = Guid.NewGuid()
            };

            _mockDatabaseActions.Setup(x => x.Update(It.IsAny<PostsDao>())).ReturnsAsync(post);

            // Act
            var result = await _postService.UpdatePost(post);

            // Assert
            Assert.That(result, Is.EqualTo(post));
        }

        [Test]
        public async Task DeletePost_ShouldReturnTrue()
        {
            // Arrange
            var post = new PostsDao
            {
                Headline = "Test Title",
                Content = "Test Content",
                UserId = Guid.NewGuid(),
                ForumId = Guid.NewGuid()
            };

            _mockDatabaseActions.Setup(x => x.Delete(It.IsAny<PostsDao>())).ReturnsAsync(true);

            // Act
            var result = await _postService.DeletePost(post);

            // Assert
            Assert.That(result, Is.True);
        }

        // [Test]
        // public async Task GetPostsFromForum_ShouldReturnListOfPostTitles()
        // {
        //     // Arrange
        //     var userId = Guid.NewGuid();
        //     var posts = new List<PostsDao>
        //     {
        //         new() { Forum = new ForumDao { ForumTopic = "Forum1" } },
        //         new() { Forum = new ForumDao { ForumTopic = "Forum2" } }
        //     };
        //
        //     _mockDatabaseActions.Setup(x => x.GetEntitiesWithSelectorById(
        //         It.IsAny<Expression<Func<PostsDao, object[]>>>(),
        //         It.IsAny<List<(string, Constants.Operator, string)>>(),
        //         It.IsAny<int>(),
        //         It.IsAny<int>(),
        //         It.IsAny<(string, Constants.Ordering, Constants.NullPosition)[]>()
        //     )).ReturnsAsync(posts);
        //
        //     // Act
        //     var result = await _postService.GetPostsFromForum(userId, 0, 2);
        //
        //     // Assert
        //     Assert.That(result.Count, Is.EqualTo(2));
        //     Assert.That(result, Does.Contain("Forum1"));
        //     Assert.That(result, Does.Contain("Forum2"));
        // }

        [Test]
        public async Task GetPostsByUserId_ShouldReturnListOfPostDtos()
        {
            // Arrange
            var userId = Guid.NewGuid();
            var posts = new List<PostsDao>
            {
                new PostsDao { PostId = Guid.NewGuid(), Content = "Content1", Forum = new ForumDao(), CreatedAt = DateTime.UtcNow },
                new PostsDao { PostId = Guid.NewGuid(), Content = "Content2", Forum = new ForumDao(), CreatedAt = DateTime.UtcNow }
            };
            _mockDatabaseActions.Setup(d => d.GetEntitiesWithSelectorById(
                It.IsAny<Expression<Func<PostsDao, object[]>>>(),
                It.IsAny<List<(string, Constants.Operator, string)>>(),
                It.IsAny<int>(),
                It.IsAny<int>(),
                It.IsAny<(string, Constants.Ordering, Constants.NullPosition)[]>()
            )).ReturnsAsync(posts);

            // Act
            var result = await _postService.GetPostsByUserId(userId, 0, 10);

            // Assert
            Assert.That(result.Count, Is.EqualTo(2));
            Assert.That(result[0].Content, Is.EqualTo("Content1"));
            Assert.That(result[1].Content, Is.EqualTo("Content2"));
        }

        [Test]
        public async Task GetPostsByUserIdByForumId_ShouldReturnListOfPostDtos()
        {
            // Arrange
            var userId = Guid.NewGuid();
            var forumId = Guid.NewGuid();
            var posts = new List<PostsDao>
            {
                new PostsDao { PostId = Guid.NewGuid(), Content = "Content1", Forum = new ForumDao(), CreatedAt = DateTime.UtcNow },
                new PostsDao { PostId = Guid.NewGuid(), Content = "Content2", Forum = new ForumDao(), CreatedAt = DateTime.UtcNow }
            };
            _mockDatabaseActions.Setup(d => d.GetEntitiesWithSelectorById(
                It.IsAny<Expression<Func<PostsDao, object[]>>>(),
                It.IsAny<List<(string, Constants.Operator, string)>>(),
                It.IsAny<int>(),
                It.IsAny<int>(),
                It.IsAny<(string, Constants.Ordering, Constants.NullPosition)[]>()
            )).ReturnsAsync(posts);

            // Act
            var result = await _postService.GetPostsByUserIdByForumId(userId, 0, 10, forumId);

            // Assert
            Assert.That(result.Count, Is.EqualTo(2));
            Assert.That(result[0].Content, Is.EqualTo("Content1"));
            Assert.That(result[1].Content, Is.EqualTo("Content2"));
        }

        [Test]
        public async Task GetPostsByForumId_ShouldReturnListOfPostDtos()
        {
            // Arrange
            var forumId = Guid.NewGuid();
            var posts = new List<PostsDao>
            {
                new PostsDao { PostId = Guid.NewGuid(), Content = "Content1", Forum = new ForumDao(), CreatedAt = DateTime.UtcNow },
                new PostsDao { PostId = Guid.NewGuid(), Content = "Content2", Forum = new ForumDao(), CreatedAt = DateTime.UtcNow }
            };
            _mockDatabaseActions.Setup(d => d.GetEntitiesWithSelectorById(
                It.IsAny<Expression<Func<PostsDao, object[]>>>(),
                It.IsAny<List<(string, Constants.Operator, string)>>(),
                It.IsAny<int>(),
                It.IsAny<int>(),
                It.IsAny<(string, Constants.Ordering, Constants.NullPosition)[]>()
            )).ReturnsAsync(posts);

            // Act
            var result = await _postService.GetPostsByForumId(forumId, 0, 10);

            // Assert
            Assert.That(result.Count, Is.EqualTo(2));
            Assert.That(result[0].Content, Is.EqualTo("Content1"));
            Assert.That(result[1].Content, Is.EqualTo("Content2"));
        }
    }
}