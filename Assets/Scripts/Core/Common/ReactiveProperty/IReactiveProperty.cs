using System;

namespace Asteroids.Core
{
    public interface IReactiveProperty<T>
    {
        public T Value { get; set; }

        public Action<T> OnChanged { get; set; }
    }
}
