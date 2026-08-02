# PasswordGeneratorCLI

`PasswordGeneratorCLI` is the command-line companion to the `AdvancedPassGenerator` library.

## Run

From the repository root:

```bash
dotnet run --project PasswordGeneratorCLI -- 20 --symbols --no-duplicates --no-sequential --begin-with-letter
```

The first argument is the password length and must be at least 4.

## Options

| Option | Description |
| --- | --- |
| `--no-uppercase` | Excludes uppercase characters. |
| `--no-lowercase` | Excludes lowercase characters. |
| `--no-numbers` | Excludes numbers. |
| `--symbols` | Includes symbols. |
| `--no-duplicates` | Prevents repeated characters. |
| `--no-sequential` | Prevents adjacent sequential characters. |
| `--begin-with-letter` | Starts the password with a letter. |
| `--help`, `-h` | Displays usage information. |

If the selected rules cannot produce a password of the requested length, the command reports an error.

## Build and test

```bash
dotnet build
dotnet test
```

For the reusable library, install the NuGet package:

```bash
dotnet add package AdvancedPassGenerator
```