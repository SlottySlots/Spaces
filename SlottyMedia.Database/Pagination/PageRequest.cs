namespace SlottyMedia.Database.Pagination;

/// <summary>
///     This class represents a request for a <see cref="IPage{T}" />. It specifies
///     the page's size and the current page number. The page is then intended to be
///     fetched server-side using this object.
/// </summary>
public class PageRequest
{
    /// <summary>
    ///     The number of the page to request
    /// </summary>
    public readonly int PageNumber;

    /// <summary>
    ///     Each page's size
    /// </summary>
    public readonly int PageSize;

    private PageRequest(int pageNumber, int pageSize)
    {
        PageNumber = pageNumber;
        PageSize = pageSize;
    }

    /// <summary>
    ///     Builds a request consisting of the page's number and size.
    /// </summary>
    /// <param name="pageNumber">The page's number</param>
    /// <param name="pageSize">The page's size</param>
    /// <returns>The corresponding request</returns>
    public static PageRequest Of(int pageNumber, int pageSize)
    {
        return new PageRequest(pageNumber, pageSize);
    }

    /// <summary>
    ///     Builds a request consisting of the page's size.
    /// </summary>
    /// <param name="pageSize">The page's size</param>
    /// <returns>The corresponding request</returns>
    public static PageRequest OfSize(int pageSize)
    {
        return Of(0, pageSize);
    }

    /// <summary>
    ///     Build a request equivalent to the first page.
    /// </summary>
    /// <returns>The corresponding request</returns>
    public PageRequest First()
    {
        return new PageRequest(0, PageSize);
    }

    /// <summary>
    ///     Build a request equivalent to the next page.
    /// </summary>
    /// <returns>The corresponding request</returns>
    public PageRequest Next()
    {
        return new PageRequest(PageNumber + 1, PageSize);
    }

    /// <summary>
    ///     Build a request equivalent to the previous page.
    ///     Returns this object instead if there is no previous page.
    /// </summary>
    /// <returns>The corresponding request</returns>
    public PageRequest Previous()
    {
        return PageNumber == 0 ? this : new PageRequest(PageNumber - 1, PageSize);
    }
}