using System;
using Asteroids.Core;

namespace Asteroids.Game
{
    public sealed class Timer : ITimer
    {
        private const float ZeroSeconds = 0f;

        private float _seconds;
        private bool _isPaused;

        public bool IsElapsed => _seconds <= ZeroSeconds;

        public float TimeLeft => _seconds;

        public Action<ITimer> Elapsed { get; set; }

        public Timer(float seconds = ZeroSeconds)
        {
            UpdateTime(seconds);
        }

        public void Tick(float deltaTime)
        {
            if (_isPaused)
            {
                return;
            }

            _seconds -= deltaTime;

            if (_seconds <= ZeroSeconds)
            {
                _seconds = ZeroSeconds;
                _isPaused = true;
                Elapsed.SafeInvoke(this);
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

        public void Destroy()
        {
            Elapsed = null;

            Pause();

            _seconds = ZeroSeconds;
        }
    }
}
