using System;
using System.Globalization;
using System.Runtime.CompilerServices;

namespace Asteroids.Core
{
    public struct Float3
    {
        public static Float3 Zero = new Float3(0f, 0f, 0f);

        public float X { get; set; }

        public float Y { get; set; }

        public float Z { get; set; }

        public Float3(float x, float y, float z)
        {
            X = x;
            Y = y;
            Z = z;
        }

        public Float3(float x, float y) : this(x, y, 0f) { }

        public Float3(Float3 other)
        {
            X = other.X;
            Y = other.Y;
            Z = other.Z;
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static Float3 operator +(Float3 left, Float3 right)
        {
            return new Float3(left.X + right.X, left.Y + right.Y, left.Z + right.Z);
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static Float3 operator -(Float3 left, Float3 right)
        {
            return new Float3(left.X - right.X, left.Y - right.Y, left.Z - right.Z);
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static Float3 operator -(Float3 current)
        {
            return new Float3(0f - current.X, 0f - current.Y, 0f - current.Z);
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static Float3 operator *(Float3 left, float right)
        {
            return new Float3(left.X * right, left.Y * right, left.Z * right);
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static Float3 operator *(float left, Float3 right)
        {
            return new Float3(left * right.X, left * right.Y, left * right.Z);
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static Float3 operator /(Float3 left, float right)
        {
            return new Float3(left.X / right, left.Y / right, left.Z / right);
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static Float3 operator %(Float3 left, float right)
        {
            return new Float3(left.X % right, left.Y % right, left.Z % right);
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static bool operator ==(Float3 left, Float3 right)
        {
            var deltaX = left.X - right.X;
            var deltaY = left.Y - right.Y;
            var deltaZ = left.Z - right.Z;

            var result = deltaX * deltaX + deltaY * deltaY + deltaZ * deltaZ;

            return result < float.Epsilon;
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static bool operator !=(Float3 left, Float3 right)
        {
            return !(left == right);
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public override bool Equals(object other)
        {
            return other is Float3 value && Equals(value);
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public bool Equals(Float3 other)
        {
            return X == other.X && Y == other.Y && Z == other.Z;
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public override int GetHashCode()
        {
            return X.GetHashCode() ^ Y.GetHashCode() ^ Z.GetHashCode();
        }

        public override string ToString()
        {
            return ToString(null, null);
        }

        public string ToString(string format)
        {
            return ToString(format, null);
        }

        public string ToString(string format, IFormatProvider formatProvider)
        {
            if (string.IsNullOrEmpty(format))
                format = "F2";

            formatProvider ??= CultureInfo.InvariantCulture.NumberFormat;

            return string.Format(formatProvider,
                "({0}, {1}, {2})",
                X.ToString(format, formatProvider),
                Y.ToString(format, formatProvider),
                Z.ToString(format, formatProvider));
        }
    }
}
