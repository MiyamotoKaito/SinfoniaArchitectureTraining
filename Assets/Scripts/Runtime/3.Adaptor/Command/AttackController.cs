using Application;

namespace Adaptor
{
    public class AttackController
    {
        public AttackController(IAttackUseCase attackUseCase, IMinionRepository minionRepository)
        {
            _attackUseCase = attackUseCase;
            _repository = minionRepository;
        }

        public void Attack(int attackerId, int targetId)
        {
            _repository.TryGetMinion(attackerId, out var attacker);
            _repository.TryGetMinion(targetId, out var target);
            _attackUseCase.Execute(attacker, target);
        }
        private readonly IMinionRepository _repository;
        private readonly IAttackUseCase _attackUseCase;
    }
}
