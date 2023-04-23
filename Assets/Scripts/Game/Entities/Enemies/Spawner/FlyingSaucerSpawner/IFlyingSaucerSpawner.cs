using System;
using Asteroids.Core;

namespace Asteroids.Game
{
    public interface IFlyingSaucerSpawner<T> : ISpawner<T>, IUpdatable where T : IFlyingSaucerPresenter
    {
        public Action FlyingSaucerDestroyed { get; set; }
    }
}
