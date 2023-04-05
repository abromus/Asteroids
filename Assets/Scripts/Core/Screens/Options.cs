using Asteroids.Core.Settings;
using System.Collections.Generic;

namespace Asteroids.Core.Screens
{
    public sealed class Options
    {
        private readonly IReadOnlyList<IUiFactory> _uiFactories;

        public IReadOnlyList<IUiFactory> UiFactories => _uiFactories;

        public Options(IReadOnlyList<IUiFactory> uiFactories)
        {
            _uiFactories = uiFactories;
        }
    }
}
