using Application;
using Domain;

namespace Adaptor
{
    public class AttackController
    {
        public AttackController(IAttackUseCase attackUseCase)
        {
            _attackUseCase = attackUseCase;
        }

        public void Attack(MinionEntity attacker, MinionEntity other)
        {
            _attackUseCase.Execute(attacker, other);
        }

        private readonly IAttackUseCase _attackUseCase;
    }
}
