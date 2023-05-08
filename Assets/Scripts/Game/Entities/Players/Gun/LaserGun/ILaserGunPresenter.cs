namespace Asteroids.Game
{
    public interface ILaserGunPresenter : IGunPresenter
    {
        public int LasersCount { get; }

        public float ReloadTime { get; }

        public ILaserGunView View { get; }

        public void TryShoot();
    }
}
