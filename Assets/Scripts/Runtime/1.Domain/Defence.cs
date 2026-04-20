using System;
using UnityEngine;

namespace Domain
{
    public readonly struct Defence : IEquatable<Defence>
    {
        public Defence(int value)
        {
            if (value < 1)
            {
                throw new ArgumentOutOfRangeException("初期防御力は1以上でなければならない" + (nameof(value)));
            }
            _defeneceValue = value;
        }
        public int DefenceValue => _defeneceValue;
        public bool Equals(Defence other) => DefenceValue == other.DefenceValue;

        private readonly int _defeneceValue;
    }
}
