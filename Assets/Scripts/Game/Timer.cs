namespace Asteroids.Game
{
    public sealed class Timer : ITimer
    {
        private float _seconds;
        private bool _isPaused;

        public bool IsElapsed => _seconds <= 0f;

        public bool IsPaused => _isPaused;

        public Timer(float seconds = 0f)
        {
            UpdateTime(seconds);
        }

        public void Tick(float deltaTime)
        {
            _seconds -= deltaTime;
        }

        public void UpdateTime(float seconds)
        {
            _seconds = seconds;
        }

        public void Pause()
        {
            _isPaused = true;
        }

        public void Resume()
        {
            _isPaused = false;
        }
    }
}
