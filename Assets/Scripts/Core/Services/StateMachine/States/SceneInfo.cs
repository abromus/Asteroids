using System;

namespace Asteroids.Core.Services
{
    public sealed class SceneInfo
    {
        public string Name;
        public Action Success;

        public SceneInfo(string name, Action success)
        {
            Name = name;
            Success = success;
        }
    }
}
