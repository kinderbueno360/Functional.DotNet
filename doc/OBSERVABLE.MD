# `Observable` Documentation

## Namespace

`Functional.DotNet.Extensions`

## Overview

The `ObservableExt` class provides extension methods for `IObservable<T>` to enhance functional programming with observables in .NET, particularly focusing on error handling and stream manipulation.

## Methods

### `Safely<T, R>`

Performs a Task-returning function `f` for each element `t` in the observable sequence `ts`, and partitions the results into two streams: one for successfully completed tasks and another for faults (exceptions).

- **Signature**:

  ```csharp
  public static (IObservable<R> Completed, IObservable<Exception> Faulted) Safely<T, R>(this IObservable<T> ts, Func<T, Task<R>> f)
  ```

- **Parameters**:

  - `ts`: The input observable sequence.
  - `f`: A function that returns a `Task<R>` when applied to an element of `ts`.

- **Returns**: A tuple containing two observables:
  - `Completed`: An `IObservable<R>` stream of successfully completed tasks.
  - `Faulted`: An `IObservable<Exception>` stream of tasks that resulted in exceptions.

### `Partition<T>`

Partitions an observable sequence of `Exceptional<T>` into two streams based on the success or failure encapsulated by the `Exceptional` instances.

- **Signature**:

  ```csharp
  public static (IObservable<T> Successes, IObservable<Exception> Exceptions) Partition<T>(this IObservable<Exceptional<T>> excTs)
  ```

- **Parameters**:

  - `excTs`: The input observable sequence of `Exceptional<T>`.

- **Returns**: A tuple containing two observables:
  - `Successes`: An `IObservable<T>` stream of successful values.
  - `Exceptions`: An `IObservable<Exception>` stream of exceptions.

### `Partition<T, bool>`

Overload of `Partition` that segregates elements based on a predicate.

- **Signature**:
  ```csharp
  public static (IObservable<T> Passed, IObservable<T> Failed) Partition<T>(this IObservable<T> source, Func<T, bool> predicate)
  ```

### `Partition<T, RTrue, RFalse>`

Another overload of `Partition` that allows transforming elements based on a predicate into two different types.

- **Signature**:
  ```csharp
  public static (IObservable<RTrue> Passed, IObservable<RFalse> Failed) Partition<T, RTrue, RFalse>(this IObservable<T> source, Func<T, bool> If, Func<T, RTrue> Then, Func<T, RFalse> Else)
  ```

### `PairWithPrevious<T>`

Pairs each element in the observable sequence with its previous element.

- **Signature**:
  ```csharp
  public static IObservable<(T Previous, T Current)> PairWithPrevious<T>(this IObservable<T> source)
  ```

## Usage Examples

Given the nature of these methods, they are particularly useful in scenarios involving asynchronous data streams where error handling and data partitioning are crucial.

For instance, `Safely` can be used to process a stream of URLs to fetch data asynchronously, partitioning the results into successful fetches and errors without crashing the entire stream processing.

## Conclusion

`ObservableExt` enriches the `IObservable<T>` with additional functional programming capabilities, making it easier to handle complex scenarios involving asynchronous streams and error handling in a more functional and expressive manner.
