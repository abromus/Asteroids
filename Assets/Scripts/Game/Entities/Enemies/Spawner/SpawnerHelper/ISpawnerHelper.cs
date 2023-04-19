using Asteroids.Core;

namespace Asteroids.Game
{
    public interface ISpawnerHelper
    {
        public Float3 CalculatePosition(Float3 rotation);
    }
}
