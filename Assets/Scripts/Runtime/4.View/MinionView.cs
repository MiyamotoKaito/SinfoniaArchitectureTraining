using UnityEngine;

namespace View
{
    public class MinionView : MonoBehaviour
    {
        public void Initialize(MinionViewModel viewModel)
        {
            _viewModel = viewModel;

            _viewModel.OnMinionHealthChanged += MinionTakeDamageHandler;
        }
        private MinionViewModel _viewModel;
        private void MinionTakeDamageHandler(float )
        {

        }
    }
}
