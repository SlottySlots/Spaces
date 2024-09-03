namespace SlottyMedia.Database.Pagination;


/// <summary>
///     This class represents a paginated list.
/// </summary>
/// <typeparam name="T">The type of the page's elements</typeparam>
public interface IPage<T> : IEnumerable<T>
{
    /// <summary>
    ///     The number of this page. This number is always between
    ///     <c>0</c> (inclusive) and <see cref="TotalPages"/> (exclusive).
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
    bool HasNext { get; }
    
    /// <summary>
    ///     Whether there is a page that comes before this page.
    /// </summary>
    bool HasPrevious { get; }
    
    /// <summary>
    ///     This page's elements as a list.
    /// </summary>
    List<T> Content { get; }
}