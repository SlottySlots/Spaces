using SlottyMedia.LoggingProvider;

namespace SlottyMedia.Backend.Exceptions.signup;

/// <summary>
///     An exception that is thrown when a user attempts to sign up with a username that
///     is either too long or too short.
/// </summary>
public class IllegalUsernameLengthException : BaseException<IllegalUsernameLengthException>;