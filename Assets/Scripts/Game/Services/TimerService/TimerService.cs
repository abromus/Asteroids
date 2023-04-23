using System.Collections.Generic;
using Asteroids.Core;

namespace Asteroids.Game.Services
{
    public sealed class TimerService : ITimerService, IUpdatable
    {
        private readonly IList<ITimer> _timers;

        public TimerService()
        {
            _timers = new List<ITimer>();
        }

        public ITimer CreateTimer(float seconds = 0f)
        {
            var timer = new Timer(seconds);

            _timers.Add(timer);

            return timer;
        }

        public void RemoveTimer(ITimer timer)
        {
            timer.Destroy();

            if (_timers.Contains(timer))
                _timers.Remove(timer);
        }

        public void Tick(float deltaTime)
        {
            for (int i = 0; i < _timers.Count; i++)
                _timers[i].Tick(deltaTime);
        }
    }
}
