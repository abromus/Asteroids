using UnityEngine;

namespace Asteroids.Game
{
    public interface ILaserGunView : IView
    {
        public Transform Transform { get; }

        public void Init();

        public void SetParent(Transform parent);
    }
}
