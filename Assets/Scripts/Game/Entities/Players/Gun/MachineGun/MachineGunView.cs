using UnityEngine;

namespace Asteroids.Game
{
    public sealed class MachineGunView : View, IMachineGunView
    {
        public Transform Transform => transform;

        public void Init() { }

        public void SetParent(Transform parent)
        {
            transform.SetParent(parent);
            transform.localPosition = Vector3.zero;
        }
    }
}
