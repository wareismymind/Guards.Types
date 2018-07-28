using System;
using wimm.Guardian;

namespace wimm.Guards.Types
{
    public struct VisibleString
    {
        private string Value
            => _value ?? throw new InvalidOperationException("VisibleString was default constructed. See docs");

        private readonly string _value;

        private VisibleString(string value)
        {
            _value = value.Require(nameof(value))
                .IsNotNullOrWhitespace()
                .Value;
        }

        public static implicit operator string(VisibleString name)
        {
            return name.Value;
        }

        public static implicit operator VisibleString(string value)
        {
            return new VisibleString(value);
        }

        public override string ToString()
        {
            return Value;
        }
    }
}
