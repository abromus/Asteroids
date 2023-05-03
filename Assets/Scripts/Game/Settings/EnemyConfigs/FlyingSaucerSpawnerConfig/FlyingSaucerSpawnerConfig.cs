using UnityEngine;

namespace Asteroids.Game.Settings
{
    [CreateAssetMenu(fileName = nameof(FlyingSaucerSpawnerConfig), menuName = ConfigKeys.EnemiesPathKey + nameof(FlyingSaucerSpawnerConfig))]
    public sealed class FlyingSaucerSpawnerConfig : ScriptableObject, IFlyingSaucerSpawnerConfig
    {
        [SerializeField] private int _maxCount;
        [SerializeField] private float _spawnDelay;

        public int MaxCount => _maxCount;

        public float SpawnDelay => _spawnDelay;
    }
}
