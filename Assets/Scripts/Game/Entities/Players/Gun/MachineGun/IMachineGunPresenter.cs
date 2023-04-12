using Asteroids.Core;

namespace Asteroids.Game
{
    public interface IMachineGunPresenter : IPresenter
    {
        public IMachineGunView View { get; }

        public void Rotate(Float3 rotation);

        public void TryShoot();
    }
}
