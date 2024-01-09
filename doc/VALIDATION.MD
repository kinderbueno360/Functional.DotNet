# `Validation` Type Documentation

## Overview

The `Validation` type in Functional.DotNet is a functional programming construct used to accumulate errors while processing data. Unlike `Either`, which short-circuits on the first error, `Validation` can collect multiple errors.

## When to Use

Use `Validation` in scenarios where you need to validate data and it's important to report all errors, not just the first one encountered. This is particularly useful in form validation, data processing, and configuration validation tasks.

## Key Methods and Their Use

### `Match`

- **Purpose**: To execute different logic based on whether the `Validation` is successful or contains errors.
- **Usage Example**:

```csharp
Validation<List<string>, string> validationResult = ValidateData(someData);
string message = validationResult.Match(
    Valid: value => $"Data processed: {value}",
    Invalid: errors => $"Errors: {String.Join(", ", errors)}");
```

### `Map`

- **Purpose**: Transforms the value inside `Validation` if it is valid.
- **Usage Example**:

```csharp
Validation<List<string>, int> validNumber = ValidateNumber("42");
Validation<List<string>, string> numberDescription = validNumber.Map(n => $"Number is: {n}");
```

### `Bind`

- **Purpose**: Chains operations that return `Validation`, allowing for multiple validations to be combined.
- **Usage Example**:

```csharp
Validation<List<string>, UserData> userDataValidation = ValidateUserData(userData);
Validation<List<string>, ProcessedData> finalValidation = userDataValidation.Bind(data => ProcessData(data));
```

## Creating `Validation` Values

- Use `Valid(value)` to create a `Validation` representing a successful outcome.
- Use `Invalid(errors)` to create a `Validation` representing an unsuccessful outcome with a list of errors.
- **Usage Example**:

```csharp
// Valid example
Validation<List<string>, int> validResult = Valid(42);

// Invalid example
Validation<List<string>, int> invalidResult = Invalid(new List<string> { "Error 1", "Error 2" });
```

## Summary

The `Validation` type offers a robust way to handle multiple error scenarios in your applications, making it a valuable tool in scenarios requiring comprehensive error reporting and data validation.
