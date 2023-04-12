﻿using UnityEngine;

namespace Asteroids.Game.Settings
{
    [CreateAssetMenu(fileName = "ShipConfig", menuName = "Settings/Game/Player/ShipConfig")]
    public sealed class ShipConfig : ScriptableObject, IShipConfig
    {
        [SerializeField] private float _damping;
        [SerializeField] private float _speed;

        public float Damping => _damping;

        public float Speed => _speed;
    }
}