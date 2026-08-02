# AdvancedPassGenerator

A small .NET solution for secure password generation. It contains a reusable NuGet library, a command-line application, and automated tests.

## Projects

- [`AdvancedPassGenerator`](AdvancedPassGenerator/README.md) — reusable `netstandard2.0` library and NuGet package.
- [`PasswordGeneratorCLI`](PasswordGeneratorCLI/README.md) — command-line interface for generating passwords.
- [`AdvancedPassGenerator.UnitTests`](AdvancedPassGenerator.UnitTests/README.md) — xUnit tests for the library.

## Quick start

Install the library:

```bash
dotnet add package AdvancedPassGenerator
```

Or run the CLI from the repository root:

```bash
dotnet run --project PasswordGeneratorCLI -- 20 --symbols --no-duplicates --no-sequential --begin-with-letter
```

## Build, test, and package

```bash
dotnet restore
dotnet build PasswordGenerator.sln --configuration Release
dotnet test PasswordGenerator.sln --configuration Release
dotnet pack AdvancedPassGenerator/AdvancedPassGenerator.csproj --configuration Release
```

The library uses `RandomNumberGenerator`, supports custom character sets and generation constraints, and rejects impossible configurations instead of silently violating them. The generated NuGet package includes the library README and icon.

## Repository automation

GitHub Actions runs build, test, package, dependency, and security checks. Dependabot monitors NuGet and GitHub Actions dependencies.

## License

MIT