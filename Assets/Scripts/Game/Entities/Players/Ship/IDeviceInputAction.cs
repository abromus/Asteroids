namespace Asteroids.Game
{
    public interface IDeviceInputAction
    {
        public void Disable();

        public void Enable();

        public bool IsMoving();

        public bool IsRotatingLeft();

        public bool IsRotatingRight();

        public bool IsShooting();
    }
}
