namespace Asteroids.Screens
{
    public interface IScreen
    {
        public ScreenType ScreenType { get; }

        public void Init(BaseOptions options);
    }
}
