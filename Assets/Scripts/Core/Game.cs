using Asteroids.Core.Services;
using Asteroids.Core.Settings;

namespace Asteroids.Core
{
    public sealed class Game : IGame
    {
        private readonly IConfigStorage _configStorage;
        private readonly IServiceStorage _serviceStorage;

        public IConfigStorage ConfigStorage => _configStorage;

        public IServiceStorage ServiceStorage => _serviceStorage;

        public Game(ICoroutineRunner coroutineRunner, IConfigStorage configStorage)
        {
            _configStorage = configStorage;

            _serviceStorage = new ServiceStorage(coroutineRunner, this, configStorage);
        }

        public void Destroy() { }
    }
}
