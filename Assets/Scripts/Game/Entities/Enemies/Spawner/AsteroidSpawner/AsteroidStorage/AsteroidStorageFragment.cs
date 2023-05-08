using System;
using System.Collections.Generic;
using Asteroids.Core;
using Asteroids.Game.Factory;
using Asteroids.Game.Services;

namespace Asteroids.Game
{
    public sealed class AsteroidStorageFragment : IAsteroidStorageFragment
    {
        private readonly IAsteroidFactory _factory;
        private readonly IPositionCheckService _positionCheckService;
        private readonly int _fragmentCount;

        private readonly IList<IAsteroidFragmentPresenter> _asteroidFragments;

        public Action AsteroidFragmentDestroyed { get; set; }

        public AsteroidStorageFragment(IAsteroidFactory factory, IPositionCheckService positionCheckService, int fragmentCount)
        {
            _factory = factory;
            _positionCheckService = positionCheckService;
            _fragmentCount = fragmentCount;

            _asteroidFragments = new List<IAsteroidFragmentPresenter>();
        }

        public void Tick()
        {
            for (int i = _asteroidFragments.Count - 1; i >= 0; i--)
            {
                var asteroidFragmentPresenter = _asteroidFragments[i];

                if (!asteroidFragmentPresenter.IsDestroyed)
                    continue;

                DestroyAsteroidFragment(asteroidFragmentPresenter);
            }
        }

        public void Destroy()
        {
            DestroyAsteroidFragments();
        }

        public void CreateAsteroidFragment(Float3 position)
        {
            for (int i = 0; i < _fragmentCount; i++)
            {
                var asteroidFragmentPresenter = _factory.CreateFragment();
                asteroidFragmentPresenter.Init(position);
                asteroidFragmentPresenter.Enable();

                _positionCheckService.AddDamagable(asteroidFragmentPresenter);
                _asteroidFragments.Add(asteroidFragmentPresenter);
            }
        }

        private void DestroyAsteroidFragment(IAsteroidFragmentPresenter asteroidFragmentPresenter)
        {
            asteroidFragmentPresenter.Disable();

            _asteroidFragments.Remove(asteroidFragmentPresenter);
            _positionCheckService.RemoveDamagable(asteroidFragmentPresenter);
            _factory.ReleaseFragment(asteroidFragmentPresenter);

            AsteroidFragmentDestroyed.SafeInvoke();
        }

        private void DestroyAsteroidFragments()
        {
            for (int i = _asteroidFragments.Count - 1; i >= 0; i--)
                DestroyAsteroidFragment(_asteroidFragments[i]);

            _asteroidFragments.Clear();

            AsteroidFragmentDestroyed = null;
        }
    }
}
