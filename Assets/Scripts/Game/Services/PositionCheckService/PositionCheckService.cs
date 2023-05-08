using System.Collections.Generic;
using Asteroids.Core;

namespace Asteroids.Game.Services
{
    public sealed class PositionCheckService : IPositionCheckService, IUpdatable
    {
        private const float Epsilon = 0.5f;

        private readonly IList<IDamagable> _damagables;
        private readonly IList<IDamaging> _damagings;

        public PositionCheckService()
        {
            _damagables = new List<IDamagable>();
            _damagings = new List<IDamaging>();
        }

        public void AddDamagable(IDamagable damagable)
        {
            _damagables.Add(damagable);
        }

        public void AddDamaging(IDamaging damaging)
        {
            _damagings.Add(damaging);
        }

        public void RemoveDamagable(IDamagable damagable)
        {
            if (_damagables.Contains(damagable))
                _damagables.Remove(damagable);
        }

        public void RemoveDamaging(IDamaging damaging)
        {
            if (_damagings.Contains(damaging))
                _damagings.Remove(damaging);
        }

        public void Tick(float deltaTime)
        {
            for (int i = _damagings.Count - 1; i >= 0; i--)
            {
                var damaging = _damagings[i];

                if (damaging.IsDestroyed)
                {
                    continue;
                }

                for (int j = _damagables.Count - 1; j >= 0; j--)
                {
                    var damagable = _damagables[j];
                    var needDestroy = IsNeedDestroy(damaging, damagable);

                    if (!needDestroy)
                        continue;

                    damagable.TakeDamage(damaging);
                    damaging.Destroy();

                    _damagables.Remove(damagable);
                    _damagings.Remove(damaging);

                    break;
                }
            }
        }

        private bool IsNeedDestroy(IDamaging damaging, IDamagable damagable)
        {
            if (damaging == damagable || damagable.IsDestroyed)
                return false;

            var damagingPresenter = damaging as IPresenter;
            var damagablePresenter = damagable as IPresenter;
            var distance = MathUtils.Distance(damagingPresenter.Position, damagablePresenter.Position);

            return distance <= Epsilon;
        }
    }
}
