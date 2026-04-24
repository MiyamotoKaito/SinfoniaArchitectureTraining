namespace Adaptor
{
    public interface IMinionHealthViewModel
    {
        void HealthChange(in MinionHealthDTO minionHealthDTO, out float currentHealth);
    }
}
