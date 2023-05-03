using Asteroids.Core;
using Asteroids.Core.Screens;
using UnityEngine;
using UnityEngine.UI;
using Screen = Asteroids.Core.Screens.Screen;

namespace Asteroids.Game.Screens
{
    public sealed class GameScreen : Screen
    {
        [SerializeField] private Text _coordinates;
        [SerializeField] private Text _rotation;
        [SerializeField] private Text _acceleration;
        [SerializeField] private Text _lasersCount;
        [SerializeField] private Text _lasersReloadTime;

        private GameScreenOptions _options;
        private IShipPresenter _shipPresenter;

        public override ScreenType ScreenType => ScreenType.Game;

        public override void Init(Options options)
        {
            _options = options as GameScreenOptions;

            _shipPresenter = _options.ShipPresenter;

            UpdateView();
        }

        public override void Close()
        {
            Closed.SafeInvoke(this);
        }

        public override void Tick(float deltaTime)
        {
            UpdateView();
        }

        private void UpdateView()
        {
            _coordinates.text = string.Format(
                GameScreenKeys.CoordinatesKey,
                ToF2Format(_shipPresenter.Position.X),
                ToF2Format(_shipPresenter.Position.Y));

            _rotation.text = string.Format(GameScreenKeys.RotationKey,
                ToF2Format(_shipPresenter.Rotation.Z));

            _acceleration.text = string.Format(GameScreenKeys.AccelerationKey,
                ToF2Format(_shipPresenter.Acceleration));

            _lasersCount.text = string.Format(GameScreenKeys.LasersCountKey, _shipPresenter.LasersCount);

            _lasersReloadTime.text = string.Format(GameScreenKeys.LasersReloadTimeKey,
                ToF2Format(_shipPresenter.LasersReloadTime));
        }

        private string ToF2Format(float value)
        {
            var f2Format = "F2";

            return value.ToString(f2Format);
        }

        private sealed class GameScreenKeys
        {
            public const string CoordinatesKey = "Координаты: ({0}; {1})";
            public const string RotationKey = "Угол поворота: {0}";
            public const string AccelerationKey = "Мгновенная скорость: {0}";
            public const string LasersCountKey = "Число зарядов лазера: {0}";
            public const string LasersReloadTimeKey = "Время отката лазера: {0}";
        }
    }
}
