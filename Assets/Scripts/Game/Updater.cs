﻿using System.Collections.Generic;

namespace Asteroids.Game
{
    public sealed class Updater : IUpdater
    {
        private readonly List<IUpdatable> _updatables = new List<IUpdatable>();

        public void Add(IUpdatable updatable)
        {
            _updatables.Add(updatable);
        }

        public void Remove(IUpdatable updatable)
        {
            _updatables.Remove(updatable);
        }

        public void Tick(float deltaTime)
        {
            _updatables.ForEach(updatable => updatable.Tick(deltaTime));
        }
    }
}
