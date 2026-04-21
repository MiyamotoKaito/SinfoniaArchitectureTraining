using System;

namespace Domain
{
    public struct AttackSpeed : IEquatable<AttackSpeed>
    {
        public AttackSpeed(float value)
        {
            if (value < 0)
            {
                throw new ArgumentOutOfRangeException("攻撃速度は0以上でなければならない" + (nameof(value)));
            }
            _attackSpeedValue = value;
        }
        public float AttackSpeedValue => _attackSpeedValue;
        public bool Equals(AttackSpeed other) => AttackSpeedValue == other.AttackSpeedValue;
        private readonly float _attackSpeedValue;
    }
}
