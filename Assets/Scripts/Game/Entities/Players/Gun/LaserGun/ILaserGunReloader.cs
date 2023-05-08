using System;

namespace Asteroids.Game
{
    public interface ILaserGunReloader
    {
        public bool IsReload { get; }

        public float ReloadTime { get; }

        public Action Reloaded { get; set; }

        public Action Regenerated { get; set; }

        public void Destroy();

        public void Disable();

        public void Enable();

        public void RegenerateLaser();

        public void Reload();

        public void StopRegeneration();
    }
}
