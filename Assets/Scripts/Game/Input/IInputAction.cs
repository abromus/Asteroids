namespace Asteroids.Game.Input
{
    public interface IInputAction
    {
        public bool IsMoving { get; }

        public bool IsRotatingLeft { get; }

        public bool IsRotatingRight { get; }

        public bool IsShooting { get; }

        public void Disable();

        public void Enable();
    }
}
