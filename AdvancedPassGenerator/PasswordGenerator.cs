using System.Security.Cryptography;
using System.Text;

namespace AdvancedPassGenerator;

/// <summary>Provides cryptographically secure password generation.</summary>
public sealed class PasswordGenerator
{
    /// <summary>Uppercase characters used by default, excluding ambiguous characters.</summary>
    public const string UpperCase = "ABCDEFGHJKMNPQRSTUVWXYZ";

    /// <summary>Lowercase characters used by default, excluding ambiguous characters.</summary>
    public const string LowerCase = "abcdefghjkmnpqrstuvwxyz";

    /// <summary>Digits used by default, excluding ambiguous characters.</summary>
    public const string Digits = "23456789";

    /// <summary>Symbols used by default.</summary>
    public const string Symbols = "!\";#$%&'()*+,-./:;<=>?@[\\]^_`{|}~";

    /// <summary>Generates a password using secure random values and the supplied options.</summary>
    /// <param name="length">The password length; must be at least four.</param>
    /// <param name="configure">Optional settings configuration callback.</param>
    /// <returns>A password matching the requested settings.</returns>
    /// <exception cref="ArgumentException">Thrown when settings are invalid or impossible to satisfy.</exception>
    public static string Generate(int length, Action<PasswordSettings>? configure = null)
    {
        if (length < 4) throw new ArgumentException("Password length must be at least 4.", nameof(length));
        var settings = new PasswordSettings();
        configure?.Invoke(settings);
        var sets = new List<string>();
        if (settings.IncludeUpperCase) sets.Add(Set(settings.CustomUpperCase, UpperCase, nameof(settings.CustomUpperCase)));
        if (settings.IncludeLowerCase) sets.Add(Set(settings.CustomLowerCase, LowerCase, nameof(settings.CustomLowerCase)));
        if (settings.IncludeNumbers) sets.Add(Set(settings.CustomDigits, Digits, nameof(settings.CustomDigits)));
        if (settings.IncludeSymbols) sets.Add(Set(settings.CustomSymbols, Symbols, nameof(settings.CustomSymbols)));
        if (sets.Count == 0) throw new ArgumentException("At least one character type must be selected.");
        if (settings.PreventDuplicateCharacters && sets.SelectMany(x => x).Distinct().Count() < length)
            throw new ArgumentException("The selected character sets do not contain enough unique characters for this length.", nameof(length));

        var password = new StringBuilder(length);
        var used = new HashSet<char>();
        if (settings.BeginWithLetter)
            Append(Set(settings.CustomUpperCase, UpperCase, nameof(settings.CustomUpperCase)) + Set(settings.CustomLowerCase, LowerCase, nameof(settings.CustomLowerCase)));
        while (password.Length < length)
            Append(sets[SecureIndex(sets.Count)]);
        return password.ToString();

        void Append(string chars)
        {
            var candidates = chars.Where(c => !settings.PreventDuplicateCharacters || !used.Contains(c))
                .Where(c => !settings.PreventSequentialCharacters || password.Length == 0 || Math.Abs(password[password.Length - 1] - c) != 1).ToArray();
            if (candidates.Length == 0) throw new ArgumentException("The selected constraints cannot produce a password of the requested length.", nameof(length));
            var c = candidates[SecureIndex(candidates.Length)];
            password.Append(c);
            used.Add(c);
        }

        static int SecureIndex(int exclusiveMax)
        {
            using var rng = RandomNumberGenerator.Create();
            var bytes = new byte[4];
            var limit = uint.MaxValue - (uint.MaxValue % (uint)exclusiveMax);
            do
            {
                rng.GetBytes(bytes);
            } while (BitConverter.ToUInt32(bytes, 0) >= limit);

            return (int)(BitConverter.ToUInt32(bytes, 0) % (uint)exclusiveMax);
        }

        static string Set(string? custom, string fallback, string name)
        {
            if (custom is not null && custom.Length == 0) throw new ArgumentException("A custom character set cannot be empty.", name);
            return custom ?? fallback;
        }
    }
}