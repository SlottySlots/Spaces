namespace SlottyMedia.Backend.Exceptions.auth;

public class UserAlreadySignedInException : Exception
{
    public UserAlreadySignedInException() : base("User already signed in!")
    {
        
    }
}