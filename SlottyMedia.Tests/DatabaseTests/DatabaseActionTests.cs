using System.Linq.Expressions;
using SlottyMedia.Database.Daos;
using SlottyMedia.Database.Exceptions;

namespace SlottyMedia.Tests.DatabaseTests;

/// <summary>
///     Tests for DatabaseActions class.
/// </summary>
[TestFixture]
public class DatabaseActionTests : BaseDatabaseTestClass
{
    /// <summary>
    ///     Sets up the test environment by initializing the user model.
    /// </summary>
    [SetUp]
    public void Setup()
    {
        _userToWorkWith = InitializeModels.GetUserDto(UserId);
    }

    /// <summary>
    ///     Cleans up the test environment by deleting the user if it exists.
    /// </summary>
    [TearDown]
    public async Task TearDown()
    {
        try
        {
            if (_userToWorkWith.UserId is null) return;

            var user = await DatabaseActions.GetEntityByField<UserDao>("userID",
                _userToWorkWith.UserId.ToString() ?? "");
            if (user != null) await DatabaseActions.Delete(user);
        }
        catch (DatabaseMissingItemException)
        {
        }
        catch (Exception ex)
        {
            Console.WriteLine($"TearDown failed with exception: {ex.Message}");
        }
    }

    private UserDao _userToWorkWith;

    /// <summary>
    ///     Tests the Insert method of DatabaseActions.
    /// </summary>
    [Test]
    public async Task Insert()
    {
        try
        {
            var insertedUser = await DatabaseActions.Insert(_userToWorkWith);
            Assert.Multiple(() =>
            {
                Assert.That(insertedUser, Is.Not.Null, "Inserted user should not be null");
                Assert.That(insertedUser.UserId, Is.EqualTo(_userToWorkWith.UserId), "UserId should match");
                Assert.That(insertedUser.UserName, Is.EqualTo(_userToWorkWith.UserName), "UserName should match");
                Assert.That(insertedUser.Description, Is.EqualTo(_userToWorkWith.Description),
                    "Description should match");
            });
        }
        catch (GeneralDatabaseException ex)
        {
            Assert.Fail($"Insert test failed with database exception: {ex.Message}");
        }
    }

    /// <summary>
    ///     Tests the Insert method of DatabaseActions for failure.
    /// </summary>
    [Test]
    public void Insert_Failure()
    {
        var invalidUser = new UserDao(); // Create an invalid user to simulate failure
        Assert.ThrowsAsync<GeneralDatabaseException>(async () => await DatabaseActions.Insert(invalidUser));
    }

    /// <summary>
    ///     Tests the Update method of DatabaseActions.
    /// </summary>
    [Test]
    public async Task Update()
    {
        try
        {
            var insertedUser = await DatabaseActions.Insert(_userToWorkWith);
            Assert.That(insertedUser, Is.Not.Null, "Inserted user should not be null");

            insertedUser.Description = "Please don't delete me, I'm updated";
            var updatedUser = await DatabaseActions.Update(insertedUser);

            Assert.Multiple(() =>
            {
                Assert.That(updatedUser, Is.Not.Null, "Updated user should not be null");
                Assert.That(updatedUser.UserId, Is.EqualTo(insertedUser.UserId), "UserId should match");
                Assert.That(updatedUser.UserName, Is.EqualTo(insertedUser.UserName), "UserName should match");
                Assert.That(updatedUser.Description, Is.EqualTo(insertedUser.Description), "Description should match");
            });
        }
        catch (GeneralDatabaseException ex)
        {
            Assert.Fail($"Update test failed with database exception: {ex.Message}");
        }
    }

    /// <summary>
    ///     Tests the Update method of DatabaseActions for failure.
    /// </summary>
    [Test]
    public void Update_Failure()
    {
        var invalidUser = new UserDao(); // Create an invalid user to simulate failure
        Assert.ThrowsAsync<GeneralDatabaseException>(async () => await DatabaseActions.Update(invalidUser));
    }

    /// <summary>
    ///     Tests the Delete method of DatabaseActions.
    /// </summary>
    [Test]
    public async Task Delete()
    {
        try
        {
            var insertedUser = await DatabaseActions.Insert(_userToWorkWith);
            Assert.That(insertedUser, Is.Not.Null, "Inserted user should not be null");

            var deletedUser = await DatabaseActions.Delete(insertedUser);
            Assert.That(deletedUser, Is.True, "Deleted user should not be false");
        }
        catch (GeneralDatabaseException ex)
        {
            Assert.Fail($"Delete test failed with database exception: {ex.Message}");
        }
    }

