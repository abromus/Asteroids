using Asteroids.Core.Factories;

namespace Asteroids.Core.Settings
{
    public interface IUiFactory : IFactory
    {
        public UiFactoryType UiFactoryType { get; }
    }
}
