namespace Asteroids.Core.Services
{
    public interface IServiceStorage
    {
        public void AddService<TService>(TService service) where TService : class, IService;

        public TService GetService<TService>() where TService : class, IService;
    }
}
