namespace PasswordGeneratorCLI;

/// <summary>
/// Defines settings for password generation, allowing customization of character inclusion, sequence prevention, and more.
/// </summary>
public sealed class PasswordSettings
{
    /// <summary>Indicates whether uppercase letters should be included in the password.</summary>
    public bool IncludeUpperCase { get; set; } = true;

    /// <summary>Custom uppercase letter set. If specified, it overrides the default uppercase letters.</summary>
    public string? CustomUpperCase { get; set; }

    /// <summary>Indicates whether lowercase letters should be included in the password.</summary>
    public bool IncludeLowerCase { get; set; } = true;

    /// <summary>Custom lowercase letter set. If specified, it overrides the default lowercase letters.</summary>
    public string? CustomLowerCase { get; set; }

    /// <summary>Indicates whether numeric digits should be included in the password.</summary>
    public bool IncludeNumbers { get; set; } = true;

    /// <summary>Custom digit set. If specified, it overrides the default numeric digits.</summary>
    public string? CustomDigits { get; set; }

    /// <summary>Indicates whether symbols should be included in the password.</summary>
    public bool IncludeSymbols { get; set; } = false;

    /// <summary>Custom symbol set. If specified, it overrides the default symbols.</summary>
    public string? CustomSymbols { get; set; }

    /// <summary>Ensures the password begins with a letter.</summary>
    public bool BeginWithLetter { get; set; } = false;

    /// <summary>Prevents duplicate characters from appearing in the password.</summary>
    public bool PreventDuplicateCharacters { get; set; } = false;

    /// <summary>Prevents sequential characters (e.g., "abc", "123") from appearing in the password.</summary>
    public bool PreventSequentialCharacters { get; set; } = false;
}