using System.Collections.Generic;
using Asteroids.Screens;

namespace Asteroids.Settings
{
    public interface IScreenConfig : IConfig
    {
        public IReadOnlyList<Screen> Screens { get; }
    }
}
