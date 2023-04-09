using Asteroids.Core.Factories;
using Asteroids.Game.Settings;

namespace Asteroids.Game.Factory
{
    public interface IShipViewFactory : IFactory
    {
        public IShipView Create(IInputConfig inputConfig);
    }
}
