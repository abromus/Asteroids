using Asteroids.Core.Settings;
using UnityEngine;

namespace Asteroids.Game.Settings
{
    public interface ILaserGunConfig : IConfig
    {
        public int Capacity { get; }

        public float FiringRate { get; }

        public float RegenerateTime { get; }

        public float ReloadTime { get; }

        public Vector3 Offset { get; }
    }
}
