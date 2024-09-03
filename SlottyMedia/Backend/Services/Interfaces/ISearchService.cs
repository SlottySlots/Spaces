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
    /// <param name="page">
    ///     Current page retrieved (interval times page)
    /// </param>
    /// <param name="pagesize">
    ///     Size of interval
    /// </param>
    /// <returns>
    ///     SearchDto
    /// </returns>
    /// <exception cref="SearchGeneralExceptions">Thrown when a general error occurs during the search.</exception>
    Task<SearchDto> SearchByUsername(string searchTerm, int page, int pagesize);

    /// <summary>
    ///     Search function to retrieve forums by topic.
    /// </summary>
    /// <param name="searchTerm">
    ///     Search Term used for wildcard search
    /// </param>
    /// <param name="page">
    ///     Current page retrieved (interval times page)
    /// </param>
    /// <param name="pagesize">
    ///     Size of interval
    /// </param>
    /// <returns>
    ///     SearchDto
    /// </returns>
    /// <exception cref="SearchGeneralExceptions">Thrown when a general error occurs during the search.</exception>
    Task<SearchDto> SearchByTopic(string searchTerm, int page, int pagesize);
}