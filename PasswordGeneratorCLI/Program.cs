using PasswordGeneratorCLI;

if (args.Length == 0 || args[0] == "--help")
{
    Console.WriteLine("Usage: PasswordGeneratorCLI <length> [options]");
    Console.WriteLine("Options:");
    Console.WriteLine("  --no-uppercase    Exclude uppercase letters");
    Console.WriteLine("  --no-lowercase    Exclude lowercase letters");
    Console.WriteLine("  --no-numbers      Exclude numbers");
    Console.WriteLine("  --symbols         Include symbols");
    Console.WriteLine("  --no-duplicates   Prevent duplicate characters");
    Console.WriteLine("  --no-sequential   Prevent sequential characters");
    Console.WriteLine("  --begin-with-letter  Start password with a letter instead of a number");
    return;
}

if (!int.TryParse(args[0], out var length) || length < 4)
{
    Console.WriteLine("Error: Password length must be a number and at least 4.");
    return;
}

var settings = new PasswordSettings();

foreach (var arg in args)
{
    switch (arg)
    {
        case "--no-uppercase":
            settings.IncludeUpperCase = false;
            break;
        case "--no-lowercase":
            settings.IncludeLowerCase = false;
            break;
        case "--no-numbers":
            settings.IncludeNumbers = false;
            break;
        case "--symbols":
            settings.IncludeSymbols = true;
            break;
        case "--no-duplicates":
            settings.PreventDuplicateCharacters = true;
            break;
        case "--no-sequential":
            settings.PreventSequentialCharacters = true;
            break;
        case "--start-with-num":
            settings.BeginWithLetter = true;
            break;
    }
}

try
{
    var password = PasswordGenerator.Generate(length, config =>
    {
        config.IncludeUpperCase = settings.IncludeUpperCase;
        config.IncludeLowerCase = settings.IncludeLowerCase;
        config.IncludeNumbers = settings.IncludeNumbers;
        config.IncludeSymbols = settings.IncludeSymbols;
        config.PreventDuplicateCharacters = settings.PreventDuplicateCharacters;
        config.PreventSequentialCharacters = settings.PreventSequentialCharacters;
        config.BeginWithLetter = settings.BeginWithLetter;
    });

    Console.WriteLine($"Generated Password: {password}");
}
catch (ArgumentException ex)
{
    Console.WriteLine($"Error: {ex.Message}");
}