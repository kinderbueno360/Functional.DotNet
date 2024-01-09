# `Result` Type Documentation

## Overview

The `Result` type is a crucial construct in Functional.DotNet, used for representing the outcome of operations in a client-focused manner. It encapsulates the success or failure of an operation, along with an associated message, status code, and data.

## Key Features

- **Record Structure**: `Result<T>` is a record that holds a boolean `Success`, a `Message`, a `Status` code, and the `Data` of type `T`.
- **Utility Methods**: Static methods like `Unauthorized`, `BadRequest`, `NotFound`, `Error`, and `Success` for constructing various common result types.

## Methods and Their Use

### Static Constructors

- **Unauthorized**
- **Purpose**: Creates a `Result` indicating unauthorized access.
- **Usage Example**:

```csharp
var result = Result.Unauthorized<User>("Access denied");
```

- **BadRequest**
- **Purpose**: Creates a `Result` indicating a bad request.
- **Usage Example**:

```csharp
var result = Result.BadRequest<User>("Invalid input");
```

- **NotFound**
  - **Purpose**: Creates a `Result` indicating a not found error.
- **Usage Example**:

```csharp
var result = Result.NotFound<User>("User not found");
```

- **Error**
  - **Purpose**: Creates a `Result` indicating a server error.
- **Usage Example**:

```csharp
var result = Result.Error<User>("Internal server error");
```

- **Success**
  - **Purpose**: Creates a successful `Result` with data.
- **Usage Example**:

```csharp
var result = Result.Success(new User(...));
```

## Key Methods and Their Use

### `Map`

- **Purpose**: Transforms the data in the `Result` if successful.
- **Usage Example**:

```csharp
Result<User> userResult = Result.Success(new User(...));
var modifiedResult = userResult.Map(user => new ModifiedUser(user));
```

### `Match`

- **Purpose**: Executes different logic based on the success or failure of the `Result`.
- **Usage Example**:

```csharp
Result<User> result = ...
string message = result.Match(
    Fail: r => $"Failed: {r.Message}",
    Success: r => $"Success: {r.Data.Name}"
);

```

### `Select and SelectMany (For LINQ)`

- **Purpose**: Enables LINQ query syntax with `Result`, enhancing readability and expressiveness.
- **Usage Example**:

```csharp
var query = from userResult in GetUserResult() // GetUserResult returns Result<User>
            select user.Name; // Selecting the user's name

public class User
{
    public string Name { get; set; }
}

public static Result<User> GetUserResult()
{
    // Simulating a successful operation returning a User
    return Result.Success(new User { Name = "John Doe" });
}
```

## Summary

The `Result` type in Functional.DotNet is designed to handle the outcomes of operations in a structured and expressive manner, making it easier to convey success, failure, and related data in a functional programming context.
