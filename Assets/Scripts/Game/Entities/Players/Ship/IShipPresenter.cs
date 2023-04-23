using Asteroids.Core;

namespace Asteroids.Game
{
    public interface IShipPresenter : IPresenter
    {
        public float Acceleration { get; }

        public int LasersCount { get; }

        public float LasersReloadTime { get; }

        public Float3 Rotation { get; }
    }
}
