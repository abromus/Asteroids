namespace Asteroids.Game
{
    public interface IUpdater
    {
        public void Add(IUpdatable updatable);

        public void Remove(IUpdatable updatable);

        public void Tick(float deltaTime);
    }
}
