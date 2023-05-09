using Asteroids.Core.Settings;
using UnityEngine;

namespace Asteroids.Game.Factory
{
    public sealed class AsteroidViewFactory : UiFactory, IAsteroidViewFactory
    {
        [SerializeField] private AsteroidView _prefab;
        [SerializeField] private AsteroidFragmentView _fragmentPrefab;

        public override UiFactoryType UiFactoryType => UiFactoryType.AsteroidViewFactory;

        public IAsteroidView Create()
        {
            var asteroid = Instantiate(_prefab);

            return asteroid;
        }

        public IAsteroidFragmentView CreateFragment()
        {
            var asteroidFragment = Instantiate(_fragmentPrefab);

            return asteroidFragment;
        }

        public override void Destroy() { }
    }
}
