using Asteroids.Core;

namespace Asteroids.Game
{
    public sealed class ThirdQuarterStrategy : IQuarterStrategy
    {
        private readonly Bounds _bounds;

        public ThirdQuarterStrategy(Bounds bounds)
        {
            _bounds = bounds;
        }

        public Float3 CalculatePosition()
        {
            var x = _bounds.Center.X - MathUtils.Value * _bounds.Size.X;
            var y = x < _bounds.Min.X ? _bounds.Max.Y - MathUtils.Value * _bounds.Size.Y / 2f : _bounds.Max.Y;

            var position = x < _bounds.Min.X ? new Float3(_bounds.Min.X, y) : new Float3(x, y);

            return position;
        }
    }
}
