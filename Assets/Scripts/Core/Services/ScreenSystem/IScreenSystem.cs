using UnityEngine;

namespace Asteroids.Core.Services
{
    public interface IScreenSystem : IService
    {
        public void Init(Transform transform);
    }
}
