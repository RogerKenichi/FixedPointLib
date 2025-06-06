# FixedPointLib - Simple Deterministic Fixed-Point Math for C#

A lightweight, dependency-free, and deterministic simple fixed-point number implementation in C#, which is ideal for physics simulations, multiplayer lockstep games, and other scenarios where floating-point inconsistencies across platforms must be avoided.

---

## ⚙️ How it works?

This library implements fixed-point arithmetic using a 16.16 (32-bit) representation (16 bits for the integer part and 16 bits for the fractional part). This ensures deterministic precision.

---

## 🔧 Features

- 16.16 (32 bits) fixed-point representation (`int`-based)
- Fast and deterministic basic arithmetic operations: `+`, `-`, `*`, `/`
- Implicit conversions:
    - From `int`, `float`, `decimal` and `string` to `Fixed`
    - From `Fixed` to `float` and `string`
- Automatic overflow checking on arithmetic operations
- Useful Fixed struct type constants: `ZERO`, `ONE` and `MINUS_ONE`
- Math class for mathematical operations
    - Includes methods `Pow`, `Sqrt`, `Abs`, `Min`, `Max`, `Clamp`, `Clamp01`, `Lerp` and `LerpUnclamped`
    - Includes constants for `π`, `2π`, `1/2 π`, `1/π`, `euler`, `ln2` and `ln10`
- Fully compatible with `.NET` and `Unity 3D` (no external dependencies)

---

## 📦 Installation

You can build and include the DLL in your project manually:

```bash
dotnet build -c Release
```
Copy the FixedPointLib.dll file from the FixedPointLib/bin/Release/net8.0/ folder and use where you need. Ignore all other folders and files, only the DLL file is needed.

**Note:** This lib was made with .NET 8.0.4

---

## 🧪 Unit Tests

Unit tests are included in FixedPointLib/tests/FixedTests.cs. In order to run the tests, restore the dependencies and run it with dotnet:

```bash
dotnet restore
dotnet test
```

---

## ⚠️ Limitations

Due to the 16.16 fixed-point format (32-bit), the `Fixed` type has the following limits:

| Type                      | Value                               |
|---------------------------|-------------------------------------|
| Maximum                   | `Fixed.MaxValue` = 32767.99998474...|
| Minimum                   | `Fixed.MinValue` = -32768.0         |
| Smallest increment        | 0.00001526... (1 / 2¹⁶)             |
| Approx. decimal precision | ~4 to 5 significant decimal digits  |

**Note:** Values exceeding these limits are automatically clamped to `Fixed.MaxValue` or `Fixed.MinValue`.

🛑 **If your use exceeds these values, this library is not recommended.**

---

## 📝 How to use it?

### Creating Fixed Values

```csharp
Fixed a = 5;           // Implicit from int
Fixed b = 3.25m;       // Implicit from decimal
Fixed c = Fixed.FromString("1.75");
Fixed d = Fixed.FromDecimal(0.125m);
```

### Arithmetic Operations

All operations are clamped to avoid overflow and maintain determinism.

It is highly recommended to use decimal values for fractional numbers instead of floats, to ensure deterministic behavior.

```csharp
Fixed a = 1.5m;           // m denotes decimal type value
Fixed b = 2;

Fixed sum = a + b;        // 3.5
Fixed diff = a - b;       // -0.5
Fixed product = a * b;    // 3
Fixed quotient = a / b;   // 0.75
```

**Note:** Division by zero throws `DivideByZeroException`.

### Conversion Between Types

```csharp
Fixed a = Fixed.FromDecimal(1.25m);
decimal dec = (decimal)a;

int raw = a.Raw; // Access raw 32-bit value
```

You can also convert from string:

```csharp
Fixed pi = Fixed.FromString("3.14159");
```

### Utility Methods

```csharp
Fixed pow = FixedMath.Pow(2, 4);                 // 16
Fixed sqrt = FixedMath.Sqrt(9);                  // 3
Fixed abs = FixedMath.Abs(-2.5m);                // 2.5
Fixed min = FixedMath.Min(3.1m, 5.4m);           // 3.1
Fixed max = FixedMath.Max(3.1m, 5.4m);           // 5.4
Fixed clamped = FixedMath.Clamp(5m, 0m, 1m);     // 1
Fixed clamped01 = FixedMath.Clamp(1.1m);         // 1
```

### Mathematical Constants

The following constants are predefined in `FixedMath` class:

```csharp
FixedMath.PI         // ≈ 3.14159 (π)
FixedMath.TWO_PI     // ≈ 6.28318 (2π)
FixedMath.HALF_PI    // ≈ 1.57079 ((1 / 2) π)
FixedMath.INV_PI     // ≈ 0.31830 (1 / π)
FixedMath.EULER      // ≈ 2.718282
FixedMath.LN2        // ≈ 0.69314
FixedMath.LN10       // ≈ 2.30258
```

These constants are stored using the best precision allowed by 16.16 format.

### Default Constants

The following constants are predefined in `Fixed` type:

```csharp
Fixed.ONE
Fixed.ZERO
Fixed.MINUS_ONE
Fixed.MAX
Fixed.MIN
```

These constants returns common values converted to `Fixed` type.

There is also two `int` types representing the maximum and minimum raw values:

```csharp
Fixed.MAX_RAW   // int.MaxValue
Fixed.MIN_RAW   // int.MinValue
```
