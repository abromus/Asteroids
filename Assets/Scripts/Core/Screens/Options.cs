using System.Collections.Generic;
using Asteroids.Core.Settings;

namespace Asteroids.Core.Screens
{
    public class Options
    {
        private readonly IReadOnlyList<IUiFactory> _uiFactories;

        public IReadOnlyList<IUiFactory> UiFactories => _uiFactories;

        public Options(IReadOnlyList<IUiFactory> uiFactories)
        {
            _uiFactories = uiFactories;
        }
    }
}
