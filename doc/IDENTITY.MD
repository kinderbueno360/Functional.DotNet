# `Identity` Type Documentation

## Overview

The `Identity` type in the Functional.DotNet library is a minimalist functional programming construct. It represents a value encapsulated within a function, allowing for the application of functional transformations without affecting the value's essence.

## When to Use

The `Identity` type is ideal for simple scenarios where you wish to apply functional operations to a value without introducing additional complexity. It is also useful when integrating with other functional constructs that expect a function rather than a direct value.

## Key Methods and Their Use

### `Map`

- **Purpose**: Applies a transformation function to the value within the `Identity`, producing a new `Identity` of a potentially different type.
- **Usage Example**:

```csharp
Identity<int> numberIdentity = F.Identity(42);
Identity<string> textIdentity = numberIdentity.Map(n => $"Number is: {n}");
```

### `Bind`

- **Purpose**: Allows for the sequential application of operations that return an `Identity`, facilitating a chain of transformations.
- **Usage Example**:

```csharp
Identity<int> numberIdentity = F.Identity(42);
Identity<double> squaredIdentity = numberIdentity.Bind(n => F.Identity(Math.Pow(n, 2)));

```

## Creating `Identity` Values

- Use `F.Identity(value)` to create an `Identity` instance that encapsulates a given value.
- **Purpose**: Allows for the sequential application of operations that return an `Identity`, facilitating a chain of transformations.
- **Usage Example**:

```csharp
Identity<string> nameIdentity = F.Identity("Alice");

```

## Summary

The `Identity` type is a core part of the Functional.DotNet library, providing a straightforward way to work with values in a functional context. Its simplicity makes it an accessible entry point to functional programming concepts and techniques.
