namespace SlottyMedia.Backend.Exceptions.auth;

/// <summary>
///     Exception to handle missing Access- and RefreshToken f.e. when handling Sessions
/// </summary>
public class TokenNotProvidedException : Exception
{
    /// <summary>
    ///     Initializes a TokenNotProvidedException. It als implements an inner exception showing which token is missin
    /// </summary>
    /// <param name="accessTokenProvided">
    ///     Boolean indicating the existence of an AccessToken
    /// </param>
    /// <param name="refreshTokenProvided">
    ///     Boolean indicating the existence of a RefreshToken
    /// </param>
    public TokenNotProvidedException(bool accessTokenProvided, bool refreshTokenProvided) : base(
        "Access- and or Refreshtoken not provided",
        new NullReferenceException(
            $"AccessToken is null: {accessTokenProvided}, RefreshToken is null: {refreshTokenProvided}")
    )
    {
    }
}