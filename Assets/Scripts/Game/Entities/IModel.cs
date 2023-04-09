using System;
using UnityEngine;

namespace Asteroids.Game
{
    public interface IModel
    {
        public Action<Vector2> OnMovementChanged { get; set; }

        public Action<Vector3> OnRotationChanged { get; set; }

        public Vector2 Movement { get; set; }

        public Vector3 Rotation { get; set; }
    }
}
