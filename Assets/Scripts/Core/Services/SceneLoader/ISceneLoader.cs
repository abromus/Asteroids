using System;

namespace Asteroids.Core.Services
{
    public interface ISceneLoader : IService
    {
        public void Load(string name, Action success);
    }
}
