using Asteroids.Core;
using Asteroids.Core.Services;
using UnityEngine;
using Bounds = Asteroids.Core.Bounds;

namespace Asteroids.Game.Services
{
    public interface IScreenSystem : IService
    {
        public Bounds Bounds { get; }

        public void Init(IGameData gameData, IUpdater updater, Bounds bounds, Transform transform);

        public void ShowGameOver(int score);

        public void ShowGame(IShipPresenter shipPresenter);
    }
}
