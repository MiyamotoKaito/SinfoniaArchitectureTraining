using System;
using Adaptor;
using UnityEngine;
using UnityEngine.AI;

namespace View
{
    public class MinionView : MonoBehaviour
    {
        public event Action MinionDead;
        public int ID => _id;
        public void Initialize(AttackController attackController,
                               AttackPresenter attackPresenter,
                               KillController killController,
                               KillPresenter killPresenter,
                               MoveSpeedPresenter moveSpeedPresenter)
        {
            _attackController = attackController;
            _attackPresenter = attackPresenter;

            _killController = killController;
            _killPresenter = killPresenter;

            _moveSpeedPresenter = moveSpeedPresenter;

            _id = GetID();
            NavMeshAgentSetUp();
        }
        public void TakeDamage(int attackerId)
        {
            _attackController.Attack(attackerId, _id);
            ApplyDamage();
        }
        private AttackController _attackController;
        private AttackPresenter _attackPresenter;

        private KillController _killController;
        private KillPresenter _killPresenter;

        private MoveSpeedPresenter _moveSpeedPresenter;

        [SerializeField]
        private NavMeshAgent _navMeshAgent;
        private int _id;
        private float _currentHealth;
        private int GetID() => gameObject.GetInstanceID();
        private void ApplyDamage()
        {
            _currentHealth = _attackPresenter.Present(_id);
            if (_killPresenter.Present(_id) && _currentHealth <= 0)
            {
                _killController.Kill(_id);
                MinionDead?.Invoke();
                Destroy(gameObject);
            }
        }

        private void NavMeshAgentSetUp()
        {
            _navMeshAgent = GetComponent<NavMeshAgent>();
            Debug.Log(_moveSpeedPresenter == null);
            _navMeshAgent.speed = _moveSpeedPresenter.GetMoveSpeed(_id);
            _navMeshAgent.SetDestination(FindAnyObjectByType<MinionView>().transform.position);
        }
    }
}
