using Application;
using UnityEngine;

namespace Adaptor
{
    public class MoveSpeedPresenter
    {
        public MoveSpeedPresenter(IMinionMoveSpeedViewModel viewModel, IMinionRepository repository)
        {
            _viewModel = viewModel;
            _repository = repository;
        }
        public float GetMoveSpeed(int id)
        {
            if (_repository.TryGetMinion(id, out var target))
            {
                _viewModel.GetMoveSpeed(new MinionMoveSpeedDTO(target.MoveSpeed.MoveSpeedValue), out var currentMoveSpeed);
                return currentMoveSpeed;
            }
            Debug.LogWarning($"なにかがNull{_viewModel}{_repository}");
            return 0f;
        }

        private readonly IMinionRepository _repository;
        private readonly IMinionMoveSpeedViewModel _viewModel;
    }
}
