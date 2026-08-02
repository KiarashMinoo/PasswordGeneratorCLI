# PasswordGenerator

A small .NET library and CLI for generating cryptographically secure passwords with customizable character sets.

## Install

```bash
dotnet add package PasswordGenerator
```

## Library usage

```csharp
using PasswordGenerator;

var password = Generator.Generate(24, options => {
    options.IncludeSymbols = true;
    options.BeginWithLetter = true;
    options.PreventDuplicateCharacters = true;
});
```

`Generator` uses `RandomNumberGenerator`. Custom character sets, duplicate prevention, and sequential-character prevention are supported. Impossible combinations fail with an exception instead of returning a password that violates the requested constraints.

## CLI

```bash
dotnet run --project PasswordGeneratorCLI -- 20 --symbols --no-duplicates --no-sequential --begin-with-letter
```

Options: `--no-uppercase`, `--no-lowercase`, `--no-numbers`, `--symbols`, `--no-duplicates`, `--no-sequential`, and `--begin-with-letter`.

## Build and test

```bash
dotnet build
dotnet test
dotnet pack PasswordGenerator/PasswordGenerator.csproj --configuration Release
```

The package targets `netstandard2.0` and `netstandard2.1`.