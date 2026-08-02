# Password Generator
A flexible and secure password generator built in C#, designed to generate customizable passwords with strong security features. This tool allows users to configure password characteristics such as inclusion of uppercase, lowercase, numbers, symbols, and more, while also preventing duplicate or sequential characters.

### Features
- **Customizable Character Sets**: Supports uppercase, lowercase, digits, and symbols, with options for custom sets. 
- **Security Options**: Prevents duplicate and sequential characters for added password strength. 
- **Flexible Length and Format**: Easily configurable to generate passwords of any length, with options for starting with letters or numbers.
- **Cryptographic Randomness**: Uses RandomNumberGenerator to ensure secure and unpredictable password generation.

## Usage

### Console Application
You can use the Password Generator from the command line by passing arguments to control the length and features of the generated password.

#### Example Command:
```bash
PasswordGeneratorCLI <length> [options]
```

**Available Options:**
* ```--no-uppercase``` : Exclude uppercase letters from the password.
* ```--no-lowercase``` : Exclude lowercase letters from the password.
* ```--no-numbers``` : Exclude numbers from the password.
* ```--symbols``` : Include symbols in the password.
* ```--no-duplicates``` : Prevent duplicate characters in the password.
* ```--no-sequential``` : Prevent sequential characters in the password.
* ```--start-with-num``` : Start the password with a number instead of a letter.

#### Example Usage:
```bash
PasswordGeneratorCLI 12 --symbols --no-duplicates --no-sequential
```

This will generate a 12-character password with symbols, and it will ensure no duplicate or sequential characters.

### Installation
1. Clone the repository: 
```bash
git clone https://github.com/yourusername/password-generator.git
```
2. Navigate into the project directory:
```bash
cd password-generator
```
3. Build the solution:
```bash
dotnet build
```
4. Run the application:
```bash
dotnet run -- <length> [options]
```

### Unit Tests
This project includes unit tests written in xUnit to ensure the functionality of the password generator.

To run the tests, use:
```bash
dotnet test
```
#### Contributing
1. Fork the repository.
2. Create a new branch (git checkout -b feature-branch).
3. Make your changes and commit (git commit -am 'Add new feature').
4. Push to the branch (git push origin feature-branch).
5. Create a new Pull Request.