    /// <summary>
    ///     Tests the Delete method of DatabaseActions for failure.
    /// </summary>
    [Test]
    public void Delete_Failure()
    {
        var invalidUser = new UserDao(); // Create an invalid user to simulate failure
        Assert.ThrowsAsync<GeneralDatabaseException>(async () => await DatabaseActions.Delete(invalidUser));
    }

    /// <summary>
    ///     Tests the GetEntityByField method of DatabaseActions.
    /// </summary>
    [Test]
    public async Task GetEntityByField()
    {
        try
        {
            var insertedUser = await DatabaseActions.Insert(_userToWorkWith);
            Assert.Multiple(() =>
            {
                Assert.That(insertedUser, Is.Not.Null, "Inserted user should not be null");
                Assert.That(insertedUser.UserId, Is.Not.Null, "Inserted user's UserId should not be null");
            });

            var user = await DatabaseActions.GetEntityByField<UserDao>("userID", insertedUser.UserId.ToString() ?? "");
            Assert.Multiple(() =>
            {
                Assert.That(user, Is.Not.Null, "Retrieved user should not be null");
                if (user != null)
                {
                    Assert.That(user.UserId, Is.EqualTo(insertedUser.UserId), "UserId should match");
                    Assert.That(user.UserName, Is.EqualTo(insertedUser.UserName), "UserName should match");
                    Assert.That(user.Description, Is.EqualTo(insertedUser.Description), "Description should match");

                    Assert.That(user.Role, Is.Not.Null, "Retrieved user should have a Role");
                    if (user.Role != null)
                    {
                        Assert.That(user.Role.RoleId, Is.Not.Null, "Retrieved user's Role should have a RoleId");
                        Assert.That(user.Role.RoleId, Is.EqualTo(_userToWorkWith.RoleId), "Role should match");
                    }
                }
            });
        }
        catch (GeneralDatabaseException ex)
        {
            Assert.Fail($"GetEntityByField test failed with database exception: {ex.Message}");
        }
    }

    /// <summary>
    ///     Tests the GetEntityByField method of DatabaseActions for failure.
    /// </summary>
    [Test]
    public void GetEntityByField_Failure()
    {
        Assert.ThrowsAsync<GeneralDatabaseException>(async () =>
            await DatabaseActions.GetEntityByField<UserDao>("userID", "invalid-id"));
    }

    /// <summary>
    ///     Tests the GetEntitieWithSelectorById method of DatabaseActions.
    /// </summary>
    [Test]
    public async Task GetEntitieWithSelectorById()
    {
        try
        {
            var insertedUser = await DatabaseActions.Insert(_userToWorkWith);
            Assert.Multiple(() =>
            {
                Assert.That(insertedUser, Is.Not.Null, "Inserted user should not be null");
                Assert.That(insertedUser.UserId, Is.Not.Null, "Inserted user's UserId should not be null");
            });

            Expression<Func<UserDao, object[]>> selector = u => new object[] { u.UserId!, u.UserName!, u.Description! };
            var user = await DatabaseActions.GetEntitieWithSelectorById(selector, "userID",
                insertedUser.UserId.ToString() ?? "");
            Assert.Multiple(() =>
            {
                Assert.That(user, Is.Not.Null, "Retrieved user should not be null");

                Assert.That(user.UserId, Is.EqualTo(insertedUser.UserId), "UserId should match");
                Assert.That(user.UserName, Is.EqualTo(insertedUser.UserName), "UserName should match");
                Assert.That(user.Description, Is.EqualTo(insertedUser.Description), "Description should match");

                // Check that fields not included in the selector are not returned
                Assert.That(user.RoleId, Is.Null, "Retrieved user should not have a RoleId");
                Assert.That(user.CreatedAt, Is.Default, "Retrieved user should not have a CreatedAt");
                Assert.That(user.ProfilePic, Is.Null, "Retrieved user should not have a ProfilePicture");
            });
        }
        catch (GeneralDatabaseException ex)
        {
            Assert.Fail($"GetEntitieWithSelectorById test failed with database exception: {ex.Message}");
        }
    }

