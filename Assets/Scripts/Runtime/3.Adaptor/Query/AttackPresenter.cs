using Domain;

namespace Adaptor
{
    public class AttackPresenter
    {
        public AttackPresenter(AttackController attackController)
        {
            _attackController = attackController;
        }

        public void Present(MinionEntity minion, MinionEntity other)
        {
            _attackController.Attack(minion, other);
        }
        private readonly AttackController _attackController;
    }
}