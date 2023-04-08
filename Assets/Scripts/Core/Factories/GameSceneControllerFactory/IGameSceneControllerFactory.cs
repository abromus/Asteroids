namespace Asteroids.Core.Factories
{
    public interface IGameSceneControllerFactory : IFactory
    {
        public SceneController Create();
    }
}
