using UnityEngine;

namespace Asteroids.Game
{
    public interface ILaserGunView : IView
    {
        public void SetParent(Transform parent);
    }
}
