using SlottyMedia.Utils;

namespace SlottyMedia.Tests.UtilTests;


[TestFixture]
public class OptionalTests
{

    [Test]
    public void Get_WhenInnerException_ShouldThrow()
    {
        var optional = Optional<int>.Of(() => throw new ArithmeticException());
        Assert.Throws<InvalidOperationException>(() =>
        {
            optional.Get();
        });
    }

    [Test]
    public void Get_WhenInstanceNull_ShouldThrow()
    {
        var optional = Optional<int?>.Of(() => null);
        Assert.Throws<NullReferenceException>(() =>
        {
            optional.Get();
        });
    }

    [Test]
    public void Get_WhenInstancePresent_ShouldReturnInstance()
    {
        var optional = Optional<int>.Of(() => 7);
        var value = optional.Get();
        Assert.That(value, Is.EqualTo(7));
    }

    [Test]
    public void OrElse_WhenCallbackReturns_ShouldReturn()
    {
        var optional = Optional<int>.Of(() => throw new ArithmeticException());
        var value = optional.OrElse(() => 7);
        Assert.That(value, Is.EqualTo(7));
    }

    [Test]
    public void OrElse_WhenCallbackThrows_ShouldThrow()
    {
        var optional = Optional<int>.Of(() => throw new ArithmeticException());
        Assert.Throws<InvalidDataException>(() =>
        {
            optional.OrElse(() => throw new InvalidDataException());
        });
    }
    
}