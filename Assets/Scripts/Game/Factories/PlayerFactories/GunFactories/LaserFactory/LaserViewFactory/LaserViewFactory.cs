using Asteroids.Core.Settings;
using UnityEngine;

namespace Asteroids.Game.Factory
{
    public sealed class LaserViewFactory : UiFactory, ILaserViewFactory
    {
        [SerializeField] private LaserView _prefab;

        public override UiFactoryType UiFactoryType => UiFactoryType.LaserViewFactory;

        public ILaserView Create()
        {
            var laser = Instantiate(_prefab);

            return laser;
        }
    }
}
