using Adaptor;
using UnityEngine;

namespace View
{
    public class MinionView : MonoBehaviour
    {
        public int ID => _id;
        public void Initialize(AttackController attackController,
                               AttackPresenter attackPresenter,
                               KillController killController,
                               KillPresenter killPresenter)
        {
            _attackController = attackController;
            _attackPresenter = attackPresenter;


            _killController = killController;
            _killPresenter = killPresenter;

            _id = GetID();

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

        private int _id;
        private float _currentHealth;
        private int GetID() => gameObject.GetInstanceID();
        private void ApplyDamage()
        {
            _currentHealth = _attackPresenter.Present(_id);
            if (_killPresenter.Present(_id) && _currentHealth <= 0)
            {
                _killController.Kill(_id);
                Destroy(gameObject);
            }
        }

        private void OnTriggerEnter(Collider other)
        {
            if (_attackPresenter != null) return;

            if (other.TryGetComponent<MinionView>(out var minionView))
            {
                minionView.TakeDamage(_id);
            }
        }
    }
}
