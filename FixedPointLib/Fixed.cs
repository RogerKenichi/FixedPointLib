using System.Globalization;

namespace FixedPointLib
{
    public readonly struct Fixed
    {
        private const int FRACTIONAL_BITS = 16;
        private const int ONE_RAW = 1 << FRACTIONAL_BITS;
        private readonly int raw;
        public readonly static Fixed ZERO = FromInt(0);
        public readonly static Fixed ONE = FromInt(1);
        public readonly static Fixed MINUS_ONE = FromInt(-1);
        public readonly static int MAX_RAW = int.MaxValue;
        public readonly static int MIN_RAW = int.MinValue;
        public readonly static Fixed MAX = new Fixed(MAX_RAW).ToFloat();
        public readonly static Fixed MIN = new Fixed(MIN_RAW).ToFloat();
        internal int Raw => raw;

        public Fixed(int rawValue)
        {
            raw = rawValue;
        }

        public static Fixed FromFloat(float value) => new Fixed((int)(value * ONE_RAW));
        public static Fixed FromInt(int value) => new Fixed(value << FRACTIONAL_BITS);
        public static Fixed FromDecimal(decimal value) => new Fixed((int)(value * ONE_RAW));
        public static Fixed FromString(string value) => FromDecimal(decimal.Parse(value, CultureInfo.InvariantCulture));

        public float ToFloat() => (float)raw / ONE_RAW;

        public static implicit operator Fixed(int value) => FromInt(value);
        public static implicit operator Fixed(float value) => FromFloat(value);
        public static implicit operator Fixed(decimal value) => FromDecimal(value);
        public static implicit operator Fixed(string value) => FromString(value);

        public static implicit operator float(Fixed value) => value.ToFloat();

        public static Fixed operator +(Fixed a, Fixed b) => Saturate(a.raw + b.raw);
        public static Fixed operator -(Fixed a, Fixed b) => Saturate(a.raw - b.raw);
        public static Fixed operator *(Fixed a, Fixed b) => Saturate(((long)a.raw * b.raw) >> FRACTIONAL_BITS);
        public static Fixed operator /(Fixed a, Fixed b)
        {
            if (b.Raw == 0)
                throw new DivideByZeroException();
            return Saturate(((long)a.raw << FRACTIONAL_BITS) / b.raw);
        }

        public override string ToString() => ToFloat().ToString("F4", CultureInfo.InvariantCulture);

        private static Fixed Saturate(long value)
        {
            if (value > MAX_RAW)
                return new Fixed(MAX_RAW);
            if (value < MIN_RAW)
                return new Fixed(MIN_RAW);
            return new Fixed((int)value);
        }
    }
}
