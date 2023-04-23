using System.Collections.Generic;
using Asteroids.Core;

namespace Asteroids.Game.Services
{
    public sealed class PositionCheckService : IPositionCheckService, IUpdatable
    {
        private readonly IList<IDamagable> _damagables;
        private readonly IList<IDamaging> _damagings;

        private readonly float epsilon = 0.5f;

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
            for (int i = 0; i < _damagings.Count; i++)
            {
                var damaging = _damagings[i];

                if (damaging.IsDestroyed)
                    continue;

                for (int j = 0; j < _damagables.Count; j++)
                {
                    var damagable = _damagables[j];
                    var needDestroy = IsNeedDestroy(damaging, damagable);

                    if (!needDestroy)
                        continue;

                    damagable.TakeDamage(damaging);
                    damaging.Destroy();
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

            return distance <= epsilon;
        }
    }
}
