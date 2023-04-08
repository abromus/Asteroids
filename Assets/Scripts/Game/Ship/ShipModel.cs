using System;
using Asteroids.Core;
using UnityEngine;

namespace Asteroids.Game
{
    public sealed class ShipModel
    {
        private Vector2 _movement;
        private Vector3 _rotation;

        public Action<Vector2> OnMovementChanged { get; set; }

        public Action<Vector3> OnRotationChanged { get; set; }

        public Vector2 Movement
        {
            get
            {
                return _movement;
            }

            set
            {
                if (_movement == value)
                    return;

                _movement = value;
                OnMovementChanged.SafeInvoke(_movement);
            }
        }

        public Vector3 Rotation
        {
            get
            {
                return _rotation;
            }

            set
            {
                if (_rotation == value)
                    return;

                _rotation = value;
                OnRotationChanged.SafeInvoke(_rotation);
            }
        }
    }
}
