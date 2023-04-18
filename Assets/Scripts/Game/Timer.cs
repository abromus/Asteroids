using System;
using Asteroids.Core;

namespace Asteroids.Game
{
    public sealed class Timer : ITimer, IUpdatable
    {
        private readonly IUpdater _updater;

        private float _seconds;

        public float TimeLeft => _seconds;

        public bool IsElapsed => _seconds <= 0f;

        public Action Elapsed { get; set; }

        public Timer(IUpdater updater, float seconds = 0f)
        {
            _updater = updater;
            _seconds = seconds;

            _updater.Add(this);
        }

        public void Tick(float deltaTime)
        {
            _seconds -= deltaTime;

            if (_seconds <= 0)
            {
                _updater.Remove(this);

                Elapsed.SafeInvoke();
            }
        }

        public void UpdateTime(float seconds)
        {
            _seconds = seconds;

            _updater.Add(this);
        }
    }
}
