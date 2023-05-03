using System;
using Asteroids.Core;
using Asteroids.Core.Screens;
using Asteroids.Game.Screens;
using Asteroids.Game.Services;

namespace Asteroids.Game
{
    public sealed class Scoreboard : IScoreboard
    {
        private int _score;
        private IGameOverScreen _screen;

        private readonly IScreenSystem _screenSystem;
        private readonly IShipPresenter _shipPresenter;
        private readonly IAsteroidSpawner<IAsteroidPresenter> _asteroidSpawner;
        private readonly IFlyingSaucerSpawner<IFlyingSaucerPresenter> _flyingSaucerSpawner;

        public Action Restarted { get; set; }

        public Scoreboard(
            IScreenSystem screenSystem,
            IShipPresenter shipPresenter,
            IAsteroidSpawner<IAsteroidPresenter> asteroidSpawner,
            IFlyingSaucerSpawner<IFlyingSaucerPresenter> flyingSaucerSpawner)
        {
            _screenSystem = screenSystem;
            _shipPresenter = shipPresenter;
            _asteroidSpawner = asteroidSpawner;
            _flyingSaucerSpawner = flyingSaucerSpawner;

            _shipPresenter.Destroyed += OnDestroyed;
            _asteroidSpawner.AsteroidDestroyed += UpdateScore;
            _asteroidSpawner.AsteroidFragmentDestroyed += UpdateScore;
            _flyingSaucerSpawner.FlyingSaucerDestroyed += UpdateScore;
        }

        public void Destroy()
        {
            _shipPresenter.Destroyed -= OnDestroyed;
            _asteroidSpawner.AsteroidDestroyed -= UpdateScore;
            _asteroidSpawner.AsteroidFragmentDestroyed -= UpdateScore;
            _flyingSaucerSpawner.FlyingSaucerDestroyed -= UpdateScore;
        }

        private void OnDestroyed()
        {
            _screenSystem.CloseAllScreens();

            _screen = _screenSystem.ShowGameOver(_score);
            _screen.Restarted += OnRestarted;
        }

        private void UpdateScore()
        {
            _score++;
        }

        private void OnRestarted()
        {
            _screenSystem.CloseScreen(_screen as IScreen);
            Restarted.SafeInvoke();
            Restarted = null;
        }
    }
}
