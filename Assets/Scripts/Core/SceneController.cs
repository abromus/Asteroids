using UnityEngine;

namespace Asteroids.Core
{
    public abstract class SceneController : MonoBehaviour
    {
        public virtual void Run(IGameData gameData) { }
    }
}
