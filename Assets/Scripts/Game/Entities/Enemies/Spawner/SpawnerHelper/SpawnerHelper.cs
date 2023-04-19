using Asteroids.Core;

namespace Asteroids.Game
{
    public sealed class SpawnerHelper : ISpawnerHelper
    {
        private readonly IQuarterStrategy _firstQuarter;
        private readonly IQuarterStrategy _secondsQuarter;
        private readonly IQuarterStrategy _thirdQuarter;
        private readonly IQuarterStrategy _fourthQuarter;

        public SpawnerHelper(Bounds bounds)
        {
            _firstQuarter = new FirstQuarterStrategy(bounds);
            _secondsQuarter = new SecondQuarterStrategy(bounds);
            _thirdQuarter = new ThirdQuarterStrategy(bounds);
            _fourthQuarter = new FourthQuarterStrategy(bounds);
        }

        public Float3 CalculatePosition(Float3 rotation)
        {
            var angle = rotation.Z % MathUtils.FullAngle;

            var strategy = GetStrategy(angle);

            var position = strategy.CalculatePosition();

            return position;
        }

        private IQuarterStrategy GetStrategy(float angle)
        {
            var strategy = angle >= MathUtils.ZeroAngle && angle <= MathUtils.QuarterAngle
                ? _firstQuarter
                : angle >= MathUtils.QuarterAngle && angle <= MathUtils.HalfAngle
                    ? _secondsQuarter
                    : angle >= -MathUtils.HalfAngle && angle <= -MathUtils.QuarterAngle
                        ? _thirdQuarter
                        : _fourthQuarter;

            return strategy;
        }
    }
}
