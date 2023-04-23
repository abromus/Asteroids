using System;

namespace Asteroids.Game.Screens
{
    public interface IGameOverScreen
    {
        public Action Restarted { get; set; }
    }
}
