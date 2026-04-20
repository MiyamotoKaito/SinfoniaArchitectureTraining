using System;

namespace Domain
{
    public struct MoveSpeed : IEquatable<MoveSpeed>
    {
        public MoveSpeed(float value)
        {
            if (value < 0)
            {
                throw new ArgumentOutOfRangeException("移動速度は0以上でなければならない" + (nameof(value)));
            }
            _moveSpeedValue = value;
        }
        public float MoveSpeedValue => _moveSpeedValue;
        public bool Equals(MoveSpeed other) => MoveSpeedValue == other.MoveSpeedValue;
        private readonly float _moveSpeedValue;
    }
}
