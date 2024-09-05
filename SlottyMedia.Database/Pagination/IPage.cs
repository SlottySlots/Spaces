namespace SlottyMedia.Database.Pagination;

/// <summary>
///     This class represents a paginated list.
/// </summary>
/// <typeparam name="T">The type of the page's elements</typeparam>
public interface IPage<T> : IEnumerable<T>
{
    /// <summary>
    ///     The number of this page. This number is always between
    ///     <c>0</c> (inclusive) and <see cref="TotalPages" /> (exclusive).
    ///     This number is always <c>0</c> when no pages are available.
    /// </summary>
    int PageNumber { get; }

    /// <summary>
    ///     The size of each page.
    /// </summary>
    int PageSize { get; }

    /// <summary>
    ///     The total number of pages. This number is at least <c>0</c>.
    /// </summary>
    int TotalPages { get; }

    /// <summary>
    ///     Whether there is a page that comes after this page.
    /// </summary>
    bool HasNext => PageNumber < TotalPages - 1;

    /// <summary>
    ///     Whether there is a page that comes before this page.
    /// </summary>
    bool HasPrevious => PageNumber > 0;

    /// <summary>
    ///     This page's elements as a list.
    /// </summary>
    List<T> Content { get; }

    /// <summary>
    ///     Maps the content of this page using the supplied function.
    /// </summary>
    /// <param name="function">The function that maps all contents of this page</param>
    /// <typeparam name="TMapped">The type of the resulting page's contents</typeparam>
    /// <returns>The mapped page</returns>
    IPage<TMapped> Map<TMapped>(Func<T, TMapped> function);

    /// <summary>
    ///     Fetches a matching page with the specified page number.
    /// </summary>
    /// <param name="pageNumber">The number of the page to fetch</param>
    /// <returns>The requested page</returns>
    Task<IPage<T>> Fetch(int pageNumber);

    /// <summary>
    ///     Fetches the next page. Returns this page instead if no such page exists.
    ///     Consider checking <see cref="HasNext" /> before invoking this method.
    /// </summary>
    /// <returns>The next page</returns>
    async Task<IPage<T>> FetchNext()
    {
        if (HasNext)
            return await Fetch(PageNumber + 1);
        return this;
    }

    /// <summary>
    ///     Fetches the previous page. Returns this page instead if no such page exists.
    ///     Consider checking <see cref="HasPrevious" /> before invoking this method.
    /// </summary>
    /// <returns>The previous page</returns>
    async Task<IPage<T>> FetchPrevious()
    {
        if (HasPrevious)
            return await Fetch(PageNumber - 1);
        return this;
    }
}