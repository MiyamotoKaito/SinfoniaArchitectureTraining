using System;

namespace Adaptor
{
    public interface IMinionMoveSpeedViewModel
    {
        float GetMoveSpeed(in MinionMoveSpeedDTO minionMoveSpeedDTO, out float moveSpeed);
    }
}
