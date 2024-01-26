### `Currency` Value Object Documentation

#### Overview

The `Currency` record struct in the `Functional.DotNet.ValueObject` namespace is designed to represent currency information in a structured and standardized format. It encapsulates both the currency code and the associated country, providing a clear and concise way to handle currency data.

#### Key Features and Usage

##### Constructor and Properties

- **Constructor**: Initializes a new instance of the `Currency` struct with a currency code and a corresponding `Country`.
- **`GetCode` Method**: Returns the currency code.
- **`GetCountry` Method**: Returns the associated `Country` instance.

##### Implicit Conversion from Tuple

- **Implicit Conversion**: Allows creating a `Currency` instance directly from a tuple containing a currency code and a `Country`.

##### Predefined Currency Instances

- **Predefined Currencies**: Includes static properties for commonly used currencies, each represented by their currency code and associated country.

##### Special Instances

- **`None`**: Represents a non-existent or undefined currency.

##### Deconstruction

- **`Deconstruct` Method**: Deconstructs the `Currency` instance into its currency code and associated country.

#### Summary

The `Currency` value object in the `Functional.DotNet` library provides a robust way to represent and handle currency data. Its integration with the `Country` type, coupled with easy-to-use constructors and predefined instances, makes it a versatile tool for applications dealing with financial, economic, or international data.
