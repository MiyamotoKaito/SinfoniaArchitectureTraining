using Domain;

namespace Application
{
    public class CriticalStep : IAttackStep
    {
        public float Execute(float totalDamage, MinionEntity other)
        {
            return IsCritical(other.CriticalChance) ? totalDamage * other.CriticalDamage.CriticalDamageValue : totalDamage;
        }

        private bool IsCritical(CriticalChance criticalChance)
        {
            return criticalChance.CriticalChanceValue < UnityEngine.Random.Range(0f, 100f);
        }
    }
}
