using Application;
using System.Collections.Generic;
using UnityEngine;

namespace Composition
{
    public class Initializer : MonoBehaviour
    {
        public AttackPipeline AttackPipeline => _attackPipeline;
        public AttackUseCase AttackUseCase => _attackUseCase;

        private List<IAttackStep> _attackSteps;
        private AttackPipeline _attackPipeline;
        private AttackUseCase _attackUseCase;
        private void Initialize()
        {
            _attackPipeline = new AttackPipeline(_attackSteps);
            _attackUseCase = new AttackUseCase(AttackPipeline);
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
