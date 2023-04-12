using System;

namespace Asteroids.Core
{
    public class ReactiveProperty<T> : IReactiveProperty<T>
    {
        private T _value;

        public T Value
        {
            get
            {
                return _value;
            }

            set
            {
                _value = value;

                OnChanged.SafeInvoke(_value);
            }
        }

        public Action<T> OnChanged { get; set; }
    }
}
