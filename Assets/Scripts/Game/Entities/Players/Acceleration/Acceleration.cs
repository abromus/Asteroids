using Asteroids.Core;

namespace Asteroids.Game
{
    public sealed class Acceleration : IAcceleration
    {
        private float _currentSpeed;

        private readonly float _defaultSpeed;

        public float Speed => _currentSpeed;

        public Acceleration(float defaultSpeed)
        {
            _defaultSpeed = defaultSpeed;
        }

        public void SlowDown(float deltaTime)
        {
            var result = _currentSpeed - _defaultSpeed * deltaTime;

            _currentSpeed = result > MathUtils.Zero ? result : MathUtils.Zero;
        }

        public void SpeedUp(float deltaTime)
        {
            var result = _currentSpeed + _defaultSpeed * deltaTime;

            _currentSpeed = result >= _defaultSpeed ? _defaultSpeed : result;
        }
    }
}
