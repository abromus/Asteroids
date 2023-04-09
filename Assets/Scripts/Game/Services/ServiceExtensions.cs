using System.Collections.Generic;
using System.Linq;
using Asteroids.Core.Services;
using Asteroids.Core.Settings;
using Asteroids.Game.Services;

namespace Asteroids.Game
{
    public static class ServiceExtensions
    {
        public static IInputSystem GetInputSystem(this IServiceStorage serviceStorage)
        {
            return serviceStorage.GetService<IInputSystem>();
        }

        public static IInputSystem GetInputSystem(this IReadOnlyList<IUiService> uiServices)
        {
            return uiServices.FirstOrDefault(service => service.UiServiceType == UiServiceType.InputSystem) as IInputSystem;
        }

        public static IScreenSystem GetScreenSystem(this IServiceStorage serviceStorage)
        {
            return serviceStorage.GetService<IScreenSystem>();
        }
    }
}
