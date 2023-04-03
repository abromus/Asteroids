using Asteroids.Screens;
using UnityEngine;
using Screen = Asteroids.Screens.Screen;

namespace Asteroids.Game
{
    public sealed class GameScreen : Screen
    {
        [SerializeField] private ShipView _shipPrefab;

        public override ScreenType ScreenType => ScreenType.Game;

        public override void Init(BaseOptions options)
        {
            var shipView = Instantiate(_shipPrefab);

            var shipModel = new ShipModel();
            var shipPresenter = new ShipPresenter(shipModel, shipView);
        }
    }
}
