using Domain;

namespace Application
{
    public class AttackUseCase : IAttackUseCase
    {
        public AttackUseCase(IAttackPipeline attackPipeline)
        {
            _attackPipeline = attackPipeline;
        }

        public void Execute(MinionEntity attacker, MinionEntity other)
        {
            _attackPipeline.CalculateDamage(attacker, other);
        }
        private readonly IAttackPipeline _attackPipeline;
    }
}
