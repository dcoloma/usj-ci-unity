using System;

public class Greeter
{
    public string Greet(string name)
    {
        if (string.IsNullOrEmpty(name))
            throw new ArgumentException("Name cannot be empty");

        return $"Hello, {name}!";
    }

    public string GreetWithCount(string name, int count)
    {
        if (string.IsNullOrEmpty(name))
            throw new ArgumentException("Name cannot be empty");
        if (count < 1)
            throw new ArgumentOutOfRangeException(nameof(count), "Count must be at least 1");

        return count == 1 ? Greet(name) : $"Hello, {name}! (x{count})";
    }
}
