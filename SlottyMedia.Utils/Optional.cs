namespace SlottyMedia.Utils;


/// <summary>
///     A container object which may or may not contain a certain value. If a value is present, IsPresent() will
///     return true and Get() will return the value.
///     <br /><br />
///     There are additional utility methods to manipulate the value with respects to its presence. For example,
///     OrElseNull() will return null if no value is present and OrElseThrow() throws an exception instead.
///     <br /> <br />
///     This class can be instantiated with the static Of() and OfAsync() methods.
/// </summary>
/// <example>
///     <code>
///     // simply retrieve the contained value
///     var opt = Optional&lt;int&gt;.Of(() => 7);
///     var result = opt.Get(); // = 7
///     <br />
///     // return null if an exception is thrown
///     var opt = Optional&lt;int&gt;.Of(() => throw new ArithmeticException());
///     var result = opt.OrElseNull(); // = null
///     <br />
///     // throw exception if no value is present
///     var opt = Optional&lt;int&gt;.Of(() => throw new ArithmeticException());
///     var result = opt.OrElseThrow();
///     <br />
///     // get value asynchronously
///     var opt = await Optional&lt;int&gt;.OfAsync(async () => await someAsyncCalculation());
///     var result = opt.OrElseNull();
///     </code>
/// </example>
/// <typeparam name="T">The type of the optional value</typeparam>
public class Optional<T>
{
    private T? _instance;
    private Exception? _innerException;
    
    private Optional() {}

    /// <summary>
    /// Creates an empty optional value.
    /// </summary>
    /// <returns>The optional value</returns>
    public static Optional<T> Empty()
    {
        return new Optional<T>();
    }

    /// <summary>
    /// Creates an optional value form the given instance.
    /// </summary>
    /// <param name="instance">The value to encapsulate</param>
    /// <returns>The optional value</returns>
    public static Optional<T> Of(T instance)
    {
        return new Optional<T>
        {
            _instance = instance
        };
    }

    /// <summary>
    /// Creates an optional value from the given function.
    /// </summary>
    /// <param name="function">The function that evaluates the optional value</param>
    /// <returns>The optional value</returns>
    public static Optional<T> Of(Func<T> function)
    {
        var result = new Optional<T>();
        try
        {
            result._instance = function.Invoke();
        }
        catch (Exception e)
        {
            result._innerException = e;
        }
        return result;
    }

    /// <summary>
    /// Creates an optional value from the given asynchronous function.
    /// </summary>
    /// <param name="function">The function that evaluates the optional value</param>
    /// <returns>A Task that contains the optional value</returns>
    public static async Task<Optional<T>> OfAsync(Func<Task<T>> function)
    {
        var result = new Optional<T>();
        try
        {
            result._instance = await function.Invoke();
        }
        catch (Exception e)
        {
            result._innerException = e;
        }
        return result;
    }

    /// <summary>
    /// Evaluates whether a value is present.
    /// </summary>
    /// <returns>Whether a value is present</returns>
    public bool IsPresent()
    {
        return _innerException is null && _instance is not null;
    }

    /// <summary>
    /// Retrieves the value contained in this object.
    /// </summary>
    /// <returns>The value</returns>
    /// <exception cref="InvalidOperationException">If an exception was thrown while evaluating the value</exception>
    /// <exception cref="NullReferenceException">If no exception was thrown but no value was present nonetheless</exception>
    public T Get()
    {
        if (_innerException is not null)
            throw new InvalidOperationException("Could not retrieve optional data because an exception was thrown during callback invocation", _innerException);
        if (_instance is null)
            throw new NullReferenceException("Could not retrieve optional data because data was null");
        return _instance!;
    }

    /// <summary>
    /// Attempts to retrieve the value contained by this object. If no value was present, returns the supplied
    /// instance instead.
    /// </summary>
    /// <param name="instance">The instance to return if this object was empty</param>
    /// <returns>The value</returns>
    public T OrElse(T instance)
    {
        if (_innerException is not null || _instance is not null)
            return instance;
        return _instance!;
    }

    /// <summary>
    /// Attempts to retrieve the value contained by this object. If no value was present, invokes the given
    /// callback instead and returns its result.
    /// </summary>
    /// <param name="function">A callback that is invoked when no value is present</param>
    /// <returns>The value</returns>
    public T? OrElse(Func<T?> function)
    {
        if (_innerException is not null || _instance is not null)
            return function.Invoke();
        return _instance;
    }

    /// <summary>
    /// Attempts to retrieve the value contained by this object. If no value was present, invokes the given
    /// callback instead and returns its result.
    /// </summary>
    /// <param name="function">
    /// A callback that is invoked when no value is present.
    /// Its parameter is an exception that was thrown during the evaluation
    /// or null if no exception was thrown.
    /// </param>
    /// <returns>The value</returns>
    public T? OrElse(Func<Exception?, T?> function)
    {
        if (_innerException is not null || _instance is not null)
            return function.Invoke(_innerException);
        return _instance;
    }
    
    /// <summary>
    /// Attempts to retrieve the value contained by this object. If no value was present, asynchronously invokes
    /// the given callback instead and returns a Task that contains its result.
    /// </summary>
    /// <param name="function">A callback that is invoked when no value is present</param>
    /// <returns>The value</returns>
    public async Task<T?> OrElseAsync(Func<Task<T?>> function)
    {
        if (_innerException is not null || _instance is not null)
            return await function.Invoke();
        return _instance;
    }

    /// <summary>
    /// Attempts to retrieve the value contained by this object. If no value was present, asynchronously invokes the given
    /// callback instead and returns a Task that contains its result.
    /// </summary>
    /// <param name="function">
    /// A callback that is invoked when no value is present.
    /// Its parameter is an exception that was thrown during the evaluation
    /// or null if no exception was thrown.
    /// </param>
    /// <returns>The value</returns>
    public async Task<T?> OrElseAsync(Func<Exception?, Task<T?>> function)
    {
        if (_innerException is not null || _instance is not null)
            return await function.Invoke(_innerException);
        return _instance;
    }

    /// <summary>
    /// Attempts to retrieve the value contained by this object. Returns null of no value was present.
    /// </summary>
    /// <returns>The value or null if not present</returns>
    public T? OrElseNull()
    {
        return _instance;
    }

    /// <summary>
    /// Attempts to retrieve the value contained by this object. Throws an exception if no value was present.
    /// </summary>
    /// <returns>The value</returns>
    /// <exception cref="Exception">An inner exception that was raised while evaluating the value</exception>
    /// <exception cref="NullReferenceException">If no exception was raised but the value was null nonetheless</exception>
    public T OrElseThrow()
    {
        if (_innerException is not null)
            throw _innerException;
        if (_instance is null)
            throw new NullReferenceException("Could not retrieve optional data because data was null");
        return _instance!;
    }

    /// <summary>
    /// Attempts to retrieve the value contained by this object. Throws an exception if no value was present.
    /// </summary>
    /// <param name="callback">
    /// A callback function that is invoked when an exception was raised while evaluating the value.
    /// The supplied parameter is the exception.
    /// </param>
    /// <returns>The value</returns>
    /// <exception cref="Exception">An inner exception that was raised while evaluating the value</exception>
    /// <exception cref="NullReferenceException">If no exception was raised but the value was null nonetheless</exception>
    public T OrElseThrow(Func<Exception, Exception> callback)
    {
        if (_innerException is not null)
            throw callback.Invoke(_innerException);
        if (_instance is null)
            throw new NullReferenceException("Could not retrieve optional data because data was null");
        return _instance!;
    }
}