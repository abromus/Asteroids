using System;

namespace Asteroids.Core
{
    public static class DelegateUtils
    {
        public static void SafeInvoke(this Action block)
        {
            block?.Invoke();
        }
    }
}
