using System;

namespace Domain
{
    public readonly struct AttackPower : IEquatable<AttackPower>
    {
        public AttackPower(int value)
        {
            if (value < 1)
            {
                throw new ArgumentOutOfRangeException("初期攻撃力は1以上でなければならない" + (nameof(value)));
            }
            _attackPowerValue = value;
        }
        public int AttackPowerValue => _attackPowerValue;
        public bool Equals(AttackPower other) => AttackPowerValue == other.AttackPowerValue;
        private readonly int _attackPowerValue;
    }
}
