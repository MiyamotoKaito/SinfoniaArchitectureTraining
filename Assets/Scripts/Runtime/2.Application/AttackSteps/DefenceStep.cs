using Domain;
using UnityEngine;

namespace Application
{
    public class DefenceStep : IAttackStep
    {
        public float Execute(float totalDamage, MinionEntity other)
        {
            totalDamage /= other.Defence.DefenceValue;
            return totalDamage;
        }
    }
}
