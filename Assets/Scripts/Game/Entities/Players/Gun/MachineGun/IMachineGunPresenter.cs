using Asteroids.Core;

namespace Asteroids.Game
{
    public interface IMachineGunPresenter : IPresenter
    {
        public Float3 Offset { get; }

        public Float3 Position { get; }

        public IMachineGunView View { get; }

        public void SetPosition(Float3 position);

        public void SetRotation(Float3 rotation);

        public void TryShoot();
    }
}
