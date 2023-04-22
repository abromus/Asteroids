using Asteroids.Core;

namespace Asteroids.Game
{
    public interface ILaserGunPresenter : IPresenter
    {
        public Float3 Offset { get; }

        public ILaserGunView View { get; }

        public void SetPosition(Float3 position);

        public void SetRotation(Float3 rotation);

        public void TryShoot();
    }
}
