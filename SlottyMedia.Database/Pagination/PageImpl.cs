using System.Collections;

namespace SlottyMedia.Database.Pagination;

/// <inheritdoc />
public class PageImpl<T> : IPage<T>
{
    private readonly Func<int, Task<IPage<T>>> _callback;

    /// <summary>
    ///     Creates a page.
    /// </summary>
    /// <param name="content">The page's content</param>
    /// <param name="pageNumber">The number of this page</param>
    /// <param name="pageSize">The size of each page</param>
    /// <param name="totalPages">The number of total pages</param>
    /// <param name="callback">A calback that is used to fetch a page with a specific number</param>
    public PageImpl(List<T> content, int pageNumber, int pageSize, int totalPages, Func<int, Task<IPage<T>>> callback)
    {
        Content = content;
        PageNumber = pageNumber;
        PageSize = pageSize;
        TotalPages = totalPages;
        _callback = callback;
    }

    /// <summary>Used to build an empty page</summary>
    private PageImpl(List<T> content, int pageNumber, int pageSize, int totalPages)
    {
        Content = content;
        PageNumber = pageNumber;
        PageSize = pageSize;
        TotalPages = totalPages;
        // this should never be used!
        _callback = _ => throw new InvalidOperationException("Cannot invoke fetch on the empty page!");
    }

    /// <inheritdoc />
    public List<T> Content { get; }

    /// <inheritdoc />
    public int PageNumber { get; }

    /// <inheritdoc />
    public int PageSize { get; }

    /// <inheritdoc />
    public int TotalPages { get; }

    /// <inheritdoc />
    public IPage<TMapped> Map<TMapped>(Func<T, TMapped> function)
    {
        var newContent = Content.Select(function).ToList();
        return new PageImpl<TMapped>(
            newContent,
            PageNumber,
            PageSize,
            TotalPages,
            async n => (await Fetch(n)).Map(function));
    }

    /// <inheritdoc />
    public Task<IPage<T>> Fetch(int pageNumber)
    {
        return _callback(pageNumber);
    }

    IEnumerator IEnumerable.GetEnumerator()
    {
        return Content.GetEnumerator();
    }

    /// <inheritdoc />
    public IEnumerator<T> GetEnumerator()
    {
        return Content.GetEnumerator();
    }

    /// <summary>
    ///     Builds an empty page with no content. Throws an <see cref="InvalidOperationException" /> when
    ///     attempting to fetch another page.
    /// </summary>
    /// <returns>The empty page</returns>
    public static IPage<T> Empty()
    {
        return new PageImpl<T>([], 0, 0, 0);
    }
}