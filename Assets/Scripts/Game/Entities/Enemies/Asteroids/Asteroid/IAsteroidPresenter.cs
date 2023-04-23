using System;
using Asteroids.Core;

namespace Asteroids.Game
{
    public interface IAsteroidPresenter : IPresenter, IPoolable, IDamagable
    {
        public Action<IAsteroidPresenter> Destroyed { get; set; }

        public void Init(Float3 position);
    }
}
