using Asteroids.Core;
using Asteroids.Core.Screens;
using Asteroids.Core.Services;
using Asteroids.Game.Screens;
using UnityEngine;
using Bounds = Asteroids.Core.Bounds;

namespace Asteroids.Game.Services
{
    public interface IScreenSystem : IService
    {
        public Bounds Bounds { get; }

        public void CloseScreen(IScreen screen);

        public void CloseAllScreens();

        public void Init(IGameData gameData, IUpdater updater, Bounds bounds, Transform transform);

        public IGameOverScreen ShowGameOver(int score);

        public void ShowGame(IShipPresenter shipPresenter);
    }
}
