using System.Security.Cryptography;
using System.Text;

namespace PasswordGeneratorCLI;

/// <summary>
/// A utility class for generating secure, customizable passwords.
/// </summary>
public sealed class PasswordGenerator
{
    public const string UpperCase = "ABCDEFGHJKMNPQRSTUVWXYZ"; // Excludes I and O
    public const string LowerCase = "abcdefghjkmnpqrstuvwxyz"; // Excludes i and o
    public const string Digits = "23456789"; // Excludes 0 and 1
    public const string Symbols = "!\";#$%&'()*+,-./:;<=>?@[\\]^_`{|}~";

    /// <summary>
    /// Generates a secure password based on the provided settings.
    /// </summary>
    /// <param name="length">The desired length of the password. Must be at least 4.</param>
    /// <param name="configure">An optional action to customize password settings.</param>
    /// <returns>A randomly generated password as a string.</returns>
    /// <exception cref="ArgumentException">Thrown when the length is less than 4 or no character types are selected.</exception>
    public static string Generate(int length, Action<PasswordSettings>? configure = null)
    {
        if (length < 4) throw new ArgumentException("Password length must be at least 4.");

        var settings = new PasswordSettings();
        configure?.Invoke(settings);

        var charSets = new List<string>();
        if (settings.IncludeUpperCase) charSets.Add(settings.CustomUpperCase ?? UpperCase);
        if (settings.IncludeLowerCase) charSets.Add(settings.CustomLowerCase ?? LowerCase);
        if (settings.IncludeNumbers) charSets.Add(settings.CustomDigits ?? Digits);
        if (settings.IncludeSymbols) charSets.Add(settings.CustomSymbols ?? Symbols);

        if (charSets.Count == 0) throw new ArgumentException("At least one character type must be selected.");

        var password = new StringBuilder();
        var usedCharacters = new HashSet<char>();

        // Ensure first character is a letter if required
        if (settings.BeginWithLetter)
        {
            AppendRandomChar((settings.CustomUpperCase ?? UpperCase) + (settings.CustomLowerCase ?? LowerCase));
        }

        while (password.Length < length)
        {
            var selectedSet = charSets[RandomNumberGenerator.GetInt32(charSets.Count)];
            AppendRandomChar(selectedSet);
        }

        return password.ToString();

        void AppendRandomChar(string chars)
        {
            char c;
            int attempt = 0;
            do
            {
                c = chars[RandomNumberGenerator.GetInt32(chars.Length)];

                if (++attempt > 50) // Failsafe to prevent infinite loops
                    break;

                if (settings.PreventDuplicateCharacters && usedCharacters.Contains(c))
                    continue;

                if (settings.PreventSequentialCharacters && password.Length > 0 && IsSequential(password[^1], c))
                    continue;

                break;
            } while (true);

            password.Append(c);
            usedCharacters.Add(c);
        }

        bool IsSequential(char a, char b) => Math.Abs(a - b) == 1;
    }
}