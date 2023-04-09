﻿using UnityEngine;

namespace Asteroids.Core.Settings
{
    [CreateAssetMenu(fileName = "AsteroidConfig", menuName = "Settings/AsteroidConfig")]
    public sealed class AsteroidConfig : ScriptableObject, IAsteroidConfig
    {
        [SerializeField] private float _damping;
        [SerializeField] private float _speed;

        public float Damping => _damping;

        public float Speed => _speed;
    }
}
