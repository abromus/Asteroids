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

        public void Init(IInputConfig inputConfig, IMachineGunView machineGunView, ILaserGunView laserGunView)
        {
            _playerInput.actions = inputConfig.Actions;
            _playerInput.SwitchCurrentActionMap(inputConfig.DefaultActionMap);
            _playerInput.notificationBehavior = inputConfig.Behaviour;

            machineGunView.SetParent(_firstGun);
            laserGunView.SetParent(_secondGun);
        }

        public void DestroyView()
        {
            if (this != null && gameObject != null)
                Destroy(gameObject);
        }
    }
}
