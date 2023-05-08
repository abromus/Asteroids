using System;
using Asteroids.Core;

namespace Asteroids.Game
{
    public interface IAsteroidStorageFragment
    {
        public Action AsteroidFragmentDestroyed { get; set; }

        public void CreateAsteroidFragment(Float3 position);

        public void Destroy();

        public void Tick();
    }
}
