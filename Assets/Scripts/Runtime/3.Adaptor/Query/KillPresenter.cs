using Application;

namespace Adaptor
{
    public class KillPresenter
    {
        public KillPresenter(IMinionIsDeadViewModel minionIsDeadViewModel, IMinionRepository repository)
        {
            _minionIsDeadViewModel = minionIsDeadViewModel;
            _repository = repository;
        }
        public bool Present(int id)
        {
            _repository.TryGetMinion(id, out var target);
            return _minionIsDeadViewModel.IsDead(new MinionIsDeadDTO(target.Health.IsDead()));
        }
        private readonly IMinionRepository _repository;
        private readonly IMinionIsDeadViewModel _minionIsDeadViewModel;
    }
}
