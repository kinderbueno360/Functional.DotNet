# `Option` Type Documentation

## Overview
The `Option` type in Functional.DotNet is a fundamental concept in functional programming, used to represent optional values. It is a safer alternative to null references, helping avoid common errors like `NullReferenceException`.

## When to Use
Use `Option` when a value might or might not exist. For example, when a function could return a result or nothing at all, `Option` makes this explicit and forces the calling code to handle both possibilities.

## Key Methods and Their Use

### `Match`
- **Purpose**: To execute different logic based on whether the `Option` is `Some` (has a value) or `None` (no value).
- **Usage Example**:

```csharp
  string Greet(Option<string> name) =>
     name.Match(
         Some: n => $"hello, {n}",
         None: () => "sorry, who?");
```

### `Map`

- **Purpose**: Transforms the value inside `Option` if it exists, without having to explicitly check for `None``.
- **Usage Example**:

```csharp
Option<string> name = Some("John");
Option<string> upperName = name.Map(n => n.ToUpper());
```

### `GetOrElse`
- **Purpose**: Returns the value if present, otherwise returns a default value.
- **Usage Example**:
```csharp
  Option<int> maybeNumber = None;
  int value = maybeNumber.GetOrElse(0);  // returns 0
```

### `OrElse`
- **Purpose**: Returns the `Option` itself if it is `Some`, otherwise returns an alternative `Option`.
- **Usage Example**:
```csharp
  Option<int> maybeNumber = None;
  Option<int> alternative = maybeNumber.OrElse(() => Some(100));
```


### `Traverse`
- **Purpose**: Transforms an `Option` of a collection into a collection of `Option`s, applying a function to each element.
- **Usage Example**:
```csharp
Option<List<int>> numbersOption = Some(new List<int> { 1, 2, 3 });
List<Option<int>> traversed = numbersOption.Traverse(n => Some(n * 2));
``` 

### `IsSome`
- **Purpose**: Checks if the `Option` has a value (`Some`).
- **Usage Example**:
```csharp
Option<int> maybeNumber = Some(42);
bool hasValue = maybeNumber.IsSome;  // true
```



### LINQ Expressions
- **Purpose**: `Option` supports LINQ expressions, allowing for more expressive and readable operations.
- **Usage Example**:

```csharp
var result = from x in opt
             select x.ToUpper();

```
- **Usage Example 2**:

```csharp
Option<int> maybeNumber = Some(42);
var result = from num in maybeNumber
             where num > 40
             select num * 2;  // Option<int> with value 84
```

## Creating `Option` Values
- Use `Some(value)` to create an `Option` with a value.
- Use `None` to represent the absence of a value.

## Testing `Option`
The `OptionTest.cs` file provides various test cases showcasing the usage of `Option`, including matching, mapping, and LINQ query expressions.