using System;

namespace wimm.Guards.Types
{
    public struct Defined<T> where T : struct, IComparable
    {
        private readonly bool _set;
        private T Value => _set ? _value : throw new InvalidOperationException($"{nameof(Defined<T>)} value was not set");

        private readonly T _value;

        private Defined(T value)
        {
            if (!Enum.IsDefined(typeof(T), value))
                throw new ArgumentOutOfRangeException(nameof(value), $"value was undefined for {nameof(T)}");

            _value = value;
            _set = true;
        }

        public static implicit operator T(Defined<T> defined)
        {
            return defined.Value;
        }

        public static implicit operator Defined<T>(T value)
        {
            return new Defined<T>(value);
        }
    }
}
