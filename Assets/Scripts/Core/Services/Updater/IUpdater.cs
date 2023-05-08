namespace Asteroids.Core.Services
{
    public interface IUpdater : IService
    {
        public void Add(IUpdatable updatable);

        public void Remove(IUpdatable updatable);

        public void Tick(float deltaTime);
    }
}
