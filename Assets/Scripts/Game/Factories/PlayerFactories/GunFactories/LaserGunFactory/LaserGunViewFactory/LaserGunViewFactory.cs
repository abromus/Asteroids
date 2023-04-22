using Asteroids.Core.Settings;
using UnityEngine;

namespace Asteroids.Game.Factory
{
    public sealed class LaserGunViewFactory : UiFactory, ILaserGunViewFactory
    {
        [SerializeField] private LaserGunView _prefab;

        public override UiFactoryType UiFactoryType => UiFactoryType.LaserGunViewFactory;

        public ILaserGunView Create()
        {
            var laserGun = Instantiate(_prefab);
            laserGun.Init();

            return laserGun;
        }
    }
}
