namespace Asteroids.Game
{
    public sealed class AsteroidFragmentView : View, IAsteroidFragmentView
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
