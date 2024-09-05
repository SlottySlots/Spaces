using SlottyMedia.Backend.Dtos;
using SlottyMedia.Backend.Exceptions.Services.SearchExceptions;

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
    /// <returns>
    ///     SearchDto
    /// </returns>
    /// <exception cref="SearchGeneralExceptions">Thrown when a general error occurs during the search.</exception>
    Task<SearchDto> SearchByUsername(string searchTerm);

    /// <summary>
    ///     Search function to retrieve forums by topic.
    /// </summary>
    /// <param name="searchTerm">
    ///     Search Term used for wildcard search
    /// </param>
    /// <returns>
    ///     SearchDto
    /// </returns>
    /// <exception cref="SearchGeneralExceptions">Thrown when a general error occurs during the search.</exception>
    Task<SearchDto> SearchByTopic(string searchTerm);
}