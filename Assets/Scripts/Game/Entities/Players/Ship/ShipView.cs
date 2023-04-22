using Asteroids.Core;
using Asteroids.Game.Settings;
using UnityEngine;
using UnityEngine.InputSystem;

namespace Asteroids.Game
{
    public sealed class ShipView : View, IShipView
    {
        [SerializeField] private PlayerInput _playerInput;
        [SerializeField] private Transform _firstGun;
        [SerializeField] private Transform _secondGun;

        public void Init(IInputConfig inputConfig, ILaserGunView laserGunView, IMachineGunView machineGunView)
        {
            _playerInput.actions = inputConfig.Actions;
            _playerInput.SwitchCurrentActionMap(inputConfig.DefaultActionMap);
            _playerInput.notificationBehavior = inputConfig.Behaviour;

            laserGunView.SetParent(_secondGun);
            machineGunView.SetParent(_firstGun);
        }

        public void Move(Float3 value)
        {
            transform.position = value.ToVector3();
        }

        public void Rotate(Float3 value)
        {
            transform.rotation = Quaternion.Euler(value.ToVector3());
        }
    }
}
