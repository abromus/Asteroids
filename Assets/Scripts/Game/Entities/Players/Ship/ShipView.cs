using Asteroids.Game.Settings;
using UnityEngine;
using UnityEngine.InputSystem;

namespace Asteroids.Game
{
    public sealed class ShipView : View, IShipView
    {
        [SerializeField] private PlayerInput _playerInput;

        public void Init(IInputConfig inputConfig)
        {
            _playerInput.actions = inputConfig.Actions;
            _playerInput.SwitchCurrentActionMap(inputConfig.DefaultActionMap);
            _playerInput.notificationBehavior = inputConfig.Behaviour;
        }

        public void Move(Vector2 value)
        {
            transform.Translate(value);
        }

        public void Rotate(Vector3 value)
        {
            transform.Rotate(value);
        }
    }
}
