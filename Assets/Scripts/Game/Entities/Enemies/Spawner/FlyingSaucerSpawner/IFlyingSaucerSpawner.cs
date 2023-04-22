namespace Asteroids.Game
{
    public interface IFlyingSaucerSpawner<T> : ISpawner<T>, IUpdatable where T : IFlyingSaucerPresenter { }
}
