using UnityEngine;

namespace Asteroids.Core.Screens
{
    public abstract class Screen : MonoBehaviour, IScreen
    {
        public abstract ScreenType ScreenType { get; }

        public abstract void Init(Options options = null);
    }
}
