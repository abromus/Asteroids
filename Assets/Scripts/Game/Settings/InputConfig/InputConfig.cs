using UnityEngine;
using UnityEngine.InputSystem;

namespace Asteroids.Game.Settings
{
    [CreateAssetMenu(fileName = nameof(InputConfig), menuName = ConfigKeys.GamePathKey + nameof(InputConfig))]
    public sealed class InputConfig : ScriptableObject, IInputConfig
    {
        [SerializeField] private InputActionAsset _actions;
        [SerializeField] private PlayerNotifications _behaviour;

        public InputActionAsset Actions => _actions;

        public PlayerNotifications Behaviour => _behaviour;
    }
}
