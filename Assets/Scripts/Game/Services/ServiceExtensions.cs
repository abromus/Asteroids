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
            return uiServices.GetService<IInputSystem>(UiServiceType.InputSystem);
        }

        public static IPositionCheckService GetPositionCheckService(this IServiceStorage serviceStorage)
        {
            return serviceStorage.GetService<IPositionCheckService>();
        }

        public static IScreenSystem GetScreenSystem(this IServiceStorage serviceStorage)
        {
            return serviceStorage.GetService<IScreenSystem>();
        }

        public static IScreenSystem GetScreenSystem(this IReadOnlyList<IUiService> uiServices)
        {
            return uiServices.GetService<IScreenSystem>(UiServiceType.ScreenSystem);
        }

        public static ITimerService GetTimerService(this IServiceStorage serviceStorage)
        {
            return serviceStorage.GetService<ITimerService>();
        }

        private static TService GetService<TService>(this IReadOnlyList<IUiService> uiServices, UiServiceType serviceType)
            where TService : class, IService
        {
            return uiServices.FirstOrDefault(service => service.UiServiceType == serviceType) as TService;
        }
    }
}
