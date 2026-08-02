# AdvancedPassGenerator.UnitTests

xUnit tests for the `AdvancedPassGenerator` library.

## Coverage

The test suite verifies password length, character inclusion and exclusion, symbols, duplicate prevention, sequential-character prevention, and invalid length handling.

## Run the tests

From the repository root:

```bash
dotnet test AdvancedPassGenerator.UnitTests/AdvancedPassGenerator.UnitTests.csproj --configuration Release
```

Run the complete solution test suite with:

```bash
dotnet test PasswordGenerator.sln --configuration Release
```

Tests use the project reference to the local `AdvancedPassGenerator` library rather than the published package.