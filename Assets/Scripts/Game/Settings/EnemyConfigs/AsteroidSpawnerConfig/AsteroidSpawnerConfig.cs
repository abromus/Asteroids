using UnityEngine;

namespace Asteroids.Game.Settings
{
    [CreateAssetMenu(fileName = nameof(AsteroidSpawnerConfig), menuName = ConfigKeys.EnemiesPathKey + nameof(AsteroidSpawnerConfig))]
    public sealed class AsteroidSpawnerConfig : ScriptableObject, IAsteroidSpawnerConfig
    {
        [SerializeField] private int _fragmentCount;
        [SerializeField] private int _maxCount;
        [SerializeField] private float _spawnDelay;

        public int FragmentCount => _fragmentCount;

        public int MaxCount => _maxCount;

        public float SpawnDelay => _spawnDelay;
    }
}
