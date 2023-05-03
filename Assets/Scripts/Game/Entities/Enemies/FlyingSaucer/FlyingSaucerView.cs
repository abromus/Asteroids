namespace Asteroids.Game
{
    public sealed class FlyingSaucerView : View, IFlyingSaucerView
    {
        public void Activate()
        {
            gameObject.SetActive(true);
        }

        public void Deactivate()
        {
            if (this != null && gameObject != null)
                gameObject.SetActive(false);
        }
    }
}
