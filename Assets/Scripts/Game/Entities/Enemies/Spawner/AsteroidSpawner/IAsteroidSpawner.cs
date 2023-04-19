namespace Asteroids.Game
{
    public interface IAsteroidSpawner<T> : ISpawner<T>, IUpdatable where T : IAsteroidPresenter { }
}
