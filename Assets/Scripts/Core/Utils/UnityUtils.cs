﻿using UnityEngine;

namespace Asteroids.Core
{
    public static class UnityUtils
    {
        public static Float2 ToFloat2(this Vector2 value)
        {
            return new Float2(value.x, value.y);
        }

        public static Vector2 ToVector2(this Float2 value)
        {
            return new Vector2(value.X, value.Y);
        }

        public static Float3 ToFloat3(this Vector3 value)
        {
            return new Float3(value.x, value.y, value.z);
        }

        public static Vector3 ToVector3(this Float3 value)
        {
            return new Vector3(value.X, value.Y, value.Z);
        }
    }
}