    /// <summary>
    ///     Tests the GetEntitieWithSelectorById method of DatabaseActions for failure.
    /// </summary>
    [Test]
    public void GetEntitieWithSelectorById_Failure()
    {
        Expression<Func<UserDao, object[]>> selector = u => new object[] { u.UserId!, u.UserName!, u.Description! };
        Assert.ThrowsAsync<GeneralDatabaseException>(async () =>
            await DatabaseActions.GetEntitieWithSelectorById(selector, "userID", "invalid-id"));
    }

    /// <summary>
    ///     Tests the GetEntitiesWithSelectorById method of DatabaseActions.
    /// </summary>
    [Test]
    public async Task GetEntitiesWithSelectorById()
    {
        try
        {
            var insertedUser = await DatabaseActions.Insert(_userToWorkWith);
            Assert.Multiple(() =>
            {
                Assert.That(insertedUser, Is.Not.Null, "Inserted user should not be null");
                Assert.That(insertedUser.UserId, Is.Not.Null, "Inserted user's UserId should not be null");
            });

            Expression<Func<UserDao, object[]>> selector = u => new object[] { u.UserId!, u.UserName!, u.Description! };
            var users = await DatabaseActions.GetEntitiesWithSelectorById(selector, "userID",
                insertedUser.UserId.ToString() ?? "");
            Assert.Multiple(() =>
            {
                Assert.That(users, Is.Not.Null, "Retrieved users list should not be null");
                Assert.That(users.Count, Is.GreaterThan(0), "Retrieved users list should contain at least one user");

                foreach (var user in users)
                {
                    Assert.That(user, Is.Not.Null, "Retrieved user should not be null");

                    Assert.That(user.UserId, Is.EqualTo(insertedUser.UserId), "UserId should match");
                    Assert.That(user.UserName, Is.EqualTo(insertedUser.UserName), "UserName should match");
                    Assert.That(user.Description, Is.EqualTo(insertedUser.Description), "Description should match");

                    // Check that fields not included in the selector are not returned
                    Assert.That(user.RoleId, Is.Null, "Retrieved user should not have a RoleId");
                    Assert.That(user.CreatedAt, Is.Default, "Retrieved user should not have a CreatedAt");
                    Assert.That(user.ProfilePic, Is.Null, "Retrieved user should not have a ProfilePicture");
                }
            });
        }
        catch (GeneralDatabaseException ex)
        {
            Assert.Fail($"GetEntitiesWithSelectorById test failed with database exception: {ex.Message}");
        }
    }

    /// <summary>
    ///     Tests the GetEntitiesWithSelectorById method of DatabaseActions for failure.
    /// </summary>
    [Test]
    public void GetEntitiesWithSelectorById_Failure()
    {
        Expression<Func<UserDao, object[]>> selector = u => new object[] { u.UserId!, u.UserName!, u.Description! };
        Assert.ThrowsAsync<GeneralDatabaseException>(async () =>
            await DatabaseActions.GetEntitiesWithSelectorById(selector, "userID", "invalid-id"));
    }

    /// <summary>
    ///     Tests the GetCountByField method of DatabaseActions.
    /// </summary>
    /// <remarks>
    ///     This test ensures that the GetCountByField method correctly returns the count of users
    ///     with a specific field and value. It first inserts a user into the database to ensure
    ///     there is at least one entry, then retrieves the count of users with the specific field
    ///     and value, and asserts that the count is greater than 0.
    /// </remarks>
    /// <exception cref="GeneralDatabaseException">
    ///     Thrown when there is a database-related error during the test execution.
    /// </exception>
    [Test]
    public async Task GetCountByField()
    {
        try
        {
            // Insert a user to ensure there is at least one entry in the database
            var insertedUser = await DatabaseActions.Insert(_userToWorkWith);
            Assert.That(insertedUser, Is.Not.Null, "Inserted user should not be null");

            // Get the count of users with the specific field and value
            var count = await DatabaseActions.GetCountByField<UserDao>("userID", insertedUser.UserId.ToString() ?? "");
            Assert.That(count, Is.GreaterThan(0), "Count should be greater than 0");
        }
        catch (GeneralDatabaseException ex)
        {
            Assert.Fail($"GetCountByField test failed with database exception: {ex.Message}");
        }
    }
}