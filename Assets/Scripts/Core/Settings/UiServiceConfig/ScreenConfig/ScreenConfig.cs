using System.Collections.Generic;
using UnityEngine;
using Screen = Asteroids.Core.Screens.Screen;

namespace Asteroids.Core.Settings
{
    [CreateAssetMenu(fileName = nameof(ScreenConfig), menuName = ConfigKeys.CorePathKey + nameof(ScreenConfig))]
    public sealed class ScreenConfig : ScriptableObject, IScreenConfig
    {
        [SerializeField] private List<Screen> _screens;

        public IReadOnlyList<Screen> Screens => _screens;
    }
}
