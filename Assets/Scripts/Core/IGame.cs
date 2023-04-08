namespace Asteroids.Core
{
    public interface IGame
    {
        public IGameData GameData { get; }

        public void Run();
    }
}
