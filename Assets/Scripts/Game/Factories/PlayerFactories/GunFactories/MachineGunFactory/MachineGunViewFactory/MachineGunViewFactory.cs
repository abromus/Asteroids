using Asteroids.Core.Settings;
using UnityEngine;

namespace Asteroids.Game.Factory
{
    public sealed class MachineGunViewFactory : UiFactory, IMachineGunViewFactory
    {
        [SerializeField] private MachineGunView _prefab;

        public override UiFactoryType UiFactoryType => UiFactoryType.MachineGunViewFactory;

        public IMachineGunView Create()
        {
            var machineGun = Instantiate(_prefab);
            machineGun.Init();

            return machineGun;
        }
    }
}
