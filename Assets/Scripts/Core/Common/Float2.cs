using System;
using System.Globalization;
using System.Runtime.CompilerServices;

namespace Asteroids.Core
{
    public struct Float2
    {
        public static Float2 Zero = new Float2(0f, 0f);

        public static Float2 Up = new Float2(0f, 1f);

        public float X { get; set; }

        public float Y { get; set; }

        public Float2(float x, float y)
        {
            X = x;
            Y = y;
        }

        public Float2(Float2 other)
        {
            X = other.X;
            Y = other.Y;
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static Float2 operator +(Float2 left, Float2 right)
        {
            return new Float2(left.X + right.X, left.Y + right.Y);
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static Float2 operator -(Float2 left, Float2 right)
        {
            return new Float2(left.X - right.X, left.Y - right.Y);
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static Float2 operator -(Float2 current)
        {
            return new Float2(0f - current.X, 0f - current.Y);
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static Float2 operator *(Float2 left, float right)
        {
            return new Float2(left.X * right, left.Y * right);
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static Float2 operator *(float left, Float2 right)
        {
            return new Float2(left * right.X, left * right.Y);
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static Float2 operator /(Float2 left, float right)
        {
            return new Float2(left.X / right, left.Y / right);
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static Float2 operator %(Float2 left, float right)
        {
            return new Float2(left.X % right, left.Y % right);
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static bool operator ==(Float2 left, Float2 right)
        {
            var deltaX = left.X - right.X;
            var deltaY = left.Y - right.Y;

            var result = deltaX * deltaX + deltaY * deltaY;

            return result < float.Epsilon;
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static bool operator !=(Float2 left, Float2 right)
        {
            return !(left == right);
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public override bool Equals(object other)
        {
            return other is Float2 value && Equals(value);
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public bool Equals(Float2 other)
        {
            return X == other.X && Y == other.Y;
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public override int GetHashCode()
        {
            return X.GetHashCode() ^ Y.GetHashCode();
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
                "({0}, {1})",
                X.ToString(format, formatProvider),
                Y.ToString(format, formatProvider));
        }
    }
}
