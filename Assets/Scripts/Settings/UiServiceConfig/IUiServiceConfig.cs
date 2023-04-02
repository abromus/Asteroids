using System.Collections.Generic;

namespace Asteroids.Settings
{
    public interface IUiServiceConfig : IConfig
    {
        public IReadOnlyList<IUiService> UiServices { get; }
    }
}
