using UnityEngine;

namespace Asteroids.Core
{
    public sealed class Bootstrapper : MonoBehaviour
    {
        [SerializeField] private CoreSceneController _coreSceneController;

        private void Awake()
        {
            _coreSceneController.CreateGame();
        }
    }
}
