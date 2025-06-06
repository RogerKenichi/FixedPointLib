using Xunit;
using FixedPointLib;

public class FixedMathTests
{
    [Theory]
    [InlineData(2, 2, 4)]
    [InlineData(2, -3, 0.125)]
    [InlineData(3.5, 4, 150.0625)]
    public void Pow_ShouldCalculatePowerCorrectly(decimal baseValue, int expoent, decimal expected)
    {
        Fixed result = FixedMath.Pow(baseValue, expoent);
        Assert.Equal(Fixed.FromDecimal(expected), result);
    }

    [Theory]
    [InlineData(9, 3)]
    [InlineData(6.25, 2.5)]
    [InlineData(0, 0)]
    public void Sqrt_ShouldCalculateSqrtCorrectly(decimal baseValue, decimal expected)
    {
        Fixed result = FixedMath.Sqrt(baseValue);
        Assert.Equal(Fixed.FromDecimal(expected), result);
    }

    [Fact]
    public void Sqrt_ShouldThrowExceptionForNegativeValue()
    {
        Fixed a = Fixed.FromInt(-4);
        Assert.Throws<ArgumentOutOfRangeException>(() => FixedMath.Sqrt(a));
    }

    [Theory]
    [InlineData(12, 12)]
    [InlineData(-12, 12)]
    [InlineData(0, 0)]
    public void Abs_ShouldReturnAbsoluteValue(decimal baseValue, decimal expected)
    {
        Fixed result = FixedMath.Abs(baseValue);
        Assert.Equal(Fixed.FromDecimal(expected), result);
    }

    [Theory]
    [InlineData(3.999, 5.05, 3.999)]
    [InlineData(7.252, 2.333, 2.333)]
    [InlineData(4.586, 4.586, 4.586)]
    public void Min_ShouldReturnsMinValue(decimal a, decimal b, decimal expected)
    {
        Fixed result = FixedMath.Min(a, b);
        Assert.Equal(Fixed.FromDecimal(expected), result);
    }

    [Theory]
    [InlineData(3.999, 5.05, 5.05)]
    [InlineData(7.252, 2.333, 7.252)]
    [InlineData(4.586, 4.586, 4.586)]
    [InlineData(3.9999999, 4, 4)]
    public void Max_ShouldReturnsMaxValue(decimal a, decimal b, decimal expected)
    {
        Fixed result = FixedMath.Max(a, b);
        Assert.Equal(Fixed.FromDecimal(expected), result);
    }

    [Theory]
    [InlineData(-32.548, -16.32, -5.05, -16.32)]
    [InlineData(4.65, -16.32, -5.05, -5.05)]
    [InlineData(-8.65, -16.32, -5.05, -8.65)]
    [InlineData(-16.32, -16.32, -5.05, -16.32)]
    [InlineData(-5.05, -16.32, -5.05, -5.05)]
    public void Clamp_ShouldReturnClampedValue(decimal a, decimal min, decimal max, decimal expected)
    {
        var result = FixedMath.Clamp(a, min, max);
        Assert.Equal(Fixed.FromDecimal(expected), result);
    }

    [Theory]
    [InlineData(0.5, 0.5)]
    [InlineData(-0.5, 0)]
    [InlineData(1.5, 1)]
    public void Clamp01_ShouldReturnClamped01Value(decimal a, decimal expected)
    {
        Fixed result = FixedMath.Clamp01(a);
        Assert.Equal(Fixed.FromDecimal(expected), result);
    }

    [Fact]
    public void Lerp_ShouldClampBetweenTwoValues()
    {
        Fixed a = Fixed.FromInt(10);
        Fixed b = Fixed.FromInt(20);
        Fixed t = Fixed.FromDecimal(0.5m);

        Fixed result = FixedMath.Lerp(a, b, t);
        Assert.Equal(Fixed.FromInt(15), result);
    }

    [Fact]
    public void LerpUnclamped_ShouldAllowOutsideRange()
    {
        Fixed a = Fixed.FromInt(10);
        Fixed b = Fixed.FromInt(20);
        Fixed t = Fixed.FromDecimal(1.5m);

        Fixed result = FixedMath.LerpUnclamped(a, b, t);
        Assert.Equal(Fixed.FromInt(25), result);
    }
}
