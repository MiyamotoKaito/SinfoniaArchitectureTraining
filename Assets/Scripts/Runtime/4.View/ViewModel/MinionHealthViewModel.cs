using Adaptor;
using System;

namespace View
{
    public class MinionHealthViewModel : IMinionHealthViewModel
    {

        public float HealthChange(in MinionHealthDTO minionHealthDTO, out float currentHealth)
        {
            currentHealth = minionHealthDTO.Health;
            return currentHealth;
        }
    }
}
