# AdvancedPassGenerator library

This project is the reusable password-generation library published as the `AdvancedPassGenerator` NuGet package.

## Install

```bash
dotnet add package AdvancedPassGenerator
```

## API

```csharp
using AdvancedPassGenerator;

var password = PasswordGenerator.Generate(24, settings =>
{
    settings.IncludeSymbols = true;
    settings.BeginWithLetter = true;
    settings.PreventDuplicateCharacters = true;
});
```

The library targets `netstandard2.0` and uses `RandomNumberGenerator` for secure random selection. It supports uppercase, lowercase, numeric, and symbol sets; custom sets; letter-first passwords; duplicate prevention; and sequential-character prevention.

Invalid custom sets and impossible constraints throw `ArgumentException`.

## Package development

From the repository root:

```bash
dotnet build AdvancedPassGenerator/AdvancedPassGenerator.csproj --configuration Release
dotnet pack AdvancedPassGenerator/AdvancedPassGenerator.csproj --configuration Release
```

The package metadata includes this README and `icon.png`.