namespace Asteroids.Game
{
    public sealed class AsteroidView : View, IAsteroidView
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
