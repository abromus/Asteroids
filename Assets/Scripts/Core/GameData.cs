using Asteroids.Core.Factories;
using Asteroids.Core.Services;
using Asteroids.Core.Settings;

namespace Asteroids.Core
{
    public sealed class GameData : IGameData
    {
        private readonly IConfigStorage _configStorage;
        private readonly IFactoryStorage _factoryStorage;
        private readonly IServiceStorage _serviceStorage;

        public IConfigStorage ConfigStorage => _configStorage;

        public IFactoryStorage FactoryStorage => _factoryStorage;

        public IServiceStorage ServiceStorage => _serviceStorage;

        public GameData(ICoroutineRunner coroutineRunner, IConfigStorage configStorage, IUpdater updater)
        {
            _configStorage = configStorage;

            _factoryStorage = new FactoryStorage(configStorage);

            _serviceStorage = new ServiceStorage(coroutineRunner, this, updater);
        }
    }
}
