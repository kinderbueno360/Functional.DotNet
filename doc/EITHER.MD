# `Either` Type Documentation

## Overview

The `Either` type is an important construct in functional programming, utilized in Functional.DotNet to represent a value that can be one of two types. It's commonly used in error handling, where one type indicates a successful outcome and the other an error or failure.

## When to Use

`Either` is suitable for operations that may result in two distinct outcomes. It offers a more descriptive and controlled approach to error handling compared to traditional exceptions, allowing explicit management of both success and failure cases.

## Key Methods and Their Use

### `Match`

- **Purpose**: Executes different logic based on whether the `Either` is `Left` (typically an error) or `Right` (typically a success).
- **Usage Example**:

```csharp
Either<string, int> result = ComputeSomeOperation();
string message = result.Match(
    Left: error => $"Error occurred: {error}",
    Right: value => $"Operation successful: {value}");
```

### `Map`

- **Purpose**: Transforms the value inside `Either` if it is a `Right`, without modifying the `Left` value.
- **Usage Example**:

```csharp
Either<string, int> number = Right(42);
Either<string, string> text = number.Map(n => $"Number is: {n}");
```

### `Bind`

- **Purpose**: Facilitates the chaining of operations that return `Either`, particularly useful in workflows where each step might fail.
- **Usage Example**:

```csharp
Either<string, int> firstOperation = PerformFirstOperation();
Either<string, string> finalResult = firstOperation.Bind(n => PerformSecondOperation(n));
```

### `IsLeft` and `IsRight`

- **Purpose**: Checks whether the `Either` is `Left` or `Right`.
- **Usage Examples**:

```csharp
Either<string, int> result = Right(42);
bool isRight = result.IsRight;  // true
bool isLeft = result.IsLeft;    // false
```

### `ForEach` Method for `Either` Type

#### Overview

The `ForEach` method in the `Either` type is a feature of the Functional.DotNet library, designed for executing actions on the `Right` value. This method simplifies operations on `Either` when it's in the successful state (`Right`).

#### When to Use

Use `ForEach` to perform actions on the `Right` value of an `Either`. It's useful for executing side-effects like logging or updating UI, but only when the `Either` is a success.

#### Method Signature

```csharp
public void ForEach(Action<T> action)
```

The method typically has a signature like `public void ForEach(Action<T> action)`, where `action` is the operation to perform on the `Right` value.

#### Usage Example

Imagine a scenario where you want to log a message if the `Either` is `Right`. `ForEach` allows you to cleanly execute this without manual state checking.

```csharp
Either<string, int> result = Right(42);

// Using ForEach to execute an action if result is Right
result.ForEach(value => Console.WriteLine($"Processed value: {value}"));

```

#### Summary

`ForEach` offers a functional and concise way to handle successful outcomes in `Either`, maintaining the clarity and expressiveness of functional programming.

### LINQ Support: `Select`, `Where`, `SelectMany`

- **Purpose**: Enables LINQ query syntax with `Either`, enhancing readability and expressiveness.
- **Usage Example**:

```csharp
Either<string, int> number = Right(42);
var result = from num in number
            where num > 40
            select num * 2;  // Either<string, int> with Right value 84
```

## Creating `Either` Values

- Use `Left(value)` to create an `Either` representing the left type (typically an error).
- Use `Right(value)` to create an `Either` representing the right type (typically a successful result).
