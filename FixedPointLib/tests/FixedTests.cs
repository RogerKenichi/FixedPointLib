using Xunit;
using FixedPointLib;

public class FixedTests
{
    [Fact]
    public void FromInt_ShouldCreateCorrectFixed()
    {
        Fixed fixedValue = Fixed.FromInt(5);
        Assert.Equal(5.0f, fixedValue.ToFloat(), 4);
    }

    [Fact]
    public void FromFloat_ShouldCreateCorrectFixed()
    {
        Fixed fixedValue = Fixed.FromFloat(3.1415f);
        Assert.InRange(fixedValue.ToFloat(), 3.1414f, 3.1416f);
    }

    [Fact]
    public void Addition_ShouldAddCorrectly()
    {
        Fixed a = Fixed.FromInt(5);
        Fixed b = Fixed.FromInt(10);
        Fixed result = a + b;

        Assert.Equal(15.0f, result.ToFloat(), 4);
    }

    [Fact]
    public void Subtraction_ShouldSubtractCorrectly()
    {
        Fixed a = Fixed.FromInt(10);
        Fixed b = Fixed.FromInt(5);
        Fixed result = a - b;

        Assert.Equal(5.0f, result.ToFloat(), 4);
    }

    [Fact]
    public void Multiplication_ShouldMultiplyCorrectly()
    {
        Fixed a = Fixed.FromFloat(1.5f);
        Fixed b = Fixed.FromFloat(2.0f);
        Fixed result = a * b;

        Assert.InRange(result.ToFloat(), 2.99f, 3.01f);
    }

    [Fact]
    public void Division_ShouldDivideCorrectly()
    {
        Fixed a = Fixed.FromFloat(3.0f);
        Fixed b = Fixed.FromFloat(1.5f);
        Fixed result = a / b;

        Assert.InRange(result.ToFloat(), 1.99f, 2.01f);
    }

    [Fact]
    public void Pow_ShouldCalculatePowerCorrectly()
    {
        Fixed a = Fixed.FromInt(2);
        Fixed result = Fixed.Pow(a, 3);

        Assert.Equal(8.0f, result.ToFloat(), 4);
    }

    [Fact]
    public void Pow_NegativeExponent_ShouldCalculateCorrectly()
    {
        Fixed a = Fixed.FromInt(2);
        Fixed result = Fixed.Pow(a, -3);

        Assert.InRange(result.ToFloat(), 0.124f, 0.126f);
    }

    [Fact]
    public void ImplicitConversion_ShouldWork()
    {
        Fixed a = 5;
        Fixed b = 2.5f;
        float sum = a + b;

        Assert.InRange(sum, 7.49f, 7.51f);
    }

    [Fact]
    public void ToString_ShouldFormatWith4DecimalPlaces()
    {
        Fixed a = Fixed.FromFloat(3.14159f);
        string s = a.ToString();

        Assert.Equal("3.1416", s);
    }
}
