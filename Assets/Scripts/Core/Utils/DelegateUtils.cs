using System;

namespace Asteroids.Core
{
    public static class DelegateUtils
    {
        public static void SafeInvoke(this Action block)
        {
            block?.Invoke();
        }

        public static void SafeInvoke<T>(this Action<T> block, T value)
        {
            block?.Invoke(value);
        }
    }
}
