namespace Asteroids.Game
{
    public interface IMachineGunPresenter : IGunPresenter
    {
        public IMachineGunView View { get; }

        public void TryShoot();
    }
}
