using Domain;

namespace Application
{
    public interface IAttackPipeline
    {
        void CalculateDamage(MinionEntity attacker, MinionEntity target);
    }
}
