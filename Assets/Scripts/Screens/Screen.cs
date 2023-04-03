using UnityEngine;

namespace Asteroids.Screens
{
    public abstract class Screen : MonoBehaviour, IScreen
    {
        public abstract ScreenType ScreenType { get; }

        public abstract void Init(BaseOptions options = null);
    }
}
