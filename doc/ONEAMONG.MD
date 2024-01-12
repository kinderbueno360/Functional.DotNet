# `OneAmong` Type Documentation

## Overview

The `OneAmong` type is a discriminated union that can hold a value of one among several possible types. It is commonly used in functional programming to represent a value that can take on different forms.

## When to Use

Use the `OneAmong` type when you need to work with values that may have different types but share a common interface or usage context. It allows you to express the idea of having one value among a set of possible values.

## Key Methods and Their Use

### `Match`

- **Purpose**: Executes different logic based on the actual type of the `OneAmong` instance.
- **Usage Example**:
```csharp
OneAmong<string, int> oneAmong = new OneAmong<string, int>("Hello");

string result = oneAmong.Match(
    strValue => $"String: {strValue}",
    intValue => $"Int: {intValue}"
);

Console.WriteLine(result); // Output: "String: Hello"
```

### `Map`

- **Purpose**: Transforms the value inside a `OneAmong` instance if it matches a specific type.
- **Usage Example**:
```csharp
OneAmong<string, int> oneAmong = new OneAmong<string, int>("Hello");

OneAmong<string, double> mappedOneAmong = oneAmong.Map(strValue => double.Parse(strValue));

Console.WriteLine(mappedOneAmong.Match(
    strValue => $"String: {strValue}",
    doubleValue => $"Double: {doubleValue}"
)); // Output: "Double: 0"

```

### `Bind`

- **Purpose**: Allows chaining operations that return `OneAmong` instances.
- **Usage Example**:
```csharp
OneAmong<string, int> oneAmong = new OneAmong<string, int>("42");

OneAmong<string, double> resultOneAmong = oneAmong.Bind(strValue => new OneAmong<string, double>(double.Parse(strValue)));

Console.WriteLine(resultOneAmong.Match(
    strValue => $"String: {strValue}",
    doubleValue => $"Double: {doubleValue}"
)); // Output: "Double: 42"

```

### `Select` and `SelectMany`

- **Purpose**: Enables LINQ query syntax with `OneAmong`, enhancing readability and expressiveness.
- **Usage Example**:
```csharp
OneAmong<string, int> oneAmong = new OneAmong<string, int>("42");

var result = from value in oneAmong
             where value > 40
             select value * 2; // OneAmong<int, string> with value 84

Console.WriteLine(result.Match(
    intValue => $"Int: {intValue}",
    strValue => $"String: {strValue}"
)); // Output: "Int: 84"

```

## Creating `OneAmong` Values

- Use constructors like `new OneAmong<T0, T1>(value)` to create `OneAmong` instances with values of specific types.

## Summary

The `OneAmong` type provides a powerful way to work with values that can be one among several types. It allows you to express complex scenarios in a clean and expressive manner.
