namespace Asteroids.Game
{
    public interface IDamagable
    {
        public bool IsDestroyed { get; }

        public void TakeDamage(IDamaging damaging);
    }
}
