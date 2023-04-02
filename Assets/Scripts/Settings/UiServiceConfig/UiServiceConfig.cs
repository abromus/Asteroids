using System.Collections.Generic;
using UnityEngine;

namespace Asteroids.Settings
{
    [CreateAssetMenu(fileName = "UiServiceConfig", menuName = "Settings/UiServiceConfig")]
    public sealed class UiServiceConfig : ScriptableObject, IUiServiceConfig
    {
        [SerializeField] private List<UiService> _uiService;

        public IReadOnlyList<IUiService> UiServices => _uiService;
    }
}
