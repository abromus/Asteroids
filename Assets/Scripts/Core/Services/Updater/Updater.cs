using System.Collections.Generic;

namespace Asteroids.Core.Services
{
    public sealed class Updater : IUpdater
    {
        private List<IUpdatable> _updatables;

        public Updater()
        {
            _updatables = new List<IUpdatable>();
        }

        public void Destroy()
        {
            _updatables.Clear();
            _updatables = null;
        }

        public void Add(IUpdatable updatable)
        {
            if (!_updatables.Contains(updatable))
                _updatables.Add(updatable);
        }

        public void Remove(IUpdatable updatable)
        {
            if (_updatables != null && _updatables.Contains(updatable))
                _updatables.Remove(updatable);
        }

        public void Tick(float deltaTime)
        {
            for (int i = 0; i < _updatables.Count; i++)
                _updatables[i].Tick(deltaTime);
        }
    }
}
