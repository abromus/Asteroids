using UnityEngine;

namespace Asteroids.Core.Settings
{
    public abstract class UiFactory : MonoBehaviour, IUiFactory
    {
        public abstract UiFactoryType UiFactoryType { get; }

        public abstract void Destroy();
    }
}
