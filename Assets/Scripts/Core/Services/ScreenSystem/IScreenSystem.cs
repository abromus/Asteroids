using UnityEngine;

namespace Asteroids.Core.Services
{
    public interface IScreenSystem : IService
    {
        public void Init(IGame game, Transform transform);

        public void ShowGame();
    }
}
