using System;
using Adaptor;
using UnityEngine;

namespace View
{
    public class MinionViewModel : MonoBehaviour
    {
        public event Action<float> OnMinionHealthChanged;

        public void HealthChange(in MinionHealthDTO minionHealthDTO)
        {
            OnMinionHealthChanged?.Invoke(minionHealthDTO.Health);
        }
    }
}
