using Asteroids.Core.Services;

namespace Asteroids.Game.Services
{
    public interface IPositionCheckService : IService
    {
        public void AddDamagable(IDamagable damagable);

        public void AddDamaging(IDamaging damaging);

        public void RemoveDamagable(IDamagable damagable);

        public void RemoveDamaging(IDamaging damaging);
    }
}
