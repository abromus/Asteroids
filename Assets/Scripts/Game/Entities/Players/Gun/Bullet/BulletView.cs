namespace Asteroids.Game
{
    public sealed class BulletView : View, IBulletView
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
