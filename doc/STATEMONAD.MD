# StateMonad Class Documentation

## Overview

The `StateMonad` class provides a way to model state transformations in a functional programming style within the C# language. It encapsulates state transitions, allowing for the chaining of operations that modify or query state, facilitating a more declarative approach to managing state in applications.

## Methods

### Return `<S, T>`

Creates a state monad from a value.

- **Parameters:**
  - `T value`: The value to encapsulate into the state monad.
- **Returns:** `State<S, T>` representing the initial value and state.

### Bind `<S, T, U>`

Chains the computation of state monads, passing the result of one as the input to another.

- **Parameters:**
  - `State<S, T> stateFunc`: The initial state function.
  - `Func<T, State<S, U>> func`: The function to apply to the result of `stateFunc`.
- **Returns:** `State<S, U>` resulting from applying `func` to the output of `stateFunc`.

### Map `<S, T, U>`

Transforms the value inside the state monad using a provided mapping function.

- **Parameters:**
  - `State<S, T> stateFunc`: The state function to map over.
  - `Func<T, U> mapper`: The mapping function.
- **Returns:** `State<S, U>` with the value transformed by `mapper`.

### Select `<S, T, U>`

LINQ compatible method to map over the state monad.

- **Parameters:**
  - `State<S, T> stateFunc`: The state function.
  - `Func<T, U> selector`: The selector function.
- **Returns:** `State<S, U>` resulting from the mapping.

### SelectMany `<S, T, U, V>`

LINQ compatible method that enables query syntax for state monads, allowing for the selection and combination of values.

- **Parameters:**
  - `State<S, T> stateFunc`: The initial state function.
  - `Func<T, State<S, U>> selector`: Function to select the next state.
  - `Func<T, U, V> resultSelector`: Function to combine results.
- **Returns:** `State<S, V>` as a result of the combination.

## Example Usage

```csharp
// Example of using StateMonad to carry out state transformations.
var initialState = 0;
var addOne = new State<int, int>(state => (state + 1, state));
var result = StateMonad.Bind(addOne, value => StateMonad.Return<int, int>(value * 2));

// Using the state monad to transform the initial state.
var (resultValue, newState) = result(initialState);
Console.WriteLine($"Result: {resultValue}, New State: {newState}");
```

This example demonstrates creating a simple state transformation that adds one to the initial state and then doubles the value, showcasing the use of `Bind` and `Return` methods of the `StateMonad` class.
