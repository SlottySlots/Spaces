using SlottyMedia.LoggingProvider;

namespace SlottyMedia.Backend.Exceptions.signup;

/// <summary>
///     An exception that is thrown when a user attempts to sign up with a password that
///     is too short.
/// </summary>
public class PasswordTooShortException : BaseException<PasswordTooShortException>;