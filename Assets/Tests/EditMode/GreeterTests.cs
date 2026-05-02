using NUnit.Framework;

public class GreeterTests
{
    private Greeter _greeter;

    [SetUp]
    public void SetUp()
    {
        _greeter = new Greeter();
    }

    // --- Greet ---

    [Test]
    public void Greet_ReturnsCorrectMessage()
    {
        Assert.AreEqual("Hello, World!", _greeter.Greet("World"));
    }

    [Test]
    public void Greet_WorksWithAnyName()
    {
        Assert.AreEqual("Hello, USJ!", _greeter.Greet("USJ"));
    }

    [Test]
    public void Greet_ThrowsForEmptyName()
    {
        Assert.Throws<System.ArgumentException>(() => _greeter.Greet(""));
    }

    [Test]
    public void Greet_ThrowsForNullName()
    {
        Assert.Throws<System.ArgumentException>(() => _greeter.Greet(null));
    }

    // --- GreetWithCount ---

    [Test]
    public void GreetWithCount_ReturnsSimpleGreetForCountOne()
    {
        Assert.AreEqual("Hello, World!", _greeter.GreetWithCount("World", 1));
    }

    [Test]
    public void GreetWithCount_ReturnsCountedGreetForCountAboveOne()
    {
        Assert.AreEqual("Hello, World! (x3)", _greeter.GreetWithCount("World", 3));
    }

    [Test]
    public void GreetWithCount_ThrowsForZeroCount()
    {
        Assert.Throws<System.ArgumentOutOfRangeException>(() => _greeter.GreetWithCount("World", 0));
    }

    [Test]
    public void GreetWithCount_ThrowsForNegativeCount()
    {
        Assert.Throws<System.ArgumentOutOfRangeException>(() => _greeter.GreetWithCount("World", -1));
    }

    [Test]
    public void GreetWithCount_ThrowsForEmptyName()
    {
        Assert.Throws<System.ArgumentException>(() => _greeter.GreetWithCount("", 2));
    }
}
