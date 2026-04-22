using Domain;
using UnityEngine;

namespace Application
{
    public interface IAttackStep
    {
        float Execute(float totalDamage, MinionEntity other);
    }
}
