using System.Collections;
using SlottyMedia.Database.Pagination;

namespace SlottyMedia.Tests.TestImpl;

/// <summary>
///     This class is a test implementation of <see cref="IPage{T}" />.
///     It allows to set all fields of a page and does not provide
///     any actual functionalities. Use for mocking purposes only!
/// </summary>
/// <typeparam name="T">The type of the page's content</typeparam>
public class PageTestImpl<T> : IPage<T>
{
    /// <summary>
    ///     Initializes a new page with the given members.
    /// </summary>
    public PageTestImpl(List<T> content, int pageNumber, int pageSize, int totalPages)
    {
        PageNumber = pageNumber;
        PageSize = pageSize;
        TotalPages = totalPages;
        Content = content;
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

    /// <inheritdoc />
    public int PageNumber { get; }

    /// <inheritdoc />
    public int PageSize { get; }

    /// <inheritdoc />
    public int TotalPages { get; }

    /// <inheritdoc />
    public List<T> Content { get; }

    /// <inheritdoc />
    public IPage<TMapped> Map<TMapped>(Func<T, TMapped> function)
    {
        return new PageTestImpl<TMapped>(
            Content.Select(function.Invoke).ToList(),
            PageNumber,
            PageSize,
            TotalPages);
    }

    /// <summary>
    ///     Simulates fetching some other page, but simply returns this object.
    /// </summary>
    public Task<IPage<T>> Fetch(int pageNumber)
    {
        return new Task<IPage<T>>(() => this);
    }
}