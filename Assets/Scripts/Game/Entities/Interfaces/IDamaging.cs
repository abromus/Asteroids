namespace Asteroids.Game
{
    public interface IDamaging
    {
        public bool IsDestroyed { get; }

        public void Destroy();
    }
}
