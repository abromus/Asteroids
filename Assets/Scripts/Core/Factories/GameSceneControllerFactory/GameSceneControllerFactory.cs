using Asteroids.Core.Settings;
using UnityEngine;

namespace Asteroids.Core.Factories
{
    public sealed class GameSceneControllerFactory : UiFactory, IGameSceneControllerFactory
    {
        [SerializeField] private SceneController _gameSceneControllerPrefab;

        public override UiFactoryType UiFactoryType => UiFactoryType.GameSceneControllerFactory;

        public SceneController Create()
        {
            var gameController = Instantiate(_gameSceneControllerPrefab);

            return gameController;
        }
    }
}
