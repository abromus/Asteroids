using System;
using Asteroids.Core;

namespace Asteroids.Game
{
    public interface IShipPresenter : IPresenter, IDamaging
    {
        public float Acceleration { get; }

        public int LasersCount { get; }

        public float LasersReloadTime { get; }

        public Float3 Rotation { get; }

        public Action Destroyed { get; set; }
    }
}
