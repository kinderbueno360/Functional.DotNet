# `Try` Type Documentation

## Overview

The `Try` type in Functional.DotNet is a functional programming construct designed to handle computations that might fail due to exceptions. It encapsulates a lazy-loaded operation, evaluated only when its result is needed.

## Advantages of Lazy Loading

- **Deferred Execution**: Operations within `Try` are not executed until explicitly invoked, allowing better control over exception handling.
- **Efficiency**: Delays computations until necessary, improving performance in resource-intensive scenarios.
- **Composability**: Facilitates chaining and composing multiple operations in a lazy manner.

## Key Methods and Their Use

### `Run`

- **Purpose**: Executes the encapsulated operation and returns an `Exceptional` type, representing either success or an exception.
- **Usage Example**:

```csharp
Try<Uri> uriTry = CreateUri("http://github.com");
uriTry.Run().Match(
    Success: uri => Console.WriteLine($"URI: {uri}"),
    Exception: ex => Console.WriteLine($"Error: {ex.Message}")
);

```

### Creating a `Try`

- **Purpose**: Encapsulates a potentially failing operation.
- **Usage Example**:

```csharp
Try<Uri> CreateUri(string uri) => () => new Uri(uri);

```

### `Map` and `Bind`

- **Purpose**: Enable functional composition of operations.
- **Usage Example**:

```csharp
var schemeTry = uriTry.Map(uri => uri.Scheme);

```

### LINQ Support: `Select` and `SelectMany`

- **Purpose**: Enhances code readability and expressiveness with LINQ query syntax.
- **Usage Example**:

```csharp
var uriTry = from uri in CreateUri("http://github.com")
             select uri.Scheme;

```
