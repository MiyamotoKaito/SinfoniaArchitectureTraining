using System;

namespace Domain
{
    public readonly struct AttackRange : IEquatable<AttackRange>
    {
        public AttackRange(float value)
        {
            if (value < 0)
            {
                throw new ArgumentOutOfRangeException("攻撃距離は0以上でなければならない" + (nameof(value)));
            }
            _attackRangeValue = value;
        }
        public float AttackRangeValue => _attackRangeValue;
        public bool Equals(AttackRange other) => AttackRangeValue == other.AttackRangeValue;

        private readonly float _attackRangeValue;
    }
}
