using Asteroids.Core.Factories;
using Asteroids.Core.Services;
using Asteroids.Core.Settings;

namespace Asteroids.Core
{
    public interface IGameData
    {
        public IConfigStorage ConfigStorage { get; }

        public IFactoryStorage FactoryStorage { get; }

        public IServiceStorage ServiceStorage { get; }

        public void Destroy();
    }
}
