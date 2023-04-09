using UnityEngine;

namespace Asteroids.Game
{
    public interface IView
    {
        public void Move(Vector2 value);

        public void Rotate(Vector3 value);
    }
}
