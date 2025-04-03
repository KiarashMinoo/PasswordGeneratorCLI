using JetBrains.Annotations;

namespace PasswordGeneratorCLI.UnitTests;

[TestSubject(typeof(PasswordGenerator))]
public class PasswordGeneratorTest
{
    [Fact]
    public void Generate_ShouldReturnPassword_OfCorrectLength()
    {
        const int length = 12;
        var password = PasswordGenerator.Generate(length);
        Assert.Equal(length, password.Length);
    }

    [Fact]
    public void Generate_ShouldThrowException_WhenLengthIsLessThanFour()
    {
        Assert.Throws<ArgumentException>(() => PasswordGenerator.Generate(3));
    }

    [Fact]
    public void Generate_ShouldIncludeUpperCase_WhenEnabled()
    {
        var password = PasswordGenerator.Generate(10, settings => settings.IncludeUpperCase = true);
        Assert.Contains(password, char.IsUpper);
    }

    [Fact]
    public void Generate_ShouldNotIncludeUpperCase_WhenDisabled()
    {
        var password = PasswordGenerator.Generate(10, settings => settings.IncludeUpperCase = false);
        Assert.DoesNotContain(password, char.IsUpper);
    }

    [Fact]
    public void Generate_ShouldIncludeNumbers_WhenEnabled()
    {
        var password = PasswordGenerator.Generate(10, settings => settings.IncludeNumbers = true);
        Assert.Contains(password, char.IsDigit);
    }

    [Fact]
    public void Generate_ShouldNotIncludeNumbers_WhenDisabled()
    {
        var password = PasswordGenerator.Generate(10, settings => settings.IncludeNumbers = false);
        Assert.DoesNotContain(password, char.IsDigit);
    }

    [Fact]
    public void Generate_ShouldIncludeSymbols_WhenEnabled()
    {
        var password = PasswordGenerator.Generate(10, settings => settings.IncludeSymbols = true);
        Assert.Contains(password, c => PasswordGenerator.Symbols.Contains(c));
    }

    [Fact]
    public void Generate_ShouldPreventDuplicateCharacters_WhenEnabled()
    {
        var password = PasswordGenerator.Generate(10, settings => settings.PreventDuplicateCharacters = true);
        Assert.True(IsUnique(password));
    }

    [Fact]
    public void Generate_ShouldPreventSequentialCharacters_WhenEnabled()
    {
        var password = PasswordGenerator.Generate(10, settings => settings.PreventSequentialCharacters = true);
        Assert.False(HasSequentialCharacters(password));
    }

    private static bool IsUnique(string password)
    {
        var charSet = new HashSet<char>();
        return password.All(c => charSet.Add(c));
    }

    private static bool HasSequentialCharacters(string password)
    {
        for (var i = 0; i < password.Length - 1; i++)
        {
            if (Math.Abs(password[i] - password[i + 1]) == 1) return true;
        }

        return false;
    }
}