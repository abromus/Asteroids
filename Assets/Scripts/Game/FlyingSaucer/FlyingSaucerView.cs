using UnityEngine;

namespace Asteroids.Game
{
    public sealed class FlyingSaucerView : MonoBehaviour
    {
        public void Init()
        {
        }

        public void StartDestroy()
        {
            Destroy(gameObject);
        }

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
