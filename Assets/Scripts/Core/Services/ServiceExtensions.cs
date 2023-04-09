namespace Asteroids.Core.Services
{
    public static class ServiceExtensions
    {
        public static IStateMachine GetStateMachine(this IServiceStorage serviceStorage)
        {
            return serviceStorage.GetService<IStateMachine>();
        }
    }
}
