### `StringNumber` Value Object Documentation

#### Overview

The `StringNumber` type, part of the `Functional.DotNet.ValueObject` namespace, is a functional construct designed to handle numeric values represented as strings. It provides a method to create a `StringNumber` from a string value, applying necessary formatting and conversions. This type is enriched with several methods to provide functional programming capabilities, such as handling optional values, transformations, and pattern matching.

####  Key Methods and Their Use

#### `Create`
- **Purpose**: Converts a string representation of a number into a `StringNumber` instance. This includes removing formatting and converting to a decimal type..
- **Usage Example**:
```csharp
StringNumber stringNumber = StringNumber.Create("12345.67");

```

##### `IsSome` and `IsNone`

- **Purpose**: Determine whether the `StringNumber` instance represents a valid (Some) or invalid/absent (None) value.
- **Usage Example**:
```csharp
StringNumber maybeNumber = StringNumber.Create("123");
bool hasValue = maybeNumber.IsSome;  // true if valid number
bool isAbsent = maybeNumber.IsNone;  // false if valid number
```

##### `Match`

- **Purpose**: Perform pattern matching, allowing different actions based on the state (Some or None) of the `StringNumber`.
- **Usage Example**:

```csharp
StringNumber maybeNumber = StringNumber.Create("456");
string result = maybeNumber.Match(
    Some: num => $"Number is: {num}",
    None: () => "No valid number"
);
```

##### `Map`

- **Purpose**: Transform the `StringNumber` value if it is valid (Some).
- **Usage Example**:

```csharp
StringNumber maybeNumber = StringNumber.Create("789");
StringNumber transformed = maybeNumber.Map(num => num * 2);  // Assuming it multiplies the number
```

##### `ToOption`

- **Purpose**: Convert the `StringNumber` to an `Option` type, representing the presence or absence of a value.
- **Usage Example**:

```csharp
StringNumber maybeNumber = StringNumber.Create("1011");
Option<StringNumber> optionNumber = maybeNumber.ToOption();
```

##### `ToString`

- **Purpose**: Get the string representation of the `StringNumber`.
- **Usage Example**:

```csharp
StringNumber maybeNumber = StringNumber.Create("1213");
string stringValue = maybeNumber.ToString();
```

##### `GetOrElse`

- **Purpose**: Provide a fallback value if the `StringNumber` is None.
- **Usage Example**:

```csharp
StringNumber maybeNumber = StringNumber.Create(null);
StringNumber fallbackNumber = maybeNumber.GetOrElse("0");
```


#### JSON Serialization

- **Details**: The `StringNumber` type is marked with a `JsonConverter` attribute, utilizing `StringNumberJsonConverter` for JSON serialization and deserialization.
- **Usage Example**:
```csharp
PROGRAM.CS

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddControllers().AddJsonOptions(options =>
{
    options.JsonSerializerOptions.Converters.Add(new StringNumberJsonConverter());
});

// ... rest of the code for configuring the app          // Creating from int
```


#### Implicit Parsing

The `StringNumber` type allows for implicit conversions from and to standard numeric types. This facilitates seamless integration with other numeric types in C#, simplifying operations and conversions.

- **Usage Example**:
```csharp
// Implicit conversion from string to StringNumber
StringNumber numberFromString = "123.45";

// Implicit conversion from StringNumber to decimal
decimal decimalValue = numberFromString;

// Implicit conversion from StringNumber to int (assuming it can handle such conversions)
int intValue = numberFromString;
```

#### Summary

The `StringNumber` type, with its comprehensive set of methods, enhances the handling of numeric values in string format. The availability of methods like `IsSome`, `IsNone`, `Match`, `Map`, `ToOption`, `ToString`, and `GetOrElse` makes it a versatile tool in functional programming, allowing for more expressive and safe manipulation of potentially absent or invalid numeric data.