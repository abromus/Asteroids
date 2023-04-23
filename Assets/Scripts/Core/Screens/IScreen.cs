using System;

namespace Asteroids.Core.Screens
{
    public interface IScreen : IUpdatable
    {
        public ScreenType ScreenType { get; }

        public Action<IScreen> Closed { get; set; }

        public void Init(Options options);
    }
}
