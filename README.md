# FixedPointLib - Simple Deterministic Fixed-Point Math for C#

A lightweight, dependency-free, and deterministic fixed-point number implementation in C# — ideal for physics simulations, multiplayer lockstep games, and any scenario where floating-point inconsistencies across platforms must be avoided.

---

## 🔧 Features

- 16.16 fixed-point representation (`int`-based)
- Fast and deterministic arithmetic operations
- Implicit conversions to/from `int` and `float`
- Safe for use in Unity or headless server logic
- Method `Pow` included for exponentiation with an integer exponent
- Fully compatible with `.NET` and `Unity` (no external dependencies)

---

## 📦 Installation

You can build and include the DLL in your project manually:

```bash
dotnet build -c Release
```
Copy the FixedPointLib.dll file from the FixedPointLib/bin/Release/net8.0/ folder and use where you need. Ignore all other folders and files, only the DLL file is needed.


## 🧪 Unit Tests

Unit tests are included in FixedPointLib/tests/FixedTests.cs. In order to run the tests, restore the dependencies and run it with dotnet:

```bash
dotnet restore
dotnet test
```
