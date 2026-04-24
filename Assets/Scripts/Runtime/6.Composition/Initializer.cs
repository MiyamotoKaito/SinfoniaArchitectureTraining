using Adaptor;
using Application;
using InfraStructure;
using System.Collections.Generic;
using UnityEngine;
using View;

namespace Composition
{
    public class Initializer : MonoBehaviour
    {
        public AttackPipeline AttackPipeline => _attackPipeline;
        public AttackUseCase AttackUseCase => _attackUseCase;
        public AttackController AttackController => _attackController;
        public AttackPresenter AttackPresenter => _attackPresenter;
        public KillUseCase KillUseCase => _killUseCase;
        public KillController KillController => _killController;
        public KillPresenter KillPresenter => _killPresenter;
        public MoveSpeedPresenter MoveSpeedPresenter => _moveSpeedPresenter;

        private List<IAttackStep> _attackSteps;
        private AttackPipeline _attackPipeline;
        private AttackUseCase _attackUseCase;
        private AttackController _attackController;
        private AttackPresenter _attackPresenter;
        private MinionRepository _minionRepository;
        private KillUseCase _killUseCase;
        private KillController _killController;
        private KillPresenter _killPresenter;

        private MinionHealthViewModel _minionHealthViewModel;
        private MinionIsDeadViewModel _minionIsDeadViewModel;

        private MoveSpeedPresenter _moveSpeedPresenter;
        private MinionMoveSpeedViewModel _minionMoveSpeedViewModel;

        private MinionSpawnUseCase _minionSpawnUseCase;
        private RegisterController _registerController;
        private MinionRegistry _minionRegistry;
        private void Initialize()
        {
            #region ViewModel
            _minionHealthViewModel = new MinionHealthViewModel();
            _minionIsDeadViewModel = new MinionIsDeadViewModel();
            _minionMoveSpeedViewModel = new();
            #endregion

            _minionRepository = FindAnyObjectByType<MinionRepository>();
            _minionRegistry = new MinionRegistry();

            _attackPipeline = new AttackPipeline(_attackSteps);
            _attackUseCase = new AttackUseCase(AttackPipeline);
            _attackController = new AttackController(AttackUseCase, _minionRepository);
            _attackPresenter = new AttackPresenter(_minionHealthViewModel, _minionRepository);
            _killUseCase = new KillUseCase(_minionRepository);
            _killController = new KillController(_killUseCase);
            _killPresenter = new KillPresenter(_minionIsDeadViewModel, _minionRepository);

            _moveSpeedPresenter = new MoveSpeedPresenter(_minionMoveSpeedViewModel, _minionRepository);

            _minionSpawnUseCase = new(_minionRepository);
            _registerController = new(_minionSpawnUseCase);


            var Spawns = FindObjectsByType<MinionSpawner>(FindObjectsSortMode.None);
            for (int i = 0; i < Spawns.Length; i++)
            {
                var spawn = Spawns[i];
                Debug.Assert(spawn != null);
                spawn.Init(_attackController,
                           _attackPresenter,
                           _killController,
                           _killPresenter,
                           _moveSpeedPresenter,
                           _registerController,
                           _minionRegistry,
                            (Team)i);
            }

        }
        private void InitializeSteps()
        {
            _attackSteps = new List<IAttackStep>
            {
                new CriticalStep(),
                new DefenceStep(),
            };
        }
        private void Awake()
        {
            InitializeSteps();
            Initialize();
        }
    }
}
