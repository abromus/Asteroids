using UnityEngine;

namespace Asteroids.Game.Settings
{
    [CreateAssetMenu(fileName = "BulletConfig", menuName = "Settings/Game/Player/Gun/BulletConfig")]
    public sealed class BulletConfig : ScriptableObject, IBulletConfig
    {
        [SerializeField] private float _speed;

        public float Speed => _speed;
    }
}
