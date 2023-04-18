using Asteroids.Core.Services;

namespace Asteroids.Game.Services
{
    public interface ITimerService : IService
    {
        public ITimer CreateTimer(float seconds = 0f);

        public void RemoveTimer(ITimer timer);
    }
}
