using SlottyMedia.Database.Daos;

namespace SlottyMedia.Database.Repository.RoleRepo;

/// <summary>
/// Interface for Role Repository, extending the IDatabaseRepository for RoleDao.
/// </summary>
public interface IRoleRepository : IDatabaseRepository<RoleDao>
{
    /// <summary>
    /// Retrieves the role ID by the role name.
    /// </summary>
    /// <param name="roleName">The name of the role.</param>
    /// <returns>A task that represents the asynchronous operation. The task result contains the role ID.</returns>
    public Task<Guid> GetRoleIdByName(string roleName);

    /// <summary>
    /// Adds a new RoleDao element to the repository.
    /// </summary>
    /// <param name="element">The RoleDao element to add.</param>
    /// <returns>A task that represents the asynchronous operation. The task result contains the added RoleDao element.</returns>
    public new Task<RoleDao> AddElement(RoleDao element) => throw new NotImplementedException();

    /// <summary>
    /// Updates an existing RoleDao element in the repository.
    /// </summary>
    /// <param name="element">The RoleDao element to update.</param>
    /// <returns>A task that represents the asynchronous operation.</returns>
    public new Task UpdateElement(RoleDao element) => throw new NotImplementedException();

    /// <summary>
    /// Deletes a RoleDao entity from the repository.
    /// </summary>
    /// <param name="entity">The RoleDao entity to delete.</param>
    /// <returns>A task that represents the asynchronous operation.</returns>
    public new Task DeleteElement(RoleDao entity) => throw new NotImplementedException();
}