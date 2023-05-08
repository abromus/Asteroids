using Asteroids.Core.Settings;
using UnityEngine;

namespace Asteroids.Game.Factory
{
    public sealed class BulletViewFactory : UiFactory, IBulletViewFactory
    {
        [SerializeField] private BulletView _prefab;

        public override UiFactoryType UiFactoryType => UiFactoryType.BulletViewFactory;

        public IBulletView Create()
        {
            var bullet = Instantiate(_prefab);

            return bullet;
        }
    }
}
