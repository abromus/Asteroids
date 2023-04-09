using Asteroids.Core.Settings;
using UnityEngine;

namespace Asteroids.Game.Factory
{
    public sealed class AsteroidViewFactory : UiFactory, IAsteroidViewFactory
    {
        [SerializeField] private AsteroidView _prefab;

        public override UiFactoryType UiFactoryType => UiFactoryType.AsteroidViewFactory;

        public AsteroidView Create()
        {
            var asteroid = Instantiate(_prefab);
            asteroid.Init();

            return asteroid;
        }
    }
}
