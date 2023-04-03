using System.Collections.Generic;
using UnityEngine;
using Screen = Asteroids.Screens.Screen;

namespace Asteroids.Settings
{
    [CreateAssetMenu(fileName = "ScreenConfig", menuName = "Settings/ScreenConfig")]
    public sealed class ScreenConfig : ScriptableObject, IScreenConfig
    {
        [SerializeField] private List<Screen> _screens;

        public IReadOnlyList<Screen> Screens => _screens;
    }
}
