namespace Adaptor
{
    public interface IMinionHealthViewModel
    {
        float HealthChange(in MinionHealthDTO minionHealthDTO, out float currentHealth);
    }
}
