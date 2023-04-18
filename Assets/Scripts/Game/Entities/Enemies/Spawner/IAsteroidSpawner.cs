namespace Asteroids.Game
{
    public interface IAsteroidSpawner<T> : ISpawner<T> where T : IAsteroidPresenter { }
}
