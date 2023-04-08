using Asteroids.Core.Services;
using Asteroids.Game.Services;

namespace Asteroids.Game
{
    public static class ServiceExtensions
    {
        public static IScreenSystem GetScreenSystem(this IServiceStorage serviceStorage)
        {
            return serviceStorage.GetService<IScreenSystem>();
        }
    }
}
