namespace Asteroids.Game
{
    public interface IAcceleration
    {
        public float Speed { get; }

        public void SpeedUp(float deltaTime);

        public void SlowDown(float deltaTime);
    }
}
