# Functional.DotNet

## Installation
To start using **Functional.DotNet** in your C# projects, install the package from NuGet:

- Using Package Manager:
```bash
Install-Package Functional.DotNet -Version 1.0.4
```

- Using .NET CLI:
```bash
dotnet add package Functional.DotNet --version 1.0.4

```

## Introduction
Welcome to **Functional.DotNet**, a framework designed to enhance the functional programming experience in C#. Inspired by functional programming principles, this toolset enables developers to write more efficient, readable, and maintainable C# code.

## Why Choose Functional.DotNet?
- **Ease of Use**: Intuitive design, making functional programming in C# accessible for all levels.
- **Enhanced Code Quality**: Promotes writing predictable, less error-prone code.
- **Seamless Integration**: Integrates smoothly with existing C# projects.

## Documentation
For a comprehensive guide on how to integrate and utilize **Functional.DotNet** in your C# projects, please refer to our [official documentation](./doc/DOCUMENTATION.md).


## Getting Started
Refer to our documentation for details on integrating and using this framework in your C# projects.

## Learning Resources
For beginners, check out my book ["Functional C#: Embracing Functional Programming in a C# World"](https://www.amazon.de/-/en/Carlos-Bueno/dp/B0C2SW3FHL/ref=sr_1_3?crid=2LFDX227TD7NL&keywords=functional+c%23&qid=1704711844&sprefix=%2Caps%2C91&sr=8-3), a great resource for understanding C# functional programming.

## Features and Code Samples

### Using `Try`
```csharp
// Example of using Try for exception-safe code
Try<Uri> CreateUri(string uri) => () => new Uri(uri);
    
var uriTry = CreateUri("http://github.com");

uriTry.Run().Match(
        Success: uri => Assert.NotNull(uri),
        Exception: ex => Fail()
);
```

### Working with Option
```csharp
// Example of using Option to handle optional values
Option<User> userOption = GetUserById(userId);
userOption.Match(
    Some: user => Console.WriteLine("User found: " + user.Name),
    None: () => Console.WriteLine("User not found"));
```


## Understanding Monads
In Functional.DotNet, we delve into the concept of monads, such as Try and Option, to handle various computational contexts in a more functional way.

## Contributing

Based on Enrico Buonanno's [la-yumba/functional-csharp-code-2](https://github.com/la-yumba/functional-csharp-code-2), **Functional.DotNet** extends these concepts to provide a comprehensive functional programming experience in C#.

Contributions are welcome! Please read CONTRIBUTING.md for guidelines.