using Adaptor;

namespace View
{
    public class MinionIsDeadViewModel : IMinionIsDeadViewModel
    {
        public bool IsDead(in MinionIsDeadDTO minionIsDeadDTO)
        {
            return minionIsDeadDTO.IsDead;
        }
    }
}
