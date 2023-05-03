namespace Asteroids.Game
{
    public sealed class LaserView : View, ILaserView
    {
        public void Init() { }

        public void Activate()
        {
            gameObject.SetActive(true);
        }

        public void Deactivate()
        {
            gameObject.SetActive(false);
        }
    }
}
