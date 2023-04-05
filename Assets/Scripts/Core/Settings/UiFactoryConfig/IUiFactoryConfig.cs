using System.Collections.Generic;

namespace Asteroids.Core.Settings
{
    public interface IUiFactoryConfig : IConfig
    {
        public IReadOnlyList<IUiFactory> UiFactories { get; }
    }
}
