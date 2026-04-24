using Adaptor;

namespace View
{
    public class MinionHealthViewModel : IMinionHealthViewModel
    {

        public void HealthChange(in MinionHealthDTO minionHealthDTO, out float currentHealth)
        {
            currentHealth = minionHealthDTO.Health;
        }
    }
}
