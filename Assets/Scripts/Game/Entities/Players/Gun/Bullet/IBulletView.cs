namespace Asteroids.Game
{
    public interface IBulletView : IView
    {
        public void Init();

        public void Activate();

        public void Deactivate();
    }
}
