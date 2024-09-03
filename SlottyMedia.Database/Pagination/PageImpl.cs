using System.Collections;

namespace SlottyMedia.Database.Pagination;


/// <inheritdoc />
public class PageImpl<T> : IPage<T>
{
    private readonly Func<int, Task<IPage<T>>> _callback;
    
    /// <inheritdoc />
    public List<T> Content { get; }
    
    /// <inheritdoc />
    public int PageNumber { get; }
    
    /// <inheritdoc />
    public int PageSize { get; }
    
    /// <inheritdoc />
    public int TotalPages { get; }

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
}