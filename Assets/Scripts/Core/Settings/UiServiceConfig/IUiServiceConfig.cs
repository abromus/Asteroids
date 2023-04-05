using System.Collections.Generic;

namespace Asteroids.Core.Settings
{
    public interface IUiServiceConfig : IConfig
    {
        public IReadOnlyList<IUiService> UiServices { get; }
    }
}
