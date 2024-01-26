### `Money` Value Object Documentation

#### Overview

The `Money` record struct, part of the `Functional.DotNet.ValueObject` namespace, is specifically designed for financial calculations and representations. It combines a numerical amount with a `Currency` type, thus encapsulating all the essential aspects of monetary value in a single, coherent structure.

#### Key Features and Usage

##### Constructor and Factory Method

- **Constructor**: Initializes a new instance of the `Money` struct with a specified amount and currency.
```csharp
var money = new Money(Number.Create(100), Currency.USD);
```

- **`Create` Method**: A static factory method for creating a new `Money` instance from a given amount and currency.
```csharp
var money = Money.Create(Number.Create(50), Currency.EUR); 
```

##### Special Instances

- **`None`**: Represents a non-existent or undefined monetary value.
```csharp
var noMoney = Money.None; 
```

##### Properties and Methods

- **`GetAmount` Method**: Returns the numeric amount of the money.
```csharp
decimal amount = money.GetAmount();
```

- **`GetCurrency` Method**: Returns the `Currency` associated with the money.
```csharp
Currency currency = money.GetCurrency();
```

- **`Add` Method**: Adds two `Money` instances together, provided they are in the same currency.
```csharp
var sum = money.Add(new Money(Number.Create(30), Currency.USD));
```

- **`Subtract` Method**: Subtracts one `Money` instance from another, again requiring the same currency.
```csharp
var difference = money.Subtract(new Money(Number.Create(20), Currency.USD));
```

- **`ToString` Method**: Returns a string representation of the `Money` instance.
```csharp
 string str = money.ToString(); // "100 USD"
```

##### Currency Validation

- **Internal `ValidateCurrency` Method**: Ensures that operations on `Money` instances are performed only when they share the same currency.

##### Deconstruction

- **`Deconstruct` Method**: Deconstructs the `Money` instance into its constituent amount and currency.
```csharp
var (amount,currency) = Money.None;
```
#### Summary

The `Money` value object in the `Functional.DotNet` library offers a comprehensive solution for handling monetary values within applications. Its integration of amount and currency, coupled with operations like addition and subtraction, ensures accurate and meaningful financial computations. The `Money` type is ideal for applications that require robust financial data handling and manipulation.
