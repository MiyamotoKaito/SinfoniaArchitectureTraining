using Adaptor;
using UnityEngine;

namespace View
{
    public class MinionSpawner : MonoBehaviour
    {
        public void Init(AttackController attackController, AttackPresenter attackPresenter, KillController killController, KillPresenter killPresenter, MoveSpeedPresenter moveSpeedPresenter,RegisterController registerController)
        {
            Debug.Log("うへへへ");
            _attackController = attackController;
            _attackPresenter = attackPresenter;
            _killController = killController;
            _killPresenter = killPresenter;
            _moveSpeedPresenter = moveSpeedPresenter;
            _registerController = registerController;
            SpawnMinion();
        }
        [SerializeField] private MinionView _minionView;
        private AttackController _attackController;
        private AttackPresenter _attackPresenter;
        private KillController _killController;
        private KillPresenter _killPresenter;
        private MoveSpeedPresenter _moveSpeedPresenter;
        private RegisterController _registerController;
        private void SpawnMinion()
        {
            var minion = _minionView;
            _registerController.Register(minion.ID);
            Instantiate(minion, transform.position, Quaternion.identity);
            minion.Initialize(_attackController, _attackPresenter, _killController, _killPresenter, _moveSpeedPresenter);
        }
    }
}
