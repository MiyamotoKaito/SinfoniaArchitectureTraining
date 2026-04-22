using System.Collections.Generic;
using Domain;

namespace Application
{
    public class AttackPipeline : IAttackPipeline
    {
        public AttackPipeline(List<IAttackStep> attackSteps)
        {
            _attackSteps = attackSteps;
        }
        public void CalculateDamage(MinionEntity attacker, MinionEntity other)
        {
            float totalDamage = attacker.AttackPower.AttackPowerValue;
            foreach (var attackStep in _attackSteps)
            {
                totalDamage = attackStep.Execute(totalDamage, attacker);
            }
            if (totalDamage > 0)
            {
                other.TakeDamage(totalDamage);
            }
        }
        private readonly List<IAttackStep> _attackSteps;
    }
}
