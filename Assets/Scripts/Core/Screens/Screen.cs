using System;
using UnityEngine;

namespace Asteroids.Core.Screens
{
    public abstract class Screen : MonoBehaviour, IScreen
    {
        public abstract ScreenType ScreenType { get; }

        public Action<IScreen> Closed { get; set; }

        public abstract void Init(Options options = null);

        public abstract void Tick(float deltaTime);
    }
}
