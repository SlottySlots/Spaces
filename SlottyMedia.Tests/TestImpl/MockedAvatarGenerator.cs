using SlottyMedia.DatabaseSeeding.Avatar;

namespace SlottyMedia.Tests.TestImpl;

public class MockedAvatarGenerator : IAvatarGenerator
{
    public string RandomAvatarB64()
    {
        return "1234567";
    }
}