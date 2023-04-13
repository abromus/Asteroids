using Asteroids.Core;
using UnityEngine;

namespace Asteroids.Game
{
    public sealed class AsteroidView : View, IAsteroidView
    {
        public void Init() { }

        public void Move(Float3 value)
        {
            transform.position = value.ToVector3();
        }

        public void Rotate(Float3 value)
        {
            transform.rotation = Quaternion.Euler(value.ToVector3());
        }
    }
}
