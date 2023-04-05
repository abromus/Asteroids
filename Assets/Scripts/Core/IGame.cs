using Asteroids.Core.Services;
using Asteroids.Core.Settings;

namespace Asteroids.Core
{
    public interface IGame
    {
        public IConfigStorage ConfigStorage { get; }

        public IServiceStorage ServiceStorage { get; }

        public void Destroy();
    }
}
