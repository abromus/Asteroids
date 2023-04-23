using Asteroids.Core;
using UnityEngine;

namespace Asteroids.Game
{
    public sealed class AsteroidFragmentView : View, IAsteroidFragmentView
    {
        public void Move(Float3 value)
        {
            transform.position = value.ToVector3();
        }

        public void Rotate(Float3 value)
        {
            transform.rotation = Quaternion.Euler(value.ToVector3());
        }

        public void Activate()
        {
            gameObject.SetActive(true);
        }

        public void Deactivate()
        {
            if (this != null && gameObject != null)
                gameObject.SetActive(false);
        }
    }
}
