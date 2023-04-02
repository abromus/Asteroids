using UnityEngine;

namespace Asteroids.Settings
{
    public abstract class UiService : MonoBehaviour, IUiService
    {
        public abstract UiServiceType UiServiceType { get; }
    }
}
