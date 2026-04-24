using Application;

namespace Adaptor
{
    public class AttackPresenter
    {
        public AttackPresenter(IMinionHealthViewModel viewModel, IMinionRepository repository)
        {
            _viewModel = viewModel;
            _repository = repository;
        }

        public float Present(int id)
        {
            _repository.TryGetMinion(id, out var target);
            _viewModel.HealthChange(new MinionHealthDTO(target.Health.Hp), out var currentHealth);
            return currentHealth;
        }
        private readonly IMinionRepository _repository;
        private readonly IMinionHealthViewModel _viewModel;
    }
}