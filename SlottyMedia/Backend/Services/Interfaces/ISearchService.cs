using SlottyMedia.Backend.Dtos;
using SlottyMedia.Backend.Exceptions.Services.SearchExceptions;
using SlottyMedia.Database.Daos;
using SlottyMedia.Database.Pagination;

namespace SlottyMedia.Backend.Services.Interfaces;

/// <summary>
///     This interface is used to define the Search Service.
/// </summary>
public interface ISearchService
{
    /// <summary>
    ///     Search function to retrieve all users for a specific search term.
    /// </summary>
    /// <param name="searchTerm">
    ///     Search Term used for wildcard selection
    /// </param>
    /// <param name="pageRequest">The page request</param>
    /// <returns>
    ///     SearchDto
    /// </returns>
    /// <exception cref="SearchGeneralExceptions">Thrown when a general error occurs during the search.</exception>
    Task<IPage<UserDto>> SearchByUsernameContaining(string searchTerm, PageRequest pageRequest);

    /// <summary>
    ///     Search function to retrieve forums by topic.
    /// </summary>
    /// <param name="searchTerm">
    ///     Search Term used for wildcard search
    /// </param>
    /// <param name="pageRequest">The page request</param>
    /// <returns>
    ///     SearchDto
    /// </returns>
    /// <exception cref="SearchGeneralExceptions">Thrown when a general error occurs during the search.</exception>
    Task<IPage<ForumDto>> SearchByForumTopicContaining(string searchTerm, PageRequest pageRequest);
}