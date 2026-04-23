using Domain;
using UnityEngine;

namespace View
{
    public class MinionView : MonoBehaviour
    {
        public MinionType MinionType => _minionType;
        public int ID => GetID();
        public void Initialize(MinionViewModel viewModel)
        {
            _viewModel = viewModel;

            _viewModel.OnMinionHealthChanged += MinionTakeDamageHandler;
        }

        [SerializeField, Tooltip("ミニオンのタイプ")] private MinionType _minionType;
        private MinionViewModel _viewModel;
        private int GetID() => gameObject.GetInstanceID();
        private void MinionTakeDamageHandler(float damage)
        {

        }
    }
}
