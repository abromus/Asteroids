using System;

namespace Asteroids.Core
{
    public static class MathUtils
    {
        private static readonly Random _random;

        public const float FullAngle = 360f;

        public const float HalfAngle = FullAngle / 2f;

        public const float QuarterAngle = FullAngle / 4f;

        public const float Zero = 0f;

        public const float Deg2Rad = (float)Math.PI / 180f;

        public const float Rad2Deg = 180f / (float)Math.PI;

        public const float EpsilonNormalSqrt = 1E-15f;

        public static float Value => (float)_random.Next() / int.MaxValue;

        static MathUtils()
        {
            _random = new Random();
        }

        public static float CalculateAngle(Float3 first, Float3 second)
        {
            var dot = Dot(first, second);

            var firstMagnitude = Magnitude(first);
            var secondMagnitude = Magnitude(second);

            if (firstMagnitude == Zero || secondMagnitude == Zero)
                return Zero;

            var modules = firstMagnitude * secondMagnitude;

            if (modules == Zero || modules < EpsilonNormalSqrt)
                return Zero;

            var min = -1f;
            var max = 1f;
            var angle = Math.Clamp(dot / modules, min, max);
            var result = (float)Math.Acos(angle) * Rad2Deg;

            return result;
        }

        public static float Dot(Float3 first, Float3 second)
        {
            return first.X * second.X + first.Y * second.Y + first.Z * second.Z;
        }

        public static float Magnitude(Float3 value)
        {
            return (float)Math.Sqrt(value.X * value.X + value.Y * value.Y + value.Z * value.Z);
        }

        public static Float3 CalculateRotation(float angle, Float3 offset)
        {
            var eulerAngles = new UnityEngine.Vector3(Zero, Zero, angle % FullAngle);
            var delta = UnityEngine.Quaternion.Euler(eulerAngles);

            var rotation = (offset + delta.eulerAngles.ToFloat3()) % FullAngle;

            if (rotation.Z > HalfAngle)
                rotation.Z -= FullAngle;

            return rotation;
        }

        public static float Distance(Float3 first, Float3 second)
        {
            var deltaX = first.X - second.X;
            var deltaY = first.Y - second.Y;
            var deltaZ = first.Z - second.Z;
            var result = (float)Math.Sqrt(deltaX * deltaX + deltaY * deltaY + deltaZ * deltaZ);

            return result;
        }

        public static Float3 Rotate(Float3 centralPoint, Float3 pivot, float angle)
        {
            var radian = angle * UnityEngine.Mathf.Deg2Rad;
            var delta = pivot - centralPoint;

            var x = delta.X * Math.Cos(radian) - delta.Y * Math.Sin(radian);
            var y = delta.X * Math.Sin(radian) + delta.Y * Math.Cos(radian);
            var result = new Float3((float)x, (float)y);

            return result;
        }

        public static Float3 TransformDirection(float angle)
        {
            var radian = angle * Deg2Rad;
            var x = (float)Math.Sin(radian);
            var y = (float)Math.Cos(radian);

            if (Math.Abs(angle) <= HalfAngle)
                x = -x;

            var result = new Float3(x, y);

            return result;
        }

        public static float Inverse(float value)
        {
            var whole = 1f;
            var result = whole / value;

            return result;
        }

        public static Float3 CorrectPosition(Float3 original, Bounds bounds)
        {
            var x = original.X > bounds.Max.X
                ? original.X - bounds.Size.X
                : original.X < bounds.Min.X
                    ? original.X + bounds.Size.X
                    : original.X;

            var y = original.Y > bounds.Max.Y
                ? original.Y - bounds.Size.Y
                : original.Y < bounds.Min.Y
                    ? original.Y + bounds.Size.Y
                    : original.Y;

            var z = original.Z;

            var position = new Float3(x, y, z);

            return position;
        }
    }
}
