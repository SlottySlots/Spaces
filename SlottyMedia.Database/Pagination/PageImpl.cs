using System.Collections;

namespace SlottyMedia.Database.Pagination;


/// <inheritdoc />
public class PageImpl<T> : IPage<T>
{
    /// <inheritdoc />
    public List<T> Content { get; }
    
    /// <inheritdoc />
    public int PageNumber { get; }
    
    /// <inheritdoc />
    public int PageSize { get; }
    
    /// <inheritdoc />
    public int TotalPages { get; }
    
    /// <inheritdoc />
    public bool HasNext => PageNumber < TotalPages - 1;
    
    /// <inheritdoc />
    public bool HasPrevious => PageNumber != 0;

    /// <summary>
    ///     Creates a page.
    /// </summary>
    /// <param name="content">The page's content</param>
    /// <param name="pageNumber">The number of this page</param>
    /// <param name="pageSize">The size of each page</param>
    /// <param name="totalPages">The number of total pages</param>
    public PageImpl(List<T> content, int pageNumber, int pageSize, int totalPages)
    {
        Content = content;
        PageNumber = pageNumber;
        PageSize = pageSize;
        TotalPages = totalPages;
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