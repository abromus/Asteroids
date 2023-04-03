namespace Asteroids.Core.Services
{
    public sealed class GameLoopState : IEnterState
    {
        private readonly IScreenSystem _screenSystem;

        public GameLoopState(IScreenSystem screenSystem)
        {
            _screenSystem = screenSystem;
        }

        public void Enter()
        {
            _screenSystem.ShowGame();
        }

        public void Exit() { }
    }
}
