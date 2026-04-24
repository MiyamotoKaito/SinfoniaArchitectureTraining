using UnityEngine;

namespace Adaptor
{
    public ref struct MinionIsDeadDTO
    {
        public MinionIsDeadDTO(bool isDead)
        {
            IsDead = isDead;
        }

        public bool IsDead { get; }
    }
}
