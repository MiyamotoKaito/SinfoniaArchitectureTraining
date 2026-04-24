using System;
using Adaptor;
using UnityEngine;
using UnityEngine.AI;

namespace View
{
    /// <summary>
    /// ミニオンのViewクラス。移動・攻撃・死亡処理を担当する。
    /// </summary>
    public class MinionView : MonoBehaviour
    {
        /// <summary> ミニオンが死亡したときに発火するイベント。 </summary>
        public event Action OnMinionDead;

        /// <summary> このミニオンのID。 </summary>
        public int ID => _id;

        /// <summary>
        /// 必要な依存を注入し、NavMeshAgentをセットアップする。
        /// </summary>
        public void Initialize(
            AttackController attackController,
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

            SetUpNavMeshAgent();
        }

        /// <summary>
        /// 追跡対象のTransformを設定する。
        /// </summary>
        public void SetTarget(Transform target)
        {
            _target = target;
        }

        /// <summary>
        /// 攻撃を受けたときにダメージを処理する。
        /// </summary>
        public void TakeDamage(int attackerId)
        {
            Debug.Log($"攻撃を受けた : 攻撃者ID{attackerId}: 被害者ID{_id}");
            _attackController.Attack(attackerId, _id);
            ApplyDamage(attackerId); // ← attackerIdを渡す
        }

        [SerializeField, Tooltip("移動を制御するNavMeshAgent。")]
        private NavMeshAgent _navMeshAgent;

        private AttackController _attackController;
        private AttackPresenter _attackPresenter;
        private KillController _killController;
        private KillPresenter _killPresenter;
        private MoveSpeedPresenter _moveSpeedPresenter;
        private int _id;
        private float _currentHealth;
        private Transform _target;

        /// <summary>
        /// NavMeshAgentの速度を初期化する。
        /// </summary>
        private void SetUpNavMeshAgent()
        {
            _navMeshAgent = GetComponent<NavMeshAgent>();
            _navMeshAgent.speed = _moveSpeedPresenter.GetMoveSpeed(_id);
        }

        /// <summary>
        /// ダメージを適用し、HPが0以下なら死亡処理を行う。
        /// </summary>
        private void ApplyDamage(int attackerId)
        {
            if (_killPresenter.Present(_id) && _currentHealth <= 0)
            {
                _killController.Kill(_id);
                OnMinionDead?.Invoke();
                Destroy(gameObject);
            }

            var damage = _attackPresenter.Present(attackerId);
            _currentHealth -= damage;
            Debug.Log($"攻撃を食らった: 残りHP{_currentHealth} : 食らったダメージ{damage}");
        }
        private void Awake()
        {
            //インスタンスIDを取得しておく
            _id = gameObject.GetInstanceID();
        }

        private void Update()
        {
            // ターゲットが存在する間は毎フレーム追跡する
            if (_target != null)
            {
                _navMeshAgent.SetDestination(_target.position);
            }
        }
        private void OnTriggerEnter(Collider other)
        {
            // 敵ミニオンに接触したら攻撃する
            if (other.TryGetComponent<MinionView>(out var enemyMinion))
            {
                if (enemyMinion != null && enemyMinion.ID != _id)
                {
                    TakeDamage(enemyMinion.ID);
                }
            }
        }
    }
}