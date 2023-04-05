using System.Collections.Generic;
using UnityEngine;

namespace Asteroids.Core.Settings
{
    [CreateAssetMenu(fileName = "UiFactoryConfig", menuName = "Settings/UiFactoryConfig")]
    public sealed class UiFactoryConfig : ScriptableObject, IUiFactoryConfig
    {
        [SerializeField] private List<UiFactory> _uiFactories;

        public IReadOnlyList<IUiFactory> UiFactories => _uiFactories;
    }
}
