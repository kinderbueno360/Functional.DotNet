### `Number` Value Object Documentation

#### Overview

The `Number` type in the `Functional.DotNet.ValueObject` namespace is an advanced construct designed to encapsulate numeric values. A key feature of this type is its ability to implicitly parse to various numeric types, greatly simplifying conversions and operations involving different numeric formats.

####  Key Methods and Their Use

#### `Create`
- **Purpose**: Provides static methods to create a Number instance from various numeric types, such as ulong, decimal, uint, int, Int64, and double.
- **Usage Example**:
```csharp
Number numberFromDecimal = Number.Create(123.45m); // Creating from decimal
Number numberFromInt = Number.Create(42);          // Creating from int
```

#### JSON Serialization

- **Details**: The `Number` type is marked with a `JsonConverter` attribute, utilizing `NumberJsonConverter` for JSON serialization and deserialization.
- **Usage Example**:
```csharp
PROGRAM.CS

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddControllers().AddJsonOptions(options =>
{
    options.JsonSerializerOptions.Converters.Add(new NumberJsonConverter());
});

// ... rest of the code for configuring the app          // Creating from int
```

#### Implicit Parsing to Numeric Types

This functionality allows for seamless conversion and interaction between `Number` and other standard numeric types in C#. It supports implicit parsing from and to types like `int`, `double`, `decimal`, `ulong`, and more.
- **Usage Example**:
```csharp
Number numberFromInt = 42;              // Implicitly parsed from int
double doubleValue = numberFromInt;     // Implicitly converts to double
decimal decimalValue = numberFromInt;   // Implicitly converts to decimal
```

#### `Bind` and `Map` Methods

- **Bind**: Used for chaining operations involving `Number`. It is ideal for sequences of dependent operations.
- **Usage Example**:
```csharp
static int MultiplyBy2(Number value) => value * 2;
static int Add5(Number value) => value 5;

Number initialNumber = Number.Create(10);
Number result = initialNumber
                    .Bind(MultiplyBy2)
                    .Bind(Add5);
// result is Number containing 25 (10 * 2 + 5)

```

- **Map**: Applies a transformation to the `Number`, altering its value while maintaining the structural integrity. It is best used for straightforward, guaranteed transformations.
- **Usage Example**:
```csharp
static int Double(Number value) => value * 2;

Number number = Number.Create(5);

Number doubledNumber = number.Map(n => n * 2);
// doubledNumber is Number containing 10 (5 * 2)

Number doubledNumberUsingFunc = number.Map(Double);
// doubledNumber is Number containing 10 (5 * 2)

```

#### Summary

The `Number` type in `Functional.DotNet` enhances numerical data handling in functional programming by offering implicit type conversion and functional methods like `Bind` and `Map`. These features contribute to more readable, maintainable
