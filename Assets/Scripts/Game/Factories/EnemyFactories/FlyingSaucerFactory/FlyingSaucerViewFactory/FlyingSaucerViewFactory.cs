using Asteroids.Core.Settings;
using UnityEngine;

namespace Asteroids.Game.Factory
{
    public sealed class FlyingSaucerViewFactory : UiFactory, IFlyingSaucerViewFactory
    {
        [SerializeField] private FlyingSaucerView _prefab;

        public override UiFactoryType UiFactoryType => UiFactoryType.FlyingSaucerViewFactory;

        public IFlyingSaucerView Create()
        {
            var flyingSaucer = Instantiate(_prefab);

            return flyingSaucer;
        }
    }
}
