using Asteroids.Core;

namespace Asteroids.Game
{
    public interface IGunPresenter : IPresenter
    {
        public Float3 Offset { get; }

        public void SetPosition(Float3 position);

        public void SetRotation(Float3 rotation);
    }
}
