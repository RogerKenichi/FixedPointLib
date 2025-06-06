using System.Globalization;

namespace FixedPointLib
{
    public readonly struct Fixed
    {
        private const int FRACTIONAL_BITS = 16;
        private const int ONE_RAW = 1 << FRACTIONAL_BITS;
        private readonly int raw;
        internal int Raw => raw;

        public Fixed(int rawValue)
        {
            raw = rawValue;
        }

        public static Fixed FromFloat(float value) => new Fixed((int)(value * ONE_RAW));
        public static Fixed FromInt(int value) => new Fixed(value << FRACTIONAL_BITS);
        public float ToFloat() => (float)raw / ONE_RAW;

        public static implicit operator Fixed(int value) => FromInt(value);
        public static implicit operator Fixed(float value) => FromFloat(value);
        public static implicit operator float(Fixed value) => value.ToFloat();

        public static Fixed operator +(Fixed a, Fixed b) => new Fixed(a.raw + b.raw);
        public static Fixed operator - (Fixed a, Fixed b) => new Fixed(a.raw - b.raw);
        public static Fixed operator * (Fixed a, Fixed b) => new Fixed((int)(((long)a.raw * b.raw) >> FRACTIONAL_BITS));
        public static Fixed operator /(Fixed a, Fixed b) => new Fixed((int)(((long)a.raw << FRACTIONAL_BITS) / b.raw));

        public static Fixed Pow(Fixed a, int b)
        {
            if (b == 0)
                return FromInt(1);

            Fixed result = FromInt(1);
            Fixed baseValue = a;
            int expoent = Math.Abs(b);

            while (expoent > 0)
            {
                if ((expoent & 1) == 1)
                    result *= baseValue;
                baseValue *= baseValue;
                expoent >>= 1;
            }

            return b < 0 ? FromInt(1) / result : result;
        }

        public override string ToString() => ToFloat().ToString("F4", CultureInfo.InvariantCulture);
    }
}
