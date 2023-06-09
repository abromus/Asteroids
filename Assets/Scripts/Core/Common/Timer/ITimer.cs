﻿using System;

namespace Asteroids.Game
{
    public interface ITimer
    {
        public bool IsElapsed { get; }

        public float TimeLeft { get; }

        public Action<ITimer> Elapsed { get; set; }

        public void Destroy();

        public void Pause();

        public void Resume();

        public void Tick(float deltaTime);

        public void UpdateTime(float seconds);
    }
}
