using UnityEngine;

namespace Asteroids.Core.Settings
{
    public abstract class UiService : MonoBehaviour, IUiService
    {
        public abstract UiServiceType UiServiceType { get; }
    }
}
