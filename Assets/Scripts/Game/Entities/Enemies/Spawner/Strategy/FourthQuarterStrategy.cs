using Asteroids.Core;

namespace Asteroids.Game
{
    public sealed class FourthQuarterStrategy : IQuarterStrategy
    {
        private readonly Bounds _bounds;

        public FourthQuarterStrategy(Bounds bounds)
        {
            _bounds = bounds;
        }

        public Float3 CalculatePosition()
        {
            var half = 0.5f;

            var x = _bounds.Center.X + MathUtils.Value * _bounds.Size.X;
            var y = x > _bounds.Max.X ? _bounds.Max.Y - MathUtils.Value * _bounds.Size.Y * half : _bounds.Max.Y;

            var position = x > _bounds.Max.X ? new Float3(_bounds.Max.X, y) : new Float3(x, y);

            return position;
        }
    }
}
