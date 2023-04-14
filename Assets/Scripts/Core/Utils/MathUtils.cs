using System;
using UnityEngine;

namespace Asteroids.Core
{
    public static class MathUtils
    {
        public const float FullAngle = 360f;

        public const float HalfAngle = FullAngle / 2f;

        public const float QuarterAngle = FullAngle / 4f;

        public static Float3 CalculateRotation(float angle, Float3 offset)
        {
            var eulerAngles = new Vector3(0f, 0f, angle);
            var delta = Quaternion.Euler(eulerAngles);

            var rotation = (offset + delta.eulerAngles.ToFloat3()) % FullAngle;

            if (rotation.Z >= HalfAngle)
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
            var radian = angle * Mathf.Deg2Rad;
            var delta = pivot - centralPoint;

            var x = delta.X * Mathf.Cos(radian) - delta.Y * Mathf.Sin(radian);
            var y = delta.X * Mathf.Sin(radian) + delta.Y * Mathf.Cos(radian);
            var result = new Float3(x, y);

            return result;
        }

        public static Float3 TransformDirection(float angle)
        {
            var radian = angle * Mathf.Deg2Rad;
            var x = Mathf.Sin(radian);
            var y = Mathf.Cos(radian);

            if (Mathf.Abs(angle) <= HalfAngle)
                x = -x;

            var result = new Float3(x, y);

            return result;
        }

        public static Float2 ToFloat2(this Float3 value)
        {
            return new Float2(value.X, value.Y);
        }

        public static Float3 ToFloat3(this Float2 value)
        {
            return new Float3(value.X, value.Y);
        }
    }
}
