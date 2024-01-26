### `Email` Value Object Documentation

#### Overview

The `Email` record struct, part of the `Functional.DotNet.ValueObject` namespace, is designed to encapsulate and handle email address data efficiently. It breaks down the email address into its constituent parts: local part and domain, providing a structured way to work with email addresses.

#### Key Features and Usage

##### Constructors and Factory Methods

- **Email Constructor**: Initializes a new instance of the `Email` struct with the local part and domain of the email address.
```csharp
  var email = new Email("localPart", "domain.com");
```

- **`Create` Method**: A factory method to create a new `Email` instance.
```csharp
var email = Email.Create("localPart", "domain.com");
```


##### Properties and Methods

- **`Address` Property**: Composes and returns the full email address as a string. If the local part is empty, it returns an empty string.
```csharp
string emailAddress = email.Address; // "localPart@domain.com"
```

- **`Deconstruct` Method**: Deconstructs the `Email` instance into its local part and domain.
```csharp
var email = new Email("localPart", "domain.com");
var (localPart, domain) = email;
```

- **`IsValid` Static Method**: Validates the format of an email address.
```csharp
bool isValid = Email.IsValid("localPart@domain.com");
```

##### Implicit and Explicit Operators

- **Implicit Conversion from String**: Allows creating an `Email` instance directly from a string representing an email address, provided it is in a valid format.
```csharp
Email emailFromString = "localPart@domain.com";
```
- **Explicit Conversion to Tuple**: Enables explicit conversion of an `Email` instance to a tuple containing the local part and domain as strings.
```csharp
var (local, domain) = (string LocalPart, string Domain)email;
```
##### Special Instances

- **`None`**: Represents a non-existent or undefined email address.
```csharp
var emptyEmail = Email.None;
```

#### Summary

The `Email` value object in the `Functional.DotNet` library offers a structured and reliable way to handle email address data. Its ability to parse and validate email addresses, coupled with convenient constructors and conversion operators, makes it an indispensable tool for applications requiring email data manipulation and validation.
