using System;
using Asteroids.Core;

namespace Asteroids.Game
{
    public interface IAsteroidSpawner<T> : ISpawner<T>, IUpdatable where T : IAsteroidPresenter
    {
        public Action AsteroidDestroyed { get; set; }

        public Action AsteroidFragmentDestroyed { get; set; }
    }
}
