using Adaptor;
using UnityEngine;

namespace View
{
    /// <summary>
    /// ミニオンのスポーンを管理するクラス。
    /// 自陣営のミニオンが死亡した際に新たなミニオンを生成する。
    /// </summary>
    public class MinionSpawner : MonoBehaviour
    {
        /// <summary>
        /// 必要な依存を注入し、初回スポーンを行う。
        /// </summary>
        public void Init(
            AttackController attackController,
            AttackPresenter attackPresenter,
            KillController killController,
            KillPresenter killPresenter,
            MoveSpeedPresenter moveSpeedPresenter,
            RegisterController registerController,
            MinionRegistry registry,
            Team team)
        {
            _attackController = attackController;
            _attackPresenter = attackPresenter;
            _killController = killController;
            _killPresenter = killPresenter;
            _moveSpeedPresenter = moveSpeedPresenter;
            _registerController = registerController;
            _registry = registry;
            _team = team;

            SpawnMinion();
        }

        [SerializeField, Tooltip("スポーンするミニオンのPrefab。")]
        private MinionView _minionPrefab;

        private AttackController _attackController;
        private AttackPresenter _attackPresenter;
        private KillController _killController;
        private KillPresenter _killPresenter;
        private MoveSpeedPresenter _moveSpeedPresenter;
        private RegisterController _registerController;
        private MinionRegistry _registry;
        private Team _team;
        private MinionView _currentMinion;

        private void OnDestroy()
        {
            // 購読中のイベントを解除する
            if (_currentMinion != null)
            {
                _currentMinion.OnMinionDead -= HandleMinionDeadHandler;
            }
        }

        /// <summary>
        /// ミニオン死亡時のイベントハンドラ。新たなミニオンをスポーンする。
        /// </summary>
        private void HandleMinionDeadHandler()
        {
            SpawnMinion();
        }

        /// <summary>
        /// ミニオンをスポーンし、レジストリへ登録・ターゲットを設定する。
        /// </summary>
        private void SpawnMinion()
        {
            // 前のインスタンスのイベントを解除する
            if (_currentMinion != null)
            {
                _currentMinion.OnMinionDead -= HandleMinionDeadHandler;
            }

            var minion = Instantiate(_minionPrefab, transform.position, Quaternion.identity);

            // IDをリポジトリに登録する
            _registerController.Register(minion.ID);

            // ミニオンに必要な依存を注入する
            minion.Initialize(
                _attackController,
                _attackPresenter,
                _killController,
                _killPresenter,
                _moveSpeedPresenter);

            // レジストリに登録する
            _registry.Register(_team, minion);

            // 敵がすでに存在していればお互いのターゲットを設定する
            var enemy = _registry.GetEnemy(_team);
            if (enemy != null)
            {
                minion.SetTarget(enemy.transform);
                enemy.SetTarget(minion.transform);
            }

            minion.OnMinionDead += HandleMinionDeadHandler;
            _currentMinion = minion;
        }
    }
    /// <summary>
    /// ミニオンの陣営を表すEnum。
    /// </summary>
    public enum Team
    {
        A,
        B,
    }
}
