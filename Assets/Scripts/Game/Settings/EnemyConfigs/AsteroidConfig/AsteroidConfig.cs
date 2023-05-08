using UnityEngine;

namespace Asteroids.Game.Settings
{
    [CreateAssetMenu(fileName = nameof(AsteroidConfig), menuName = ConfigKeys.EnemiesPathKey + nameof(AsteroidConfig))]
    public sealed class AsteroidConfig : ScriptableObject, IAsteroidConfig
    {
        [SerializeField] private float _speed;
        [SerializeField] private float _fragmentSpeed;

        public float FragmentSpeed => _fragmentSpeed;

        public float Speed => _speed;
    }
}
