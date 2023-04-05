using System.Collections.Generic;
using UnityEngine;

namespace Asteroids.Core.Settings
{
    [CreateAssetMenu(fileName = "UiServiceConfig", menuName = "Settings/UiServiceConfig")]
    public sealed class UiServiceConfig : ScriptableObject, IUiServiceConfig
    {
        [SerializeField] private List<UiService> _uiServices;

        public IReadOnlyList<IUiService> UiServices => _uiServices;
    }
}
