using UnityEngine;

namespace Asteroids.Game
{
    public sealed class MachineGunView : View, IMachineGunView
    {
        public void Init() { }

        public void Move(Vector2 value)
        {
            transform.Translate(value);
        }

        public void Rotate(Vector3 value)
        {
            transform.Rotate(value);
        }
    }
}
