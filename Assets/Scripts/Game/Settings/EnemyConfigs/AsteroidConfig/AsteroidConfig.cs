using UnityEngine;

namespace Asteroids.Game.Settings
{
    [CreateAssetMenu(fileName = "AsteroidConfig", menuName = "Settings/Game/Enemies/AsteroidConfig")]
    public sealed class AsteroidConfig : ScriptableObject, IAsteroidConfig
    {
        [SerializeField] private float _damping;
        [SerializeField] private float _speed;
        [SerializeField] private float _fragmentSpeed;

        public float FragmentSpeed => _fragmentSpeed;

        public float Damping => _damping;

        public float Speed => _speed;
    }
}
