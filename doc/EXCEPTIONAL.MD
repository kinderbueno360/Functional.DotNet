# `Exceptional` Type Documentation

## Overview

The `Exceptional` type in Functional.DotNet is a construct designed to handle operations that might result in either a successful outcome or an exception. It encapsulates a value or an exception, allowing for more expressive and safer error handling compared to traditional try-catch blocks.

## When to Use

`Exceptional` is ideal for operations where you want to avoid throwing and catching exceptions directly, and instead handle them in a functional way. It's particularly useful in scenarios where an operation might fail, and you want to gracefully handle the failure.

## Key Methods and Their Use

### `Match`

- **Purpose**: Executes different logic based on whether the `Exceptional` contains a value or an exception.
- **Usage Example:**

```csharp
Exceptional<int> result = F.Exceptional(ComputeOperation());
string message = result.Match(
    Exception: ex => $"Error: {ex.Message}",
    Success: value => $"Value: {value}");

```

### `Map`

- **Purpose**: Transforms the value inside `Exceptional` if no exception occurred.
- **Usage Example:**

```csharp
Exceptional<int> number = F.Exceptional(GetNumber());
Exceptional<string> text = number.Map(n => n.ToString());

```

### `Bind`

- **Purpose**: Chains operations that return `Exceptional`, useful for sequential operations that might throw exceptions.
- **Usage Example:**

```csharp
Exceptional<int> operationResult = F.Exceptional(PerformOperation());
Exceptional<string> finalResult = operationResult.Bind(n => ConvertResult(n));
```

### `ForEach`

- **Purpose**: Executes an action on the value if the `Exceptional` is a success.
- **Usage Example:**

```csharp
Exceptional<int> result = F.Exceptional(SomeOperation());
result.ForEach(value => Console.WriteLine($"Processed value: {value}"));
```

### `Select`, `Where`, and `SelectMany` (LINQ Support)

- **Purpose**: Enhances the `Exceptional` type with LINQ query syntax, allowing for more readable and expressive operations.

## Creating `Exceptional` Values

- Typically created by wrapping a value or an exception in an `Exceptional` construct.
