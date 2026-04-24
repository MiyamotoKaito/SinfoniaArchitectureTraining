using Adaptor;

namespace View
{
    public class MinionMoveSpeedViewModel : IMinionMoveSpeedViewModel
    {
        public float GetMoveSpeed(in MinionMoveSpeedDTO minionMoveSpeedDTO, out float moveSpeed)
        {
            moveSpeed = minionMoveSpeedDTO.MoveSpeed;
            return moveSpeed;
        }
    }
}
