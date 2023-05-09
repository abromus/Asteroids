using System.Collections.Generic;
using Asteroids.Core;

namespace Asteroids.Game.Services
{
    public sealed class TimerService : ITimerService, IUpdatable
    {
        private IList<ITimer> _timers;

        public TimerService()
        {
            _timers = new List<ITimer>();
        }

        public void Destroy()
        {
            for (int i = _timers.Count - 1; i >= 0; i--)
                RemoveTimer(_timers[i]);

            _timers.Clear();
            _timers = null;
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

            if (_timers != null && _timers.Contains(timer))
                _timers.Remove(timer);
        }

        public void Tick(float deltaTime)
        {
            for (int i = 0; i < _timers.Count; i++)
                _timers[i].Tick(deltaTime);
        }
    }
}
