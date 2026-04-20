using System;

namespace Domain
{
    public struct CriticalChance : IEquatable<CriticalChance>
    {
        public CriticalChance(float value)
        {
            if (value < 0)
            {
                throw new ArgumentOutOfRangeException("クリティカル率は0以上でなければならない" + (nameof(value)));
            }
            _criticalChanceValue = value;
        }
        public float CriticalChanceValue => _criticalChanceValue;
        public bool Equals(CriticalChance other) => CriticalChanceValue == other.CriticalChanceValue;
        private readonly float _criticalChanceValue;
    }
}
