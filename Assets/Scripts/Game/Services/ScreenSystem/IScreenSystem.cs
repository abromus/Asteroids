using Asteroids.Core;
using Asteroids.Core.Services;
using UnityEngine;

namespace Asteroids.Game.Services
{
    public interface IScreenSystem : IService
    {
        public void Init(IGameData gameData, Transform transform);

        public void ShowGame();
    }
}
