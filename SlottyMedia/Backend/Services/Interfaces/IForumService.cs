using SlottyMedia.Backend.Dtos;
using SlottyMedia.Database.Exceptions;

namespace SlottyMedia.Backend.Services.Interfaces
{
    public interface IForumService
    {
        /// <summary>
        /// Inserts a new forum into the database.
        /// </summary>
        /// <param name="forum">The ForumDto object containing the forum details.</param>
        /// <returns>Returns the inserted ForumDto object.</returns>
        /// <exception cref="GeneralDatabaseException">Throws an exception if an error occurs while inserting the forum.</exception>
        Task<ForumDto> InsertForum(ForumDto forum);

        /// <summary>
        /// Deletes a forum from the database based on the given forum ID.
        /// </summary>
        /// <param name="forum">The forum to delete.</param>
        /// <returns>Returns a Task representing the asynchronous operation.</returns>
        /// <exception cref="NotFoundException">Throws an exception if the forum is not found.</exception>
        /// <exception cref="GeneralDatabaseException">Throws an exception if an error occurs while deleting the forum.</exception>
        Task DeleteForum(ForumDto forum);
    }
}