namespace Asteroids.Game
{
    public interface IPresenter : IUpdatable
    {
        public void Destroy();

        public void Disable();

        public void Enable();
    }
}
