using Asteroids.Core.Settings;
using UnityEngine;

namespace Asteroids.Game.Settings
{
    public interface IMachineGunConfig : IConfig
    {
        public float FiringRate { get; }

        public Vector3 Offset { get; }
    }
}
