using UnityEngine;

namespace Asteroids.Game
{
    public interface IBulletPresenter : IPresenter
    {
        public void SetPosition(Vector3 position);

        public void SetRotate(Vector3 rotation);
    }
}
