using System;
using Asteroids.Core;

namespace Asteroids.Game
{
    public sealed class Timer : ITimer
    {
        private float _seconds;
        private bool _isPaused;

        public bool IsElapsed => _seconds <= 0f;

        public Action<ITimer> Elapsed { get; set; }

        public Timer(float seconds = 0f)
        {
            UpdateTime(seconds);
        }

        public void Tick(float deltaTime)
        {
            if (_isPaused)
                return;

            _seconds -= deltaTime;

            if (_seconds <= 0f)
            {
                Elapsed.SafeInvoke(this);
                Elapsed = null;
            }
        }

        public void UpdateTime(float seconds)
        {
            _seconds = seconds;
        }

        public void Pause()
        {
            _isPaused = true;
        }

        public void Resume()
        {
            _isPaused = false;
        }
    }
}
