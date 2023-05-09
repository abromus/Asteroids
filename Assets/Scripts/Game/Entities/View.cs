using Asteroids.Core;
using UnityEngine;

namespace Asteroids.Game
{
    public abstract class View : MonoBehaviour, IView
    {
        public void Activate()
        {
            if (this != null && transform != null)
                gameObject.SetActive(true);
        }

        public void Deactivate()
        {
            if (this != null && gameObject != null)
                gameObject.SetActive(false);
        }

        public void Move(Float3 value)
        {
            if (this != null && transform != null)
                transform.position = value.ToVector3();
        }

        public void Rotate(Float3 value)
        {
            if (this != null && transform != null)
                transform.rotation = Quaternion.Euler(value.ToVector3());
        }
    }
}
