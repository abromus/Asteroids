﻿using System.Collections.Generic;

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
            if (_timers.Contains(timer))
                _timers.Remove(timer);
        }

        public void Tick(float deltaTime)
        {
            foreach (var timer in _timers)
                if (!timer.IsPaused)
                    timer.Tick(deltaTime);
        }
    }
}