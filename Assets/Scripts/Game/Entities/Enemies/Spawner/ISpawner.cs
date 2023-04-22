namespace Asteroids.Game
{
    public interface ISpawner<T>
    {
        public T Spawn();

        public void Destroy();
    }
}
