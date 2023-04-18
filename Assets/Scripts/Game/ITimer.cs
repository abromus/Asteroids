using System;

namespace Asteroids.Game
{
    public interface ITimer
    {
        public float TimeLeft { get; }

        public bool IsElapsed { get; }

        public Action Elapsed { get; set; }

        public void UpdateTime(float seconds);
    }
}
