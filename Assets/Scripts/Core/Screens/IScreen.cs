namespace Asteroids.Core.Screens
{
    public interface IScreen
    {
        public ScreenType ScreenType { get; }

        public void Init(Options options);
    }
}
