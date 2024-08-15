using SlottyMedia.Backend.Dtos;
using SlottyMedia.Backend.Exceptions.Services.PostExceptions;
using SlottyMedia.Backend.Services.Interfaces;
using SlottyMedia.Database;
using SlottyMedia.Database.Daos;
using SlottyMedia.Database.Exceptions;

namespace SlottyMedia.Backend.Services
{
    /// <summary>
    /// The ForumService class is responsible for handling forum related operations.
    /// </summary>
    public class ForumService : IForumService
    {
        private readonly IDatabaseActions _databaseActions;

        // Constructor to initialize the ForumService with the required database actions.
        public ForumService(IDatabaseActions databaseActions)
        {
            _databaseActions = databaseActions;
        }

        /// <summary>
        ///     Inserts a new forum into the database.
        /// </summary>
        /// <param name="forum">The ForumDto object containing the forum details.</param>
        /// <returns>Returns the inserted ForumDto object.</returns>
        /// <exception cref="GeneralDatabaseException">Throws an exception if an error occurs while inserting the forum.</exception>
        public async Task<ForumDto> InsertForum(ForumDto forum)
        {
            try
            {
                // Attempt to insert the forum into the database.
                var insertedForum = await _databaseActions.Insert(forum.Mapper());
                // Return the inserted forum as a ForumDto object.
                return new ForumDto().Mapper(insertedForum);
            }
            catch (DatabaseIudActionException ex)
            {
                // Handle specific database insert/update/delete action exceptions.
                throw new ForumIudException("An error occurred while inserting the forum", ex);
            }
            catch (GeneralDatabaseException ex)
            {
                // Handle general database exceptions.
                throw new ForumGeneralException("An error occurred while inserting the forum", ex);
            }
            catch (Exception ex)
            {
                // Handle any other exceptions.
                throw new ForumGeneralException("An error occurred while inserting the forum", ex);
            }
        }

        /// <summary>
        ///     Deletes a forum from the database based on the given forum ID.
        /// </summary>
        /// <param name="forum">The the forum to delete.</param>
        /// <returns>Returns a Task representing the asynchronous operation.</returns>
        /// <exception cref="NotFoundException">Throws an exception if the forum is not found.</exception>
        /// <exception cref="GeneralDatabaseException">Throws an exception if an error occurs while deleting the forum.</exception>
        public async Task DeleteForum(ForumDto forum)
        {
            try
            {
                // Attempt to delete the forum from the database.
                await _databaseActions.Delete<ForumDao>(forum.Mapper());
            }
            catch (DatabaseIudActionException ex)
            {
                // Handle specific database insert/update/delete action exceptions.
                throw new ForumIudException("An error occurred while deleting the forum", ex);
            }
            catch (GeneralDatabaseException ex)
            {
                // Handle general database exceptions.
                throw new ForumGeneralException("An error occurred while deleting the forum", ex);
            }
            catch (Exception ex)
            {
                // Handle any other exceptions.
                throw new ForumGeneralException("An error occurred while deleting the forum", ex);
            }
        }
    }
}