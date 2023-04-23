using System;

namespace Asteroids.Game
{
    public interface IScoreboard
    {
        public Action Restarted { get; set; }

        public void Destroy();
    }
}
