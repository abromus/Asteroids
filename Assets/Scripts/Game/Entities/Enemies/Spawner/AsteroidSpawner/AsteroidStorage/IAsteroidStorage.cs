using System;
using Asteroids.Core;

namespace Asteroids.Game
{
    public interface IAsteroidStorage
    {
        public Action<Float3> AsteroidDestroyed { get; set; }

        public void Destroy();

        public IAsteroidPresenter SpawnAsteroid();

        public void Tick();
    }
}
