using System;

namespace Domain
{
    public struct CriticalDamage : IEquatable<CriticalDamage>
    {
        public CriticalDamage(float value)
        {
            if (value < 0)
            {
                throw new ArgumentOutOfRangeException("クリティカルダメージは0以上でなければならない" + (nameof(value)));
            }
            _criticalDamageValue = value;
        }
        public float CriticalDamageValue => _criticalDamageValue;
        public bool Equals(CriticalDamage other) => CriticalDamageValue == other.CriticalDamageValue;
        private readonly float _criticalDamageValue;
    }
}
