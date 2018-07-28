using System;
using wimm.Guardian;

namespace wimm.Guards.Types
{
    public struct Definitely<T>
    {
        public T Value => _set
            ? _value
            : throw new InvalidOperationException(
                $"{nameof(Value)} was not set. You have default initialized this struct.");

        private readonly bool _set;
        private readonly T _value;

        internal Definitely(T value)
        {
            _set = true;
            _value = value.Require(nameof(value)).IsNotNull().Value;
        }

        public static implicit operator Definitely<T>(T value)
        {
            return new Definitely<T>(value);
        }

        public static implicit operator T(Definitely<T> definitely)
        {
            return definitely.Value;
        }
    }
}
