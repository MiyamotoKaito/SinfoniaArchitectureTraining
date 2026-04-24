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
        public void CalculateDamage(MinionEntity attacker, MinionEntity target)
        {
            // 攻撃者か対象が既に死亡していたら処理しない
            if (attacker == null || target == null) return;

            float totalDamage = attacker.AttackPower.AttackPowerValue;
            foreach (var attackStep in _attackSteps)
            {
                totalDamage = attackStep.Execute(totalDamage, attacker);
            }
            if (totalDamage > 0)
            {
                target.TakeDamage(totalDamage);
            }
        }
        private readonly List<IAttackStep> _attackSteps;
    }
}
