using Asteroids.Core.Settings;
using System.Collections.Generic;
using System.Linq;

namespace Asteroids.Core.Services
{
    public static class ServiceExtensions
    {
        public static IInputSystem GetInputSystem(this IServiceStorage serviceStorage)
        {
            return serviceStorage.GetService<IInputSystem>();
        }

        public static IStateMachine GetStateMachine(this IServiceStorage serviceStorage)
        {
            return serviceStorage.GetService<IStateMachine>();
        }

        public static IInputSystem GetInputSystem(this IReadOnlyList<IUiService> uiServices)
        {
            return uiServices.FirstOrDefault(service => service.UiServiceType == UiServiceType.InputSystem) as IInputSystem;
        }
    }
}
