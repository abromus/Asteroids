using UnityEngine;

namespace Asteroids.Game.Settings
{
    [CreateAssetMenu(fileName = nameof(FlyingSaucerConfig), menuName = ConfigKeys.EnemiesPathKey + nameof(FlyingSaucerConfig))]
    public sealed class FlyingSaucerConfig : ScriptableObject, IFlyingSaucerConfig
    {
        [SerializeField] private float _damping;
        [SerializeField] private float _speed;

        public float Damping => _damping;

        public float Speed => _speed;
    }
}
