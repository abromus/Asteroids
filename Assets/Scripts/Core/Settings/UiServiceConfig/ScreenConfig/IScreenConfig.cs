using System.Collections.Generic;
using Asteroids.Core.Screens;

namespace Asteroids.Core.Settings
{
    public interface IScreenConfig : IConfig
    {
        public IReadOnlyList<Screen> Screens { get; }
    }
}
