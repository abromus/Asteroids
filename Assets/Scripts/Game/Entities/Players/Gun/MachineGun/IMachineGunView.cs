using UnityEngine;

namespace Asteroids.Game
{
    public interface IMachineGunView : IView
    {
        public Transform Transform { get; }

        public void Init();

        public void SetParent(Transform parent);
    }
}
