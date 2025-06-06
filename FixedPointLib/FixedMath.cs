namespace FixedPointLib
{
    public readonly struct FixedMath
    {
        public static readonly Fixed PI = Fixed.FromDecimal(3.141593m);
        public readonly static Fixed TWO_PI = Fixed.FromDecimal(6.283185m);
        public readonly static Fixed HALF_PI = Fixed.FromDecimal(1.570796m);
        public static readonly Fixed INV_PI = Fixed.FromDecimal(0.318310m);
        public static readonly Fixed EULER = Fixed.FromDecimal(2.718282m);
        public static readonly Fixed LN2 = Fixed.FromDecimal(0.693147m);
        public static readonly Fixed LN10 = Fixed.FromDecimal(2.302585m); 

        // Exponentiation by squaring
        public static Fixed Pow(Fixed a, int b)
        {
            if (b == 0)
                return Fixed.ONE;

            Fixed result = Fixed.ONE;
            Fixed baseValue = a;
            int expoent = Math.Abs(b);

            while (expoent > 0)
            {
                if ((expoent & 1) == 1)
                    result *= baseValue;
                baseValue *= baseValue;
                expoent >>= 1;
            }

            return b < 0 ? Fixed.ONE / result : result;
        }

        // Newton-Raphson method
        public static Fixed Sqrt(Fixed a)
        {
            if (a < 0)
                throw new ArgumentOutOfRangeException("Cannot compute square root of a negative number");

            if (a.Raw == 0)
                return Fixed.ZERO;

            Fixed estimatedValue = a;
            Fixed lastValue;
            for (int i = 0; i < 6; i++)
            {
                lastValue = estimatedValue;
                estimatedValue = (estimatedValue + a / estimatedValue) / Fixed.FromInt(2);
                if (estimatedValue == lastValue)
                    break;
            }
            return estimatedValue;
        }

        public static Fixed Abs(Fixed a) => a.Raw < 0 ? new Fixed(-a.Raw) : a;

        public static Fixed Min(Fixed a, Fixed b) => a < b ? a : b;

        public static Fixed Max(Fixed a, Fixed b) => a > b ? a : b;

        public static Fixed Clamp(Fixed a, Fixed min, Fixed max)
        {
            if (a < min)
                return min;
            if (a > max)
                return max;
            return a;
        }

        public static Fixed Clamp01(Fixed a)
        {
            if (a > Fixed.ONE)
                return Fixed.ONE;
            if (a < Fixed.ZERO)
                return Fixed.ZERO;
            return a;
        }

        public static Fixed Lerp(Fixed a, Fixed b, Fixed t) => a + (b - a) * Clamp01(t);
        public static Fixed LerpUnclamped(Fixed a, Fixed b, Fixed t) => a + (b - a) * t;
    }
}
