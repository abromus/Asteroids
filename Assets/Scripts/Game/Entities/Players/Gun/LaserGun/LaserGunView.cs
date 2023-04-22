using Asteroids.Core;
using UnityEngine;

namespace Asteroids.Game
{
    public sealed class LaserGunView : View, ILaserGunView
    {
        public Transform Transform => transform;

        public void Init() { }

        public void Move(Float3 value)
        {
            transform.Translate(value.ToVector3());
        }

        public void Rotate(Float3 value)
        {
            transform.Rotate(value.ToVector3());
        }

        public void SetParent(Transform parent)
        {
            transform.SetParent(parent);
            transform.localPosition = Vector3.zero;
        }
    }
}
