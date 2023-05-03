using UnityEngine;

namespace Asteroids.Core
{
    public static class UnityUtils
    {
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